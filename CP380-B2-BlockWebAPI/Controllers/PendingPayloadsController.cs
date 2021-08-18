using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;
using CP380_B1_BlockList.Models;


namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private readonly PendingPayloads pendingpayloadlist;
        public List<PendingPayloads> PendingPayloadsList { get; set; }

        public PendingPayloadsController(PendingPayloads pendingPayloads)
        {
            pendingpayloadlist = pendingPayloads;
        }

        [HttpGet("/PenidngPayloads")]
        public ActionResult<List<Payload>> Get()
        {
            var value = pendingpayloadlist.Payloads.ToList();
            return value;
        }


        [HttpPost("/PendingPayloads")]
        public void Post(Payload payload)
        {
            pendingpayloadlist.Payloads.Add(payload);

        }
        // TODO
    }
}
