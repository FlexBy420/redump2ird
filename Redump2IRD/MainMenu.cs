using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IsoTools;
using System.Threading;
using System.Threading.Tasks;

namespace Redump2IRD {
    public partial class MainMenu : Form {
        CancellationTokenSource cancellation_ = null;
        private static readonly byte[] D1_IV = { 105, 71, 71, 114, 175, 111, 218, 179, 66, 116, 58, 239, 170, 24, 98, 135 };
        private static readonly byte[] D1_KEY = { 56, 11, 207, 11, 83, 69, 91, 60, 120, 23, 171, 79, 163, 186, 144, 237 };

        public MainMenu() {
            // We set the icon here so that it doesn't get duplicated (20kB) in the exe for managaged/unmanaged resources.
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            Interaction.SetInteraction(new RedumpInteraction(pbCreateIRD, tbOutput, this));
        }
        
        private async void bCreateIRD_Click(object sender, EventArgs e) {
            // Prepare the D1/D2/PIC data in string form.
            string d1_dec_hexstring = tbD1Dec.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
            string d2_enc_hexstring = tbD2Enc.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
            string pic_hexstring = tbPic.Text.Replace("-", "").Replace(" ", "").Replace(",", "").Replace("\r", "").Replace("\n", "");
            if (String.IsNullOrEmpty(d1_dec_hexstring) || String.IsNullOrEmpty(d2_enc_hexstring) || String.IsNullOrEmpty(pic_hexstring) || d1_dec_hexstring.Length != 16 * 2 || d2_enc_hexstring.Length != 16 * 2 || pic_hexstring.Length < 115 * 2) {
                MessageBox.Show("Invalid D1/D2/PIC data, please fix.");
                return;
            }

            // Redump PIC is larger than 3k3y PIC, truncate if needed.
            pic_hexstring = pic_hexstring.Substring(0, 115 * 2);

            // Prepare the D1/D2/PIC data in byte form.
            byte[] d1 = HexStringToByteArray(d1_dec_hexstring);
            byte[] d2 = HexStringToByteArray(d2_enc_hexstring);
            byte[] pic = HexStringToByteArray(pic_hexstring);
            if (d1.Length != 16 || d2.Length != 16 || pic.Length != 115) {
                MessageBox.Show("D1/D2/PIC conversion issue, please report.");
                return;
            }

            if (cancellation_ != null && !cancellation_.IsCancellationRequested)
                cancellation_.Cancel();
            if (cancellation_ != null)
                cancellation_.Dispose();
            cancellation_ = new CancellationTokenSource();
            try {
                bool result = await new IrdCreateRedumpFile(false, true, d1, d2, pic).CreateIRD(cancellation_.Token);
                if (!result)
                    Interaction.Instance.ReportMessage("IrdCreateRedumpFile failed or cancled.", ReportType.Fail);
            } catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
        }

        private void tbD1Dec_TextChanged(object sender, EventArgs e) {
            if (tbD1Dec.ReadOnly)
                return;

            string d1_dec_hexstring = tbD1Dec.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
            tbD1Enc.ReadOnly = !String.IsNullOrEmpty(d1_dec_hexstring);
            if (String.IsNullOrEmpty(d1_dec_hexstring) || d1_dec_hexstring.Length != 32 || !IsHex(d1_dec_hexstring)) {
                tbD1Enc.Text = String.Empty;
                return;
            }

            // Convert the inputed D1 (decoded) data to a byte[], and encode it it.
            byte[] d1_dec = HexStringToByteArray(d1_dec_hexstring);
            if (d1_dec.Length > 0) {
                int? nullable = null;
                ODD.AESEncrypt(D1_KEY, D1_IV, d1_dec, 0, d1_dec.Length, d1_dec, 0, nullable);
                if (d1_dec.Length > 0) {
                    tbD1Enc.Text = ByteArrayToHexString(d1_dec);
                    return;
                }
            }

            tbD1Enc.Text = String.Empty;
        }

        private void tbD1Enc_TextChanged(object sender, EventArgs e) {
            if (tbD1Enc.ReadOnly)
                return;

            string d1_enc_hexstring = tbD1Enc.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
            tbD1Dec.ReadOnly = cbRedumpMode.Checked || !String.IsNullOrEmpty(d1_enc_hexstring);
            if (String.IsNullOrEmpty(d1_enc_hexstring) || d1_enc_hexstring.Length != 32 || !IsHex(d1_enc_hexstring)) {
                tbD1Dec.Text = String.Empty;
                return;
            }

            // Convert the inputed D1 (encoded) data to a byte[], and decode it it.
            byte[] d1_enc = HexStringToByteArray(d1_enc_hexstring);
            if (d1_enc.Length > 0) {
                int? nullable = null;
                ODD.AESDecrypt(D1_KEY, D1_IV, d1_enc, 0, d1_enc.Length, d1_enc, 0, nullable);
                if (d1_enc.Length > 0) {
                    tbD1Dec.Text = ByteArrayToHexString(d1_enc);
                    return;
                }
            }

            tbD1Dec.Text = String.Empty;
        }

        private void tbD2Dec_TextChanged(object sender, EventArgs e) {
            if (tbD2Dec.ReadOnly)
                return;

            // Note: D1 redump has some special logic, the XXXXXXXX gets converted to ?? 00000001 ??.
            string d2_dec_hexstring = tbD2Dec.Text.Replace("-", "").Replace(" ", "").Replace(",", "").Replace("XXXXXXXX", "00000001");
            tbD2Enc.ReadOnly = cbRedumpMode.Checked || !String.IsNullOrEmpty(d2_dec_hexstring);
            if (String.IsNullOrEmpty(d2_dec_hexstring) || d2_dec_hexstring.Length != 32 || !IsHex(d2_dec_hexstring)) {
                tbD2Enc.Text = String.Empty;
                return;
            }

            // Convert the inputed D2 (decoded) data to a byte[], and encode it it.
            byte[] d2_dec = HexStringToByteArray(d2_dec_hexstring);
            if (d2_dec.Length > 0) {
                int? nullable = null;
                ODD.AESEncrypt(Utilities.D2_KEY, Utilities.D2_IV, d2_dec, 0, d2_dec.Length, d2_dec, 0, nullable);
                if (d2_dec.Length > 0) {
                    tbD2Enc.Text = ByteArrayToHexString(d2_dec);
                    return;
                }                
            }

            tbD1Enc.Text = String.Empty;
        }

        private void tbD2Enc_TextChanged(object sender, EventArgs e) {
            if (tbD2Enc.ReadOnly)
                return;

            string d2_enc_hexstring = tbD2Enc.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
            tbD2Dec.ReadOnly = !String.IsNullOrEmpty(d2_enc_hexstring);
            if (String.IsNullOrEmpty(d2_enc_hexstring) || d2_enc_hexstring.Length != 32 || !IsHex(d2_enc_hexstring)) {
                tbD2Dec.Text = String.Empty;
                return;
            }

            // Convert the inputed D2 (encoded) data to a byte[], and decode it it.
            byte[] d2_enc = HexStringToByteArray(d2_enc_hexstring);
            if (d2_enc.Length > 0) {
                int? nullable = null;
                ODD.AESDecrypt(Utilities.D2_KEY, Utilities.D2_IV, d2_enc, 0, d2_enc.Length, d2_enc, 0, nullable);
                if (d2_enc.Length > 0) {
                    tbD2Dec.Text = ByteArrayToHexString(d2_enc);
                    return;
                }
            }

            tbD2Dec.Text = String.Empty;
        }

        private void cbRedumpMode_CheckedChanged(object sender, EventArgs e) {
            tbD1Dec.ReadOnly = tbD2Enc.ReadOnly = cbRedumpMode.Checked;
        }

        private void bCancel_Click(object sender, EventArgs e) {
            cancellation_.Cancel();
        }


        // Change the state of the forum, basicially "this.Enable = enable;".
        public void ChangeState(bool enable) {
            gbD1.Enabled = gbD2.Enabled = gbPic.Enabled = gbOutput.Enabled = enable;
            bCreateIRD.Enabled = cbRedumpMode.Enabled = enable;
            bCancel.Enabled = !enable;
        }


        // Fastest byte[] > String implementations:
        //  ByteArrayToHexString: "Byte Manipulation 2 (via CodesInChaos)"
        //  HexStringToByteArray: "Lookup/Shift (via Nathan Moinvaziri)"
        //   Note: Byte Manipulation didn't have a String>Byte impelemtnation so went with 2nd fastest "Lookup/Shift" for the reverse (not sure if these were tested though).
        //   Source: http://stackoverflow.com/a/624379
        private static string ByteArrayToHexString(byte[] bytes) {
            char[] c = new char[bytes.Length * 2];
            for (int i = 0, b; i < bytes.Length; i++) {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        }
        private static byte[] HexStringToByteArray(string Hex) {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 
               0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
               0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 | HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            return Bytes;
        }

        // Checks to see if the input string is all valid hex.
        private bool IsHex(IEnumerable<char> chars) {
            bool isHex;
            foreach (var c in chars) {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));
                if (!isHex)
                    return false;
            }
            return true;
        }
    }
}
