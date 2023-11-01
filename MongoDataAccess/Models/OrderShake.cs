namespace RebarProject.Models
{
    public class OrderShake
    {
        public int Id { get; set; }
        public MenuShake shake { get; set; }
        public char Size { get; set; }
        public decimal Price { get; set; }

    }
}
