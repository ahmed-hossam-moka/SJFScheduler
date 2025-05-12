namespace SJFSchedulerV1
{
    public class Process
    {
        public string Name { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int RemainingBurstTime { get; set; }
        public int CompletionTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int WaitingTime { get; set; }
        public int ResponseTime { get; set; }
        public bool HasStarted { get; set; }

        public Process(string name, int arrivalTime, int burstTime)
        {
            Name = name;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            RemainingBurstTime = burstTime;
            CompletionTime = 0;
            TurnaroundTime = 0;
            WaitingTime = 0;
            ResponseTime = -1;
            HasStarted = false;
        }

        public void CalculateMetrics()
        {
            TurnaroundTime = CompletionTime - ArrivalTime;
            WaitingTime = TurnaroundTime - BurstTime;
        }
    }
}