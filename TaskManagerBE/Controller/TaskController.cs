using Microsoft.AspNetCore.Mvc;
using TaskManagerBE.MapperBase;
using TaskManagerBE.Models;
using TaskManagerBE.Services;

namespace TaskManagerBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IReadMapper<Models.Task, TaskReadDTO> taskReadMapper =
            new TaskReadMapper();
        private readonly ICreateMapper<Models.Task, TaskCreateDTO> taskCreateMapper =
            new TaskCreateMapper();
        private readonly IUpdateMapper<Models.Task, TaskUpdateDTO> taskUpdateMapper =
            new TaskUpdateMapper();

        public TaskController(
            ITaskService taskService,
            IReadMapper<Models.Task, TaskReadDTO> taskReadMapper,
            ICreateMapper<Models.Task, TaskCreateDTO> taskCreateMapper,
            IUpdateMapper<Models.Task, TaskUpdateDTO> taskUpdateMapper
        )
        {
            this.taskService = taskService;
            this.taskReadMapper = taskReadMapper;
            this.taskCreateMapper = taskCreateMapper;
            this.taskUpdateMapper = taskUpdateMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskReadDTO>>> GetAll()
        {
            var response = new List<TaskReadDTO>();

            response.AddRange(
                (await taskService.GetAll()).Select(task => taskReadMapper.ToDto(task))
            );
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskReadDTO>> GetSingle(int id)
        {
            var result = await taskService.GetSingle(id);

            if (result is null)
                return NotFound();

            var response = taskReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TaskReadDTO>> Create(TaskCreateDTO taskCreateDTO)
        {
            var mappedTask = taskCreateMapper.ToEntity(taskCreateDTO);

            var result = await taskService.Create(mappedTask);

            var response = taskReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskReadDTO>> Update(int id, TaskUpdateDTO taskUpdateDTO)
        {
            var task = await taskService.GetSingle(id);

            if (task is null)
                return NotFound();

            taskUpdateMapper.MapToEntity(task, taskUpdateDTO);

            var result = await taskService.Update(id, task);

            if (result is null)
                return NotFound();

            var response = taskReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskReadDTO>> Delete(int id)
        {
            var result = await taskService.Delete(id);

            if (result is null)
                return NotFound();

            var response = taskReadMapper.ToDto(result);

            return Ok(response);
        }
    }
}
