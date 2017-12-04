using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReactDemo3.Controllers
{
    [Route("api/[controller]")]
    public class RefPageController : Controller
    {
        [HttpGet("[action]/{operationId}")]
        public Operation ReferencePath(string operationId)
        {
            Operation op = new Operation()
            {
                operation_id = operationId,
                name = "Get Envelopes",
                summary = "Gets me some envelopes",
                http_method = "Get"
            };
            return op;
        }
    }

    public class Operation
    {
        public string operation_id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string http_method { get; set; }
    }
}