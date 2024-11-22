import tkinter as tk
from tkinter import messagebox
import random
from tkinter import ttk
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg

class Process:
    def __init__(self, pid, arrival_time, burst_time):
        self.pid = pid
        self.arrival_time = arrival_time
        self.burst_time = burst_time
        self.remaining_time = burst_time
        self.completion_time = 0
        self.turnaround_time = 0
        self.waiting_time = 0

def srtn_scheduling(processes):
    current_time = 0
    completed = 0
    n = len(processes)
    
    timeline = []  # This will hold tuples of (start_time, end_time, pid)

    while completed != n:
        shortest_process = None
        for process in processes:
            if (process.arrival_time <= current_time and 
                process.remaining_time > 0 and
                (shortest_process is None or process.remaining_time < shortest_process.remaining_time)):
                shortest_process = process

        if shortest_process is None:
            current_time += 1
            continue

        # Record the timeline of the process
        start_time = current_time
        shortest_process.remaining_time -= 1
        current_time += 1
        end_time = current_time
        timeline.append((start_time, end_time, shortest_process.pid))

        if shortest_process.remaining_time == 0:
            completed += 1
            shortest_process.completion_time = current_time
            shortest_process.turnaround_time = shortest_process.completion_time - shortest_process.arrival_time
            shortest_process.waiting_time = shortest_process.turnaround_time - shortest_process.burst_time

    results = [(p.pid, p.arrival_time, p.burst_time, p.completion_time, p.turnaround_time, p.waiting_time) for p in processes]
    avg_waiting_time = sum(p.waiting_time for p in processes) / n
    avg_turnaround_time = sum(p.turnaround_time for p in processes) / n
    return results, avg_waiting_time, avg_turnaround_time, timeline

class SRTNGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("SRTN - Ứng dụng lập lịch")

        self.num_processes_label = tk.Label(root, text="Chọn số lượng tiến trình (2-5):")
        self.num_processes_label.grid(row=0, column=0, padx=10, pady=10)

        self.num_processes_var = tk.IntVar(value=2)
        self.num_processes_menu = tk.OptionMenu(root, self.num_processes_var, *range(2, 6), command=self.create_process_inputs)
        self.num_processes_menu.grid(row=0, column=1, padx=10, pady=10)

        self.process_entries = []
        self.create_process_inputs(2)

        self.calculate_button = tk.Button(root, text="Tính toán", command=self.calculate)
        self.calculate_button.grid(row=7, column=0, pady=10)

        self.random_button = tk.Button(root, text="Ngẫu nhiên", command=self.randomize_inputs)
        self.random_button.grid(row=7, column=1, pady=10)

        self.result_frame = ttk.Frame(root)
        self.result_frame.grid(row=8, column=0, columnspan=2, padx=10, pady=10)

    def create_process_inputs(self, num_processes):
        for entry_row in self.process_entries:
            for entry in entry_row:
                entry.grid_forget()

        self.process_entries = []
        for i in range(num_processes):
            arrival_label = tk.Label(self.root, text=f"T.gian đến của P{i+1}:")
            burst_label = tk.Label(self.root, text=f"T.gian thực thi của P{i+1}:")
            arrival_entry = tk.Entry(self.root)
            burst_entry = tk.Entry(self.root)

            arrival_label.grid(row=i+1, column=0, padx=5, pady=5)
            burst_label.grid(row=i+1, column=2, padx=5, pady=5)
            arrival_entry.grid(row=i+1, column=1, padx=5, pady=5)
            burst_entry.grid(row=i+1, column=3, padx=5, pady=5)

            self.process_entries.append((arrival_entry, burst_entry))

    def randomize_inputs(self):
        try:
            num_processes = self.num_processes_var.get()
            previous_arrival = 0

            for i, (arrival_entry, burst_entry) in enumerate(self.process_entries):
                arrival_time = random.randint(previous_arrival, previous_arrival + 3)
                previous_arrival = arrival_time
                burst_time = random.randint(1, 10)

                arrival_entry.delete(0, tk.END)
                arrival_entry.insert(0, str(arrival_time))

                burst_entry.delete(0, tk.END)
                burst_entry.insert(0, str(burst_time))
        
        except Exception as e:
            messagebox.showerror("Randomization Error", f"Error during randomization: {e}")

    def calculate(self):
        try:
            processes = []
            for i, (arrival_entry, burst_entry) in enumerate(self.process_entries):
                arrival_time = int(arrival_entry.get())
                burst_time = int(burst_entry.get())
                processes.append(Process(pid=i+1, arrival_time=arrival_time, burst_time=burst_time))

            results, avg_waiting_time, avg_turnaround_time, timeline = srtn_scheduling(processes)

            for widget in self.result_frame.winfo_children():
                widget.grid_forget()

            headers = ["Tiến trình", "T.gian đến", "T.gian thực thi", "T.gian hoàn thành", "TG lưu lại HT", "T.gian chờ"]
            for col, header in enumerate(headers):
                label = tk.Label(self.result_frame, text=header, font=('Arial', 10, 'bold'), relief='solid', width=15)
                label.grid(row=0, column=col, padx=5, pady=5)

            for row, (pid, arrival_time, burst_time, finish_time, turnaround_time, waiting_time) in enumerate(results, start=1):
                data = [f"P{pid}", arrival_time, burst_time, finish_time, turnaround_time, waiting_time]
                for col, value in enumerate(data):
                    label = tk.Label(self.result_frame, text=value, relief='solid', width=15)
                    label.grid(row=row, column=col, padx=5, pady=5)

            avg_row = len(results) + 1
            avg_waiting_time_label = tk.Label(self.result_frame, text=f"Thời gian chờ trung bình: {avg_waiting_time:.2f}", font=('Arial', 10, 'bold'))
            avg_turnaround_time_label = tk.Label(self.result_frame, text=f"Thời gian lưu lại h.thống trung bình: {avg_turnaround_time:.2f}", font=('Arial', 10, 'bold'))

            avg_waiting_time_label.grid(row=avg_row, column=0, columnspan=3, pady=10)
            avg_turnaround_time_label.grid(row=avg_row, column=3, columnspan=3, pady=10)

            self.plot_gantt_chart(timeline)

        except ValueError:
            messagebox.showerror("Input Error", "Please enter valid integer values for arrival and burst times.")

    def plot_gantt_chart(self, timeline):
        fig, ax = plt.subplots(figsize=(10, 2))

        # Danh sách màu sắc để mỗi tiến trình có màu riêng biệt
        colors = ['skyblue', 'lightgreen', 'salmon', 'orange', 'purple']  # Bạn có thể thêm màu vào đây
        process_colors = {}  # Lưu màu sắc cho mỗi tiến trình

        # Gán màu cho mỗi tiến trình trong timeline
        for start_time, end_time, pid in timeline:
            if pid not in process_colors:
                process_colors[pid] = colors[len(process_colors) % len(colors)]  # Gán màu cho tiến trình mới

            # Vẽ thanh tiến trình với màu đã chọn
            ax.barh(pid, end_time - start_time, left=start_time, height=0.5, color=process_colors[pid])

        # Cải thiện độ phân giải của trục thời gian
        ax.set_xticks(range(int(timeline[0][0]), int(timeline[-1][1]) + 1))  # Đặt các tick trục x chi tiết hơn
        ax.set_xticklabels([str(i) for i in range(int(timeline[0][0]), int(timeline[-1][1]) + 1)])  # Đặt nhãn chi tiết

        ax.set_xlabel('Thời gian')
        ax.set_ylabel('Tiến trình')
        ax.set_title('Biểu đồ Gantt - Lập lịch SRTN')

        # Show the chart in Tkinter
        canvas = FigureCanvasTkAgg(fig, master=self.root)
        canvas.get_tk_widget().grid(row=9, column=0, columnspan=2)
        canvas.draw()



root = tk.Tk()
app = SRTNGUI(root)
root.mainloop()
