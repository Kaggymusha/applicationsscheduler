using System.Diagnostics;

namespace applicationsscheduler
{
    public partial class MainWindow : Form
    {
        private DateTime startTime;
        private DateTime endTime;
        private DateTime currentTime;
        private Process? process;
        private string? processPath;
        private string? friendlyProcessName;
        private int processKilled = 0;
        private object? selectedProcess;

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
            foreach (Process process in Process.GetProcesses())
            {
                string processName = process.ProcessName;
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
                //Process[] processes = Process.GetProcessesByName((string)selectedProcess);
                //processes[0].Kill();
                processListBox.SelectedItems.Remove(selectedProcess);
            }
        }

        private void processListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedProcessLabel.Text = processListBox.SelectedItem != null ? processListBox.SelectedItem.ToString() : "";
            selectedProcess = processListBox.SelectedItem;
        }
    }
}