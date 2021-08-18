using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class BlockSummary
    {
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public BlockSummary()
        {
            List<Payload> item = new()
            {
                new Payload("user", TransactionTypes.GRANT, 10, null),
                new Payload("user", TransactionTypes.BUY, 20, "20C"),
            };
            var blockvalue = new Block(DateTime.Now, "", item);
            blockvalue.Mine(2);

            TimeStamp = blockvalue.TimeStamp;
            PreviousHash = blockvalue.PreviousHash;
            Hash = blockvalue.Hash;
        }
        // TODO
    }
}
