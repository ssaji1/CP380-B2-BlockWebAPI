using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class PendingPayloads
    {
        public List<Payload> Payloads { get; set; }

        public PendingPayloads()
        {
            Payloads = new List<Payload>() { };
        }
        public void deletePending() 
        {
            Payloads.Clear();
        }
        // TODO
    }
}
