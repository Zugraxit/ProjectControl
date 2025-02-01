using Microsoft.AspNetCore.Mvc;
using WebApi.Contexts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext data;

        public TaskController(DataContext context)
        {
            data = context;
        }

        [HttpPost("create")]
        public async void Create(int idProject, int idUser, string title)
        {
            data.Tasks.Add(new Models.TaskItem
            {
                IdProject = idProject,
                IdUser = idUser,
                Title = title
            });
            data.SaveChanges();
        }
    }
}
