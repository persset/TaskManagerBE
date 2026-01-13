using Microsoft.AspNetCore.Mvc;
using TaskManagerBE.MapperBase;
using TaskManagerBE.Models;
using TaskManagerBE.Services;

namespace TaskManagerBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IReadMapper<User, UserReadDTO> userReadMapper = new UserReadMapper();
        private readonly ICreateMapper<User, UserCreateDTO> userCreateMapper =
            new UserCreateMapper();
        private readonly IUpdateMapper<User, UserUpdateDTO> userUpdateMapper =
            new UserUpdateMapper();

        public UserController(
            IUserService userService,
            IReadMapper<User, UserReadDTO> userReadMapper,
            ICreateMapper<User, UserCreateDTO> userCreateMapper,
            IUpdateMapper<User, UserUpdateDTO> UserUpdateMapper
        )
        {
            this.userService = userService;
            this.userReadMapper = userReadMapper;
            this.userCreateMapper = userCreateMapper;
            this.userUpdateMapper = UserUpdateMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetAll()
        {
            var response = new List<UserReadDTO>();

            response.AddRange(
                (await userService.GetAll()).Select(user => userReadMapper.ToDto(user))
            );
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetSingle(int id)
        {
            var result = await userService.GetSingle(id);

            if (result is null)
                return NotFound();

            var response = userReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> Create(UserCreateDTO userCreateDTO)
        {
            var mappedUser = userCreateMapper.ToEntity(userCreateDTO);

            var result = await userService.Create(mappedUser);

            var response = userReadMapper.ToDto(result);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDTO>> Update(int id, UserUpdateDTO userUpdateDTO)
        {
            var user = await userService.GetSingle(id);

            if (user is null)
                return NotFound();

            userUpdateMapper.MapToEntity(user, userUpdateDTO);

            await userService.Update(id, user);

            return Ok(userReadMapper.ToDto(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserReadDTO>> Delete(int id)
        {
            var result = await userService.Delete(id);

            if (result == null)
                return NotFound();

            return Ok(userReadMapper.ToDto(result));
        }
    }
}
