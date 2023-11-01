using MongoDB.Driver;
using RebarProject.ModelsDB;

namespace RebarProject.DataAccess
{
    public class DailyReportDataAccess : DataAccess
    {
        private const string DailyReportCollection = "dailyReport";

        public async Task<List<DailyReport>> GetDailyReports()
        {
            var dailyReportCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
            var results = await dailyReportCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public Task CreateDailyReport(DailyReport dailyReport)
        {
            var dailyReportCollection = ConnectToMongo<DailyReport>(DailyReportCollection);
            return dailyReportCollection.InsertOneAsync(dailyReport);
        }
    }
}
