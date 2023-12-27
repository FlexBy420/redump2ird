using IsoTools;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redump2IRD {
    internal class RedumpInteraction : EmptyInteraction {
        private readonly Timer progress_timer_ = null;
        private readonly ProgressBar progress_bar_ = null;
        private readonly TextBox output_ = null;
        private readonly MainMenu main_menu_ = null;
        private int progress_ = 0;

        public RedumpInteraction(ProgressBar progress_bar, TextBox output, MainMenu main_menu) {
            progress_bar_ = progress_bar;
            output_ = output;
            main_menu_ = main_menu;

            // Setup the progress timer.
            progress_timer_ = new Timer();
            progress_timer_.Interval = 200;
            progress_timer_.Tick += new EventHandler(ProgressTimerTick);
            progress_timer_.Start();
        }

        private string ird_output_inital_dir_ = String.Empty;
        public override Task<string> GetIrdOutputFile(string inputFile) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { InitialDirectory = ird_output_inital_dir_ }) {
				saveFileDialog.Title = "Select where to save the IRD file";
				saveFileDialog.Filter = "ISO Rebuild Data|*.ird";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    ird_output_inital_dir_ = Path.GetDirectoryName(saveFileDialog.FileName);
                    return TaskEx.FromResult<string>(saveFileDialog.FileName);
                }
			}
            return TaskEx.FromResult<string>(String.Empty);
        }

        private string iso_file_inital_dir_ = String.Empty;
        public override Task<string[]> GetIsoFile(bool verify = false, bool multiple = true) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { InitialDirectory = iso_file_inital_dir_ }) {
                openFileDialog.Title = "Select ISO file to create IRD file from";
				openFileDialog.Filter = "ISO Files|*.iso";
				openFileDialog.CheckFileExists = true;
				openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    iso_file_inital_dir_ = Path.GetDirectoryName(openFileDialog.FileName);
                    return TaskEx.FromResult<string[]>(openFileDialog.FileNames);
                }
			}
			return TaskEx.FromResult<string[]>(new string[] { String.Empty });
        }

        public override void ReportMessage(string message, ReportType reportType) {
            output_.Invoke((Action)(() => { output_.AppendText(message + "\r\n"); }));
        }

        public override void ReportProgress(int progress) {
            if (progress != -1)
                progress_ = progress;
        }

        public override void SetProgressMaximum(int max) {
            progress_bar_.Invoke((Action)(() => { progress_bar_.Maximum = max; }));
        }

		public override void TaskBegin(TaskType taskType) {
            if (main_menu_ != null)
                main_menu_.Invoke((Action)(() => main_menu_.ChangeState(false)));

            if (output_ != null)
                output_.Invoke((Action)(() => { output_.Text = String.Empty; }));
            progress_ = 0;
            if (progress_timer_ != null)
                progress_timer_.Start();
		}

        public override void TaskComplete() {
            if (progress_timer_ != null)
                progress_timer_.Stop();
            if (main_menu_ != null)
                main_menu_.Invoke((Action)(() => main_menu_.ChangeState(true)));
        }

        private void ProgressTimerTick(object sender, EventArgs e) {
            if (progress_bar_ != null)
                progress_bar_.Value = progress_;
        }
    }
}