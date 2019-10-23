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
            Queue<Process> ProQue = new Queue<Process>();
            Process[] processes = new Process[4];
         
            processes[0] = new Process()
            {
                ProcessId = "p0",
                ArrivalTime = 0,
                Burstime = 4

            };
            processes[1] = new Process()
            {
                ProcessId = "p1",
                ArrivalTime = 0,
                Burstime = 1

            };
            processes[2] = new Process()
            {
                ProcessId = "p2",
                ArrivalTime = 0,
                Burstime = 5

            };
            processes[3] = new Process()
            {
                ProcessId = "p3",
                ArrivalTime = 0,
                Burstime = 3

            };

            foreach (Process x in processes)
            {
                Console.WriteLine("Process Id={0} Arrival Time={1} Bustime={2}", x.ProcessId, x.ArrivalTime, x.Burstime);
            }

            Console.WriteLine("================================");
            StartProcessing(processes,ProQue);
            Console.WriteLine();
            Console.WriteLine("===Avg Waiting Time===");
            Console.WriteLine(AverageWaitingTime(ProQue.ToArray()));
            Console.WriteLine("===Avg TurnAround Time===");
            Console.WriteLine(AverageTurnAroundTime(ProQue.ToArray()));



        }

        static void StartProcessing(Process[] processes,Queue<Process>ProQue)
        {
            int CurrentTime = 0;
            Process pro = null;
            for (int i = 0; i < processes.Length; i++)
            {

                if (i == 0)
                {
                    pro = GetProcess(processes, CurrentTime);
                    pro.TurnAroundTime = CurrentTime + pro.Burstime;
                    CurrentTime = pro.TurnAroundTime;
                    ProQue.Enqueue(pro);
                    Console.Write("{0}-[{1}]-{2}", pro.ArrivalTime, pro.ProcessId, pro.Burstime);
                }
                else
                {
                    pro = GetProcess(processes, CurrentTime);
                    pro.TurnAroundTime = CurrentTime + pro.Burstime;
                    CurrentTime = pro.TurnAroundTime;
                    ProQue.Enqueue(pro);
                    Console.Write("-[{0}]-{1}", pro.ProcessId, pro.TurnAroundTime);
                    
                    pro = null;
                    
                }
            }
        }
        public static Process GetProcess(Process[] processes, int CurrentTime)
        {
            Process pro = null;
            foreach (Process x in processes)
            {
                if (pro == null)
                {
                    if (x.IsProcessed == false && x.ArrivalTime <= CurrentTime)
                    {
                        pro = x;
                    }
                }
                else
                {
                    if (x.IsProcessed == false && x.ArrivalTime <= CurrentTime && pro.Burstime > x.Burstime)
                    {
                        pro = x;
                    }
                }

            }
            pro.IsProcessed = true;
            return pro;
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
     
    }
}
