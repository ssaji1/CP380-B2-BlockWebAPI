using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace CP380_B2_BlockWebAPI.Services
{
    public class BlockListService
    {
        private PendingPayloads _payloads;
        private BlockList _blockList;
        private readonly IConfiguration _IConfiguration;

        public BlockListService(IConfiguration configuration, BlockList blockList, PendingPayloads pendingPayloads)
        {
            _blockList = blockList;
            _payloads = pendingPayloads;
            _IConfiguration = configuration;
        }
        public Block SubmitNewBlock(string hash, int nonce, DateTime timestamp)
        {

            Block block = new(timestamp, _blockList.Chain[_blockList.Chain.Count - 1].Hash, _payloads.Payloads);
            block.CalculateHash(); 

            if (block.Hash == hash)
            {
                _blockList.Chain.Add(block);  
                _payloads.deletePending(); 
                return block;
            }

            return null; 
        }
    }
}