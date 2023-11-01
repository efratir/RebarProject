namespace RebarProject.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderShake> Shakes { get; set; } 
        public List<Discount> Discounts { get; set; }
        public decimal SumOfPrices { get; set; }

        public Order(string customerName, List<OrderShake> orderedShakes, decimal sumOfPrices)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            Shakes = new List<OrderShake>();
            Shakes = orderedShakes;
            Discounts = new List<Discount>();
            OrderDate = DateTime.Now;                              
            SumOfPrices = sumOfPrices;
        }

    }
}
