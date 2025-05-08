using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
using Api.Serveice;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public LogsController(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        // פעולה לקבלת כל הלוגים
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogPostModel>>> GetAll()
        {
            var logs = await _logService.GetAllAsync();
            var logsDto = _mapper.Map<IEnumerable<ILogDTO>>(logs);
            return Ok(logsDto);
        }
        // פעולה לקבלת לוג לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<LogPostModel>> GetById(int id)
        {
            var log = await _logService.GetByIdAsync(id);
            if (log == null) { return NotFound("משתמש לא נמצא"); }
            var logDtp = _mapper.Map<ILogDTO>(log);
            return Ok(logDtp);
        }
        // פעולה להוספת לוג חדש
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] LogPostModel log)
        {
            var logToAdd = _mapper.Map<Log>(log);
            await _logService.AddValueAsync(logToAdd);
            return Ok(logToAdd);

        }


        // פעולה לעדכון לוג קיים
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLogModel log)
        {
            var existingAlbum = await _logService.GetByIdAsync(id);
            if (existingAlbum != null)
            {
                existingAlbum.Action = log.Action;
                existingAlbum.Description = log.Description;
            }

            await _logService.PutValueAsync(existingAlbum);
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