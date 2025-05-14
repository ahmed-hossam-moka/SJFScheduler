namespace SJFSchedulerV1
{
    public partial class Form1 : Form
    {
        private List<Process> processes = new List<Process>();
        private List<(string ProcessName, int StartTime, int EndTime)> ganttChart = new List<(string, int, int)>();

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            CreateAverageTimeLabels();
        }

 private void CreateAverageTimeLabels()
{
    lblAvgWaitingTime = new Label
    {
        Location = new Point(300, 10), // Position within panelButtons
        AutoSize = true,
        Text = "Average Waiting Time: ",
        Name = "lblAvgWaitingTime",
        Font = new Font(this.Font, FontStyle.Bold)
    };
    
    lblAvgTurnaroundTime = new Label
    {
        Location = new Point(300, 30),
        AutoSize = true,
        Text = "Average Turnaround Time: ",
        Name = "lblAvgTurnaroundTime",
        Font = new Font(this.Font, FontStyle.Bold)
    };
    
    lblAvgResponseTime = new Label
    {
        Location = new Point(300, 50),
        AutoSize = true,
        Text = "Average Response Time: ",
        Name = "lblAvgResponseTime",
        Font = new Font(this.Font, FontStyle.Bold)
    };
    
    // Add to panelButtons
    panelButtons.Controls.Add(lblAvgWaitingTime);
    panelButtons.Controls.Add(lblAvgTurnaroundTime);
    panelButtons.Controls.Add(lblAvgResponseTime);
    
    // Make panelButtons taller
    this.tableLayoutPanel1.RowStyles[2].Height = 130; // Was 40
}
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Add("Name", "Process Name");
            dataGridView1.Columns.Add("ArrivalTime", "Arrival Time");
            dataGridView1.Columns.Add("BurstTime", "Burst Time");
            dataGridView1.Columns.Add("WaitingTime", "Waiting Time");
            dataGridView1.Columns.Add("TurnaroundTime", "Turnaround Time");
            dataGridView1.Columns.Add("ResponseTime", "Response Time");
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string name = txtProcessName.Text;
            int arrivalTime = int.Parse(txtArrivalTime.Text);
            int burstTime = int.Parse(txtBurstTime.Text);

            Process process = new Process(name, arrivalTime, burstTime);
            processes.Add(process);

            // Add to DataGridView
            dataGridView1.Rows.Add(name, arrivalTime, burstTime, 0, 0, 0);

            // Clear inputs
            txtProcessName.Clear();
            txtArrivalTime.Clear();
            txtBurstTime.Clear();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProcessName.Text))
            {
                MessageBox.Show("Please enter a process name.");
                return false;
            }

            if (!int.TryParse(txtArrivalTime.Text, out int arrivalTime) || arrivalTime < 0)
            {
                MessageBox.Show("Please enter a valid non-negative arrival time.");
                return false;
            }

            if (!int.TryParse(txtBurstTime.Text, out int burstTime) || burstTime <= 0)
            {
                MessageBox.Show("Please enter a valid positive burst time.");
                return false;
            }

            return true;
        }

        private void btnRunScheduler_Click(object sender, EventArgs e)
        {
            if (processes.Count == 0)
            {
                MessageBox.Show("Please add at least one process.");
                return;
            }

            RunSJFScheduler();
            UpdateResults();
            DrawGanttChart();
        }

        private void RunSJFScheduler()
        {
            ganttChart.Clear();

            // Reset process states for new run
            foreach (var process in processes)
            {
                process.RemainingBurstTime = process.BurstTime;
                process.CompletionTime = 0;
                process.TurnaroundTime = 0;
                process.WaitingTime = 0;
                process.ResponseTime = -1;
                process.HasStarted = false;
            }

            var sortedProcesses = processes.OrderBy(p => p.ArrivalTime).ToList();
            int currentTime = 0;
            Process currentProcess = null;
            int processStartTime = 0;

            while (sortedProcesses.Any(p => p.RemainingBurstTime > 0))
            {
                // Find available processes at current time
                var availableProcesses = sortedProcesses
                    .Where(p => p.ArrivalTime <= currentTime && p.RemainingBurstTime > 0)
                    .OrderBy(p => p.RemainingBurstTime)
                    .ToList();

                if (availableProcesses.Any())
                {
                    var nextProcess = availableProcesses.First();

                    // If there's a context switch
                    if (currentProcess != null && currentProcess != nextProcess)
                    {
                        // Record the previous process's execution segment
                        ganttChart.Add((currentProcess.Name, processStartTime, currentTime));
                        processStartTime = currentTime;
                    }

                    // If no process was running before, set the start time
                    if (currentProcess == null)
                    {
                        processStartTime = currentTime;
                    }

                    currentProcess = nextProcess;

                    // Record response time if this is the first time the process runs
                    if (!currentProcess.HasStarted)
                    {
                        currentProcess.ResponseTime = currentTime - currentProcess.ArrivalTime;
                        currentProcess.HasStarted = true;
                    }

                    currentProcess.RemainingBurstTime--;
                    currentTime++;

                    if (currentProcess.RemainingBurstTime == 0)
                    {
                        currentProcess.CompletionTime = currentTime;
                        currentProcess.CalculateMetrics();
                        // Record the final segment for this process
                        ganttChart.Add((currentProcess.Name, processStartTime, currentTime));
                        currentProcess = null;
                    }
                }
                else
                {
                    // If CPU was idle, record the idle time if there was a process running before
                    if (currentProcess != null)
                    {
                        ganttChart.Add((currentProcess.Name, processStartTime, currentTime));
                        currentProcess = null;
                    }
                    currentTime++;
                }
            }
        }

        private void UpdateResults()
        {
            // Update DataGridView
            for (int i = 0; i < processes.Count; i++)
            {
                dataGridView1.Rows[i].Cells["WaitingTime"].Value = processes[i].WaitingTime;
                dataGridView1.Rows[i].Cells["TurnaroundTime"].Value = processes[i].TurnaroundTime;
                dataGridView1.Rows[i].Cells["ResponseTime"].Value = processes[i].ResponseTime;
            }
            DisplayAverageTimes();

        }

        private void DrawGanttChart(string selectedMetric = null)
        {
            panelGantt.Controls.Clear();

            if (!ganttChart.Any())
                return;

            int scale = 80; // pixels per time unit
            int height = 30;
            int y = 10;

            // Calculate the total width needed for the Gantt chart
            int maxTime = ganttChart.Max(s => s.EndTime);
            int totalGanttWidth = maxTime * scale;

            // Calculate the starting X position to center the Gantt chart
            int startX = (panelGantt.Width - totalGanttWidth) / 2;
            startX = Math.Max(startX, 10); // Ensure it doesn't go negative or too close to edge

            // Create a dictionary to store process metrics
            var processMetrics = new Dictionary<string, double>();
            foreach (var process in processes)
            {
                double metric = 0;
                if (selectedMetric != null)
                {
                    if (selectedMetric.Contains("Waiting"))
                        metric = process.WaitingTime;
                    else if (selectedMetric.Contains("Turnaround"))
                        metric = process.TurnaroundTime;
                    else if (selectedMetric.Contains("Response"))
                        metric = process.ResponseTime;
                }
                processMetrics[process.Name] = metric;
            }

            // Draw Gantt chart segments
            foreach (var segment in ganttChart)
            {
                Label lbl = new Label
                {
                    Text = segment.ProcessName,
                    BackColor = GetProcessColor(segment.ProcessName),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size((segment.EndTime - segment.StartTime) * scale, height),
                    Location = new Point(startX + (segment.StartTime * scale), y)
                };

                // Add tooltip with metric value if a metric is selected
                if (selectedMetric != null && processMetrics.ContainsKey(segment.ProcessName))
                {
                    lbl.Text = $"{segment.ProcessName}\n{processMetrics[segment.ProcessName]:F2}";
                }

                panelGantt.Controls.Add(lbl);
            }

            // Add time markers
            for (int i = 0; i <= maxTime; i++)
            {
                Label timeMarker = new Label
                {
                    Text = i.ToString(),
                    AutoSize = true,
                    Location = new Point(startX + (i * scale), y + height + 5)
                };
                panelGantt.Controls.Add(timeMarker);
            }
        }

        private Color GetProcessColor(string processName)
        {
            // Generate a consistent color for each process
            int hash = processName.GetHashCode();
            return Color.FromArgb(
                (hash & 0xFF0000) >> 16,
                (hash & 0x00FF00) >> 8,
                hash & 0x0000FF
            );
        }
        private void DisplayAverageTimes()
        {
            if (processes.Count == 0) return;

            double avgWaiting = processes.Average(p => p.WaitingTime);
            double avgTurnaround = processes.Average(p => p.TurnaroundTime);
            double avgResponse = processes.Average(p => p.ResponseTime);

            // Update the labels with the averages
            lblAvgWaitingTime.Text = $"Average Waiting Time: {avgWaiting:F2}";
            lblAvgTurnaroundTime.Text = $"Average Turnaround Time: {avgTurnaround:F2}";
            lblAvgResponseTime.Text = $"Average Response Time: {avgResponse:F2}";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            processes.Clear();
            dataGridView1.Rows.Clear();
            panelGantt.Controls.Clear();
            ganttChart.Clear();

            lblAvgWaitingTime.Text = "Average Waiting Time: ";
            lblAvgTurnaroundTime.Text = "Average Turnaround Time: ";
            lblAvgResponseTime.Text = "Average Response Time: ";
        }
    }
}
