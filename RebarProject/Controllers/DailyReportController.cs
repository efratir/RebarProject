using Microsoft.AspNetCore.Mvc;
using Rebar.Controllers;
using RebarProject.DataAccess;
using RebarProject.ModelsDB;

namespace RebarProject.Controllers
{
    public class DailyReportController : BaseController
    {
        readonly DailyReportDataAccess _dailyReportDataAccess;
        public DailyReportController()
        {
            _dailyReportDataAccess = new DailyReportDataAccess();
        }

        [HttpGet]
        public async Task<ActionResult<List<DailyReport>>> GetAll()
        {
            var result = await _dailyReportDataAccess.GetDailyReports();
            if (result.Count == 0)
            {
                return await Task.FromResult(NoContent());
            }
            return await Task.FromResult(result);
        }
    }
}
