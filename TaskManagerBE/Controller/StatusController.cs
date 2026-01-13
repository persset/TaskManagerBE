using Microsoft.AspNetCore.Mvc;
using TaskManagerBE.MapperBase;
using TaskManagerBE.Models;
using TaskManagerBE.Services;

namespace TaskManagerBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;
        private readonly IReadMapper<Status, StatusReadDTO> statusReadMapper =
            new StatusReadMapper();
        private readonly ICreateMapper<Status, StatusCreateDTO> statusCreateMapper =
            new StatusCreateMapper();
        private readonly IUpdateMapper<Status, StatusUpdateDTO> statusUpdateMapper =
            new StatusUpdateMapper();

        public StatusController(
            IStatusService statusService,
            IReadMapper<Status, StatusReadDTO> statusReadMapper,
            ICreateMapper<Status, StatusCreateDTO> statusCreateMapper,
            IUpdateMapper<Status, StatusUpdateDTO> statusUpdateMapper
        )
        {
            this.statusService = statusService;
            this.statusReadMapper = statusReadMapper;
            this.statusCreateMapper = statusCreateMapper;
            this.statusUpdateMapper = statusUpdateMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusReadDTO>>> GetAll()
        {
            var response = new List<StatusReadDTO>();

            response.AddRange(
                (await statusService.GetAll()).Select(status => statusReadMapper.ToDto(status))
            );
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusReadDTO>> GetSingle(int id)
        {
            var result = await statusService.GetSingle(id);

            if (result is null)
                return NotFound();

            var response = statusReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<StatusReadDTO>> Create(StatusCreateDTO statusCreateDTO)
        {
            var mappedStatus = statusCreateMapper.ToEntity(statusCreateDTO);

            var result = await statusService.Create(mappedStatus);

            var response = statusReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusReadDTO>> Update(
            int id,
            StatusUpdateDTO statusUpdateDTO
        )
        {
            var status = await statusService.GetSingle(id);

            if (status is null)
                return NotFound();

            statusUpdateMapper.MapToEntity(status, statusUpdateDTO);

            await statusService.Update(id, status);

            return Ok(statusReadMapper.ToDto(status));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusReadDTO>> Delete(int id)
        {
            var result = await statusService.Delete(id);

            if (result is null)
                return NotFound();

            return Ok(statusReadMapper.ToDto(result));
        }
    }
}
