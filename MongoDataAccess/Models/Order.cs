namespace RebarProject.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderShake> Shakes { get; set; }
        public List<Discount> discounts { get; set; }

    }
}
