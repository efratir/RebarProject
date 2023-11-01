namespace RebarProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public List<Order> orders { get; set; }
        public decimal SumOfOrders { get; set; }
    }
}
