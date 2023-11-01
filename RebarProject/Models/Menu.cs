using RebarProject.DataAccess;
using RebarProject.ModelsDB;

namespace RebarProject.Models
{
    public class Menu
    {
        public List<MenuShake> Shakes { get; set; }

        public Menu()
        {
            InitializeShakes();
        }

        public async void InitializeShakes()
        {
            ShakeDataAccess shakedb = new ShakeDataAccess();
            Shakes = await shakedb.GetAllShakes();
        }

        public List<MenuShake> ShowMenu()
        {
            return Shakes;
        }

        public void AddShakeToMenu(MenuShake shake)
        {
            ShakeDataAccess shakedb = new ShakeDataAccess();
            shakedb.CreateShake(shake);
            InitializeShakes();
        }
    }
}
