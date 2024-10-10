using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SRTN
{
    public partial class Form1 : Form
    {
        public class Process
        {
            public string ProcessID { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int RemainingTime { get; set; }
            public int WaitingTime { get; set; }
            public int CompletionTime { get; set; }

            public Process(string id, int arrival, int burst)
            {
                ProcessID = id;
                ArrivalTime = arrival;
                BurstTime = burst;
                RemainingTime = burst;
                WaitingTime = 0;
                CompletionTime = 0;
            }
        }

        private List<Process> processes = new List<Process>();
        private Random rand = new Random();
        private int currentTime = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgv_process.Columns.Clear();
            dgv_process.Columns.Add("ProcessID", "Mã tiến trình");
            dgv_process.Columns.Add("ArrivalTime", "Thời gian đến");
            dgv_process.Columns.Add("BurstTime", "Thời gian thực thi");
            dgv_process.Columns.Add("WaitingTime", "Thời gian chờ");
            dgv_process.Columns.Add("CompletionTime", "Thời gian hoàn thành");
            dgv_process.AllowUserToAddRows = false;

            // Thiết lập các cột WaitingTime và CompletionTime là chỉ đọc
            dgv_process.Columns["WaitingTime"].ReadOnly = true;
            dgv_process.Columns["CompletionTime"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy số lượng tiến trình từ ComboBox
            int numProcesses = Convert.ToInt32(comboBox1.SelectedItem);
            processes.Clear();
            dgv_process.Rows.Clear();

            for (int i = 0; i < numProcesses; i++)
            {
                string processId = "P" + (i + 1);
                int arrivalTime = rand.Next(0, 10);
                int burstTime = rand.Next(1, 10);
                Process process = new Process(processId, arrivalTime, burstTime);
                processes.Add(process);
                dgv_process.Rows.Add(processId, arrivalTime, burstTime, "", ""); // Thêm các ô trống cho thời gian chờ và hoàn thành
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Reset thông tin các tiến trình
            foreach (var process in processes)
            {
                process.WaitingTime = 0;
                process.CompletionTime = 0;
                process.RemainingTime = process.BurstTime; // Reset RemainingTime
            }

            List<Process> completedProcesses = new List<Process>();
            currentTime = 0; // Reset currentTime

            while (processes.Any(p => p.CompletionTime == 0))
            {
                // Lọc các tiến trình đã đến
                var readyProcesses = processes.Where(p => p.ArrivalTime <= currentTime && p.CompletionTime == 0).ToList();

                if (readyProcesses.Count > 0)
                {
                    // Chọn tiến trình có thời gian còn lại ngắn nhất
                    Process currentProcess = readyProcesses.OrderBy(p => p.RemainingTime).First();

                    // Thực hiện một đơn vị thời gian
                    currentProcess.RemainingTime--;
                    currentTime++;

                    // Cập nhật thời gian chờ cho các tiến trình khác
                    foreach (var process in readyProcesses)
                    {
                        if (process != currentProcess)
                        {
                            process.WaitingTime++;
                        }
                    }

                    // Nếu tiến trình hoàn thành
                    if (currentProcess.RemainingTime == 0)
                    {
                        currentProcess.CompletionTime = currentTime;
                        completedProcesses.Add(currentProcess);
                    }
                }
                else
                {
                    currentTime++; // Nếu không có tiến trình nào đến, tăng thời gian
                }
            }

            // Cập nhật DataGridView với kết quả
            for (int i = 0; i < completedProcesses.Count; i++)
            {
                var process = completedProcesses[i];
                int rowIndex = processes.FindIndex(p => p.ProcessID == process.ProcessID);
                dgv_process.Rows[rowIndex].Cells["WaitingTime"].Value = process.WaitingTime;
                dgv_process.Rows[rowIndex].Cells["CompletionTime"].Value = process.CompletionTime;
            }

            // Kiểm tra nếu completedProcesses không rỗng trước khi tính thời gian chờ trung bình
            if (completedProcesses.Count > 0)
            {
                double averageWaitingTime = completedProcesses.Average(p => p.WaitingTime);
                MessageBox.Show("Thời gian chờ trung bình: " + averageWaitingTime);
            }
            else
            {
                MessageBox.Show("Không có tiến trình nào hoàn thành.");
            }
        }

    }
}
