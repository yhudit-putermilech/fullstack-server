//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LogController : ControllerBase
//    {
//        // GET: api/<LogController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<LogController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<LogController>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<LogController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<LogController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
//---------------------------------------------------------------------------------------------
using Api.Core.Models;
using Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        // פעולה לקבלת כל הלוגים
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetAll()
        {
            var logs = await _logService.GetAllAsync();
            return Ok(logs);
        }

        // פעולה לקבלת לוג לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetById(int id)
        {
            var log = await _logService.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // פעולה להוספת לוג חדש
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Log log)
        {
            if (log == null)
            {
                return BadRequest("Log data is required");
            }
            await _logService.AddValueAsync(log);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
        }

        // פעולה לעדכון לוג קיים
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Log log)
        {
            if (log == null || log.Id != id)
            {
                return BadRequest("Invalid log data");
            }
            await _logService.PutValueAsync(log);
            return NoContent();
        }

        // פעולה למחיקת לוג
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var log = await _logService.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            await _logService.DeleteAsync(log);
            return NoContent();
        }
    }
}