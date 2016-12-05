using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMenu_berigaj
{
    class InitializeBakeryMenu
    {
        public async static void WriteDataToFileXml()
        {
            List<BakeryMenu> menuItems = new List<BakeryMenu>();

            // initialize the IList of high scores - note: no instantiation for an interface
            menuItems.Add(new BakeryMenu() { ID = 0, Flavor = "Chocolate", Type="Cake", Price = 8.95,Category="Food", Description="Chocolate cake description", MenuImage = "" });
            menuItems.Add(new BakeryMenu() { ID = 1, Flavor="Lemon", Type="Cake", Price=8.95, Category="Food", Description="Lemon cake desc",MenuImage = "" });
            
            await DataServiceXML.SaveObjectToXml(menuItems, "BakeryMenu.xml");
        }
    }
}
