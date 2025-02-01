using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext data;

        public ProjectController(DataContext context)
        {
            data = context;
        }

        [HttpGet("all/{userId}")]
        public async Task<List<object>> GetProgectsByUser(int userId, bool isAdmin)
        {
            List<object> result = new List<object>();
            if (isAdmin)
            {
                result = await data.Projects
                    .Where(p => p.IdAdmin == userId)
                    .Include(p => p.AdminNavigation)
                    .Select(p => new { p.IdProject, p.Title, p.Description })
                    .ToListAsync<object>();
            }
            else
            {
                result = await data.Users
                    .Where(u => u.IdUser == userId)
                    .Include(u => u.ProjectsNavigation)                    
                    .Select(p => new
                    {
                        p.Name,
                        Projects = p.Projects
                            .Select(p => new { p.IdProject, p.Title, p.Description }).ToList<object>()
                    })
                    .ToListAsync<object>();
            }
            return result;
        }

        [HttpPost("create")]
        public async void Create(int idAdmin, string title, string description)
        {
            data.Projects.Add(new Models.Project
            {
                IdAdmin = idAdmin,
                Title = title,
                Description = description
            });
            data.SaveChanges();
        }

        [HttpGet("getTasks")]
        public async Task<object> GetTasks(int idProject) 
        {
            return await data.Projects
                .Include(p => p.Tasks)
                .Where(p => p.IdProject == idProject)
                .Select(p => p.Tasks)
                .ToListAsync<object>();
        }

        [HttpPut("inviteUser")]
        public async void InviteUser(int idProject, int idUser)
        {
            try
            {
                data.Projects.Include(u => u.Users)
                    .Where(p => p.IdProject == idProject)
                    .FirstOrDefault().Users
                        .Add(data.Users
                            .Where(u => u.IdUser == idUser)
                            .FirstOrDefault()
                            );
                await data.SaveChangesAsync();

            }
            catch (Exception)
            {
                Console.WriteLine("Приглашение не работает");
            }
        }
    }
}
