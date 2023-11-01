using Microsoft.AspNetCore.Mvc;
using Rebar.Controllers;
using RebarProject.DataAccess;
using RebarProject.ModelsDB;

namespace RebarProject.Controllers
{
    public class ShakeController : BaseController
    {
        readonly ShakeDataAccess _dataAccess;
        public ShakeController()
        {
            _dataAccess = new ShakeDataAccess();
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuShake>>> GetAll()
        {
            var result = await _dataAccess.GetAllShakes();
            if (result.Count == 0)
            {
                return await Task.FromResult(NoContent());
            }
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task PostShake(MenuShake shake)
        {
            await Task.FromResult(_dataAccess.CreateShake(shake));
        }
    }
}
