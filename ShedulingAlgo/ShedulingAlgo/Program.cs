using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulingAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = new Process[4];
            processes[0] = new Process()
            {
                ProcessId = "p1",
                ArrivalTime = 0,
                Bustime = 4

            };
            processes[1] = new Process()
            {
                ProcessId = "p2",
                ArrivalTime = 0,
                Bustime = 1

            };
            processes[2] = new Process()
            {
                ProcessId = "p3",
                ArrivalTime = 2,
                Bustime = 5

            };
            processes[3] = new Process()
            {
                ProcessId = "p4",
                ArrivalTime = 2,
                Bustime = 3

            };

            SortProcess(processes);
            Console.WriteLine("===Sorted Process===");
            foreach (Process x in processes)
            {
                Console.WriteLine("Process Id={0} Arrival Time={1} Bustime={2}", x.ProcessId, x.ArrivalTime, x.Bustime);
            }

            Console.WriteLine("================================");
            StartProcessing(processes);
            Console.WriteLine();
            Console.WriteLine("===Avg Waiting Time===");
            Console.WriteLine(AverageWaitingTime(processes));
            Console.WriteLine("===Avg TurnAround Time===");
            Console.WriteLine(AverageTurnAroundTime(processes));



        }

        static void StartProcessing(Process[] processes)
        {
            for (int i = 0; i < processes.Length; i++)
            {
                if (i == 0)
                {
                    processes[i].TurnAroundTime = processes[i].Bustime;
                    Console.Write("{0}-[{1}]-{2}", processes[i].ArrivalTime, processes[i].ProcessId, processes[i].Bustime);
                }
                else
                {
                    processes[i].TurnAroundTime = processes[i - 1].TurnAroundTime + processes[i].Bustime;
                    Console.Write("-[{0}]-{1}", processes[i].ProcessId, processes[i].TurnAroundTime);
                }
            }
        }
        static double AverageWaitingTime(Process[] process)
        {
            int AverageTime = 0;
            for (int i = 1; i < process.Length; i++)
            {
                AverageTime += process[i - 1].TurnAroundTime;
            }
            return (double)AverageTime / process.Length;
        }
        static double AverageTurnAroundTime(Process[] process)
        {
            int AverageTime = 0;
            for (int i = 0; i < process.Length; i++)
            {
                AverageTime += process[i].TurnAroundTime;
            }
            return (double)AverageTime / process.Length;
        }
        static void SortProcess(Process[] processes)
        {
            int start = 0;
            int end = 0;
            bool IsSameArrival = false;
            for (int i = 0; i < processes.Length; i++)
            {
                if (i + 1 < processes.Length && processes[i].ArrivalTime == processes[i + 1].ArrivalTime)
                {
                    if (IsSameArrival == false)
                    {
                        start = i;
                        IsSameArrival = true;
                    }


                }
                else if (IsSameArrival)
                {
                    end = i;
                    InsertionSort(processes, start, end);
                    end = 0;
                    start = 0;
                    IsSameArrival = false;
                }
                if (i == processes.Length && IsSameArrival)
                {
                    end = i;
                    InsertionSort(processes, start, end);
                    end = 0;
                    start = 0;
                    IsSameArrival = false;
                }
            }
        }
        static void InsertionSort(Process[] arr, int start, int End)
        {
            for (int i = start + 1; i <= End; i++)
            {
                Process temp = arr[i];
                int j = i;
                while (j > start && arr[j - 1].Bustime > temp.Bustime)
                {
                    arr[j] = arr[j - 1];
                    j -= 1;
                }
                arr[j] = temp;
            }

        }
    }
}
