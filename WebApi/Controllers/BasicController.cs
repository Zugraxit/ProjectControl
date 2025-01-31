using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Utils;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicController : ControllerBase
    {
        private readonly DataContext data;

        public BasicController(DataContext context)
        {
            data = context;
        }

        [HttpGet("Auth")]
        public async Task<object> Login(string login, string password)
        {
            return await data.Users.Where(u => u.Password == EncriptHelper.ConvertToSHA256(password)
            && u.Login == login).Select(u => new { u.IdUser, u.Login, u.Name, u.ImagePath }).FirstOrDefaultAsync();
        }

        [HttpPost("reg")]
        public async Task<ActionResult> Registration(string login, string password, string name)
        {
            await data.Users.AddAsync(new Models.User
            {
                Login = login,
                Password = EncriptHelper.ConvertToSHA256(password),
                Name = name
            }
            );
            data.SaveChanges();
            return Ok();
        }
    }
}
