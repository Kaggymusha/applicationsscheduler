using System.Diagnostics;

namespace applicationsscheduler
{
    public partial class MainWindow : Form
    {
        private DateTime startTime;
        private DateTime endTime;
        private Process? process;
        private string? processPath;
        private int processKilled = 0;
        private object? selectedProcess;
        private int abort = 0;

        public MainWindow()
        {
            InitializeComponent();
            dateStart.CustomFormat = "yyyy-MM-dd HH:mm";
            dateEnd.CustomFormat = "yyyy-MM-dd HH:mm";

            UpdateProcessView();
            StartThreadMethods();
        }

        private void StartThreadMethods()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (currentTimeLabel.IsHandleCreated)
                    {
                        BeginInvoke(() => { currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss"); });
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private void UpdateProcessView(string? searchString = null)
        {
            string? query = searchString?.ToLower();
            foreach (Process p in Process.GetProcesses())
            {
                string processName = p.ProcessName;
                if (query == null)
                {
                    processListBox.Items.Add(processName);
                }
                else
                {
                    if (processName.ToLower().Contains(query))
                    {
                        processListBox.Items.Add(processName);
                    }
                }
            }
        }

        private void searchProcessBox_TextChanged(object sender, EventArgs e)
        {
            processListBox.Items.Clear();
            UpdateProcessView(searchProcessBox.Text);
        }

        private void killProcessBtn_Click(object sender, EventArgs e)
        {
            if (selectedProcess != null)
            {
                Process[] processes = Process.GetProcessesByName((string)selectedProcess);
                processes[0].Kill();
                processListBox.Items.Clear();
                Thread.Sleep(50);
                UpdateProcessView(searchProcessBox.Text);
            }
        }

        private void processListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedProcessLabel.Text = processListBox.SelectedItem != null ? processListBox.SelectedItem.ToString() : "";
            selectedProcess = processListBox.SelectedItem;
        }

        private void refreshProcessBtn_Click(object sender, EventArgs e)
        {
            processListBox.Items.Clear();
            UpdateProcessView(searchProcessBox.Text);
        }

        private void sleepButton_Click(object sender, EventArgs e)
        {
            if (sleepButton.Text == "Abort")
            {
                abort++;
            }
            else if (selectedProcess != null)
            {
                process = Process.GetProcessesByName((string)selectedProcess)[0];
                startTime = dateStart.Value;
                endTime = dateEnd.Value;
                processPath = process.MainModule.FileName.ToString();
                sleepTextBox.Text = $"The process '{(string)selectedProcess}' will be shut down between {startTime} and {endTime}";
                DialogResult dialog = MessageBox.Show("This will cause the selected process to be shut down in specified time interval. Continue?", "Notice", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    ToggleInteractables(false);
                    sleepButton.Text = "Abort";
                    Task.Factory.StartNew(() => CheckIfProcessIsAsleep());
                }
            }
            else
            {
                MessageBox.Show("Please select a process first.", "No process selected", MessageBoxButtons.OK);
            }
        }

        private void CheckIfProcessIsAsleep()
        {
            while (true)
            {
                if (abort == 1)
                {
                    abort--;
                    BeginInvoke(() =>
                    {
                        ToggleInteractables(true);
                        sleepButton.Text = "Sleep";
                        sleepTextBox.Text = "";
                    });
                    break;
                }
                if (DateTime.Compare(startTime, DateTime.Now) == -1 && process != null && processKilled == 0)
                {
                    process.Kill();
                    processListBox.Items.Clear();
                    Thread.Sleep(50);
                    UpdateProcessView(searchProcessBox.Text);
                    processKilled++;
                }
                if (DateTime.Compare(endTime, DateTime.Now) == -1 && process != null && processKilled == 1)
                {
                    processKilled++;
                    ProcessStartInfo start = new()
                    {
                        UseShellExecute = true,
                        FileName = processPath,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    };
                    using (Process proc = Process.Start(start))
                    {
                        BeginInvoke(() =>
                        {
                            ToggleInteractables(true);
                            sleepTextBox.Text = $"The process '{(string)selectedProcess}' was started at {endTime}";
                        });
                        break;
                    }
                }
            }
        }

        private void ToggleInteractables(bool state)
        {
            processListBox.Enabled = state;
            searchProcessBox.Enabled = state;
            killProcessBtn.Enabled = state;
            refreshProcessBtn.Enabled = state;
            dateStart.Enabled = state;
            dateEnd.Enabled = state;
        }
    }
}