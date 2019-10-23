using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShedulingAlgo
{
    class Process
    {
        public string ProcessId { get; set; }
        public int ArrivalTime { get; set; }
        public int Burstime { get; set; }
        public int TurnAroundTime { get; set; }
        public bool IsProcessed { get; set; }
    }
}
