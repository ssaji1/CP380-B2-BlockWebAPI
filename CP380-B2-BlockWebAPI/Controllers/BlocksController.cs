using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockList list_block;

        public BlocksController(BlockList blockList)
        {
            list_block = blockList;
        }


        [HttpGet("/Blocks")]
        public ActionResult<List<BlockSummary>> Get()
        {
            List<Block> blockslist = list_block.Chain.ToList();


            List<BlockSummary> blockSummaryList = new List<BlockSummary>();
            foreach (var block in blockslist)
            {
                list_block.AddBlock(block);
                blockSummaryList.Add(new BlockSummary()
                {
                    Hash = block.Hash,
                    PreviousHash = block.PreviousHash,
                    TimeStamp = block.TimeStamp,
                });
            }
            var listsummary = blockSummaryList;
            return listsummary;

        }


        [HttpGet("/blockslist/{hash}")]
        public ActionResult<Block> Get(string hash)
        {
            var block = list_block.Chain.Where(tempBlock => tempBlock.Hash == hash);
            int count = block.Count();
            if (count > 0)
            {
                return block.First();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/blockslist/{hash}/Payloads")]
        public ActionResult<List<Payload>> GetPayload(string hash)
        {
            var block = list_block.Chain.Where(tempBlock => tempBlock.Hash == hash);
            int count = block.Count();
            if (count > 0)
            {
                var firstValue= block.Select(value => value.Data).First().ToList();
                return firstValue;
                
             }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public void PostBlock(Block block)
        {
            string hash = block.Hash;
            if (hash != list_block.Chain[list_block.Chain.Count - 1].PreviousHash)
            {
                BadRequestResult badRequestResult = BadRequest();
                _ = badRequestResult;
            }
            else
            {
                NewMethod(block);
            }
        }

        private void NewMethod(Block block)
        {
            list_block.Chain.Add(block);
        }

        // TODO
    }
}
