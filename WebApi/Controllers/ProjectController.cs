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
                    .Select(p => new { p.IdProject, p.Title, p.Description })
                    .ToListAsync<object>();
            }
            else
            {
                result = await data.Users
                    .Where(u => u.IdUser == userId)
                    .Include(u => u.ProjectsNavigation)
                    //.SelectMany(u => u.ProjectsNavigation)
                    .Select(p => new {
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
    }
}
