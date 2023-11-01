using RebarProject.DataAccess;
using RebarProject.ModelsDB;

namespace RebarProject.Models
{
    public class ManageOrder
    {
        private string password = "1111";
        public Menu Menu { get; set; }
        public List<Account> accounts { get; set; }

        public ManageOrder()
        {
            InilializeAccounts();
        }

        public async void InilializeAccounts()
        {
            AccountDataAccess db = new AccountDataAccess();
            accounts = await db.GetAccounts();
        }

        public bool TakeOrder(List<OrderShake> orderedShakes, List<Discount> discounts, string customerName)
        {
            if (orderedShakes.Count > 9 || customerName == null)
            {
                return false;
            }
            decimal sumOfPrices = 0, discount = 0;
            orderedShakes.ForEach(shake => sumOfPrices += shake.Price);
            discounts.ForEach(d => discount += d.Percent);
            sumOfPrices = sumOfPrices * (1 - discount);

            Order order = new Order(customerName, orderedShakes, sumOfPrices);
            OrderDB orderDB = new OrderDB(order);
            AccountDataAccess accountdb = new AccountDataAccess();
            Account? account = accounts.Find(x => x.CustomerName == customerName);
            if (account != null)
            {
                account.Orders.Add(order);
                accountdb.UpdateAccount(account);
            }
            else
            {
                account = new Account();
                account.Orders.Add(order);
                accountdb.CreateAccount(account);
            }
            InilializeAccounts();
            OrderDBDataAccess orderdb = new OrderDBDataAccess();
            orderdb.CreateOrder(orderDB);
            return true;
        }


        public async Task<DailyReport?> CloseCashRegister(string password)
        {
            if (!this.password.Equals(password))
            {
                return null;
            }
            int numOfOrdersToday = 0;
            decimal dailyProfit = 0;
            OrderDBDataAccess orderdb = new OrderDBDataAccess();
            var todaysOrders = await orderdb.GetTodaysOrders();
            numOfOrdersToday = todaysOrders.Count();
            todaysOrders.ForEach(o => dailyProfit += o.SumOfPrices);
            DailyReport dailyReport = new DailyReport() { DailyProfit = dailyProfit, NumOfOrdersToday = numOfOrdersToday };
            DailyReportDataAccess dailyReportdb = new DailyReportDataAccess();
            await dailyReportdb.CreateDailyReport(dailyReport);
            return dailyReport;
        }
    }
}
