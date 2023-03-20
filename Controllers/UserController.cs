using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auth.Models;
using Auth.Utils;

namespace Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UserController(ILogger<UserController> logger, DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<UserInfo> GetAllUsers() => _context.getUsers();

        [HttpPost]
        public async Task<ActionResult<UserInfo>> CreateUserInfo(UserInfo st)
        {
            st.Password = Hashcode.getHashCode(st.Password!);
            System.Console.WriteLine(st.Password);
            _context.UserInfos!.Add(st);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllUsers), st);
        }

    }

}