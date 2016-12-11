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
            menuItems.Add(new BakeryMenu() { ID = 0, Flavor = "Chocolate Cake", Type = "Cake", Price = 8.95, Category = "Food", Description = "This is a real old-fashioned American chocolate layer cake. It's very moist, very chocolatey.", MenuImage = "Assets/chocolate_cake.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 1, Flavor = "Lemon Cake", Type = "Cake", Price = 8.95, Category = "Food", Description = "This cheery lemon cake is perfect for festive occasions. Top it off with our Whipped Frosting that's the perfect light and fluffy complement to this moist cake.", MenuImage = "Assets/lemon_cake.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 2, Flavor = "Strawberry Cake", Type = "Cake", Price = 8.95, Category = "Food", Description = "This three-layer strawberry cake gets its delicious flavor from chopped fresh strawberries and strawberry gelatin; slathered with the homemade strawberry buttercream frosting for a rich cake that's truly out of this world. ", MenuImage = "Assets/strawberry_cake.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 3, Flavor = "Chocolate Eclair", Type = "Eclair", Price = 8.95, Category = "Food", Description = "An oblong pastry made with choux dough filled with a cream and topped with chocolate icing.", MenuImage = "Assets/chocolate_elcair.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 4, Flavor = "Coffee Eclair", Type = "Eclair", Price = 8.95, Category = "Food", Description = "An oblong pastry made with choux dough filled with a coffee flavored cream and topped with caramel icing.", MenuImage = "Assets/coffee_eclair.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 5, Flavor = "Vanilla Eclair", Type = "Eclair", Price = 8.95, Category = "Food", Description = "an oblong pastry made with choux dough filled with a vanilla cream and topped with vanilla icing.", MenuImage = "Assets/vanilla_eclair.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 6, Flavor = "Apple Tart", Type = "Tart", Price = 8.95, Category = "Food", Description = "This classic French Apple Tart gives you a double dose of apples. It begins with a pre baked Sweet Pastry Crust which has a wonderfully crisp texture and a sweet buttery flavor. Next, comes a layer of lightly sweetened apple sauce that is topped with artfully arranged apples slices.", MenuImage = "Assets/apple_tart.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 7, Flavor = "Cherry Tart", Type = "Tart", Price = 8.95, Category = "Food", Description = "This rustic, overstuffed tart makes enticing use of the summer's bounty of cherries.", MenuImage = "Assets/cherry_tart.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 8, Flavor = "Berry Tart", Type = "Tart", Price = 8.95, Category = "Food", Description = "Lightly sweetened berries top vanilla bean-flecked pastry cream contained in a graham cracker crust.", MenuImage = "Assets/berry_tart.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 9, Flavor = "Chocolate Mocha", Type = "Coffee", Price = 8.95, Category = "Drink", Description = "Our signature espresso meets white chocolate sauce and steamed milk, then is finished off with sweetened whipped cream in this white chocolate delight.", MenuImage = "Assets/chocolate_coffee.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 10, Flavor = "Vanilla Frappachino", Type = "Frappachino", Price = 8.95, Category = "Drink", Description = "This rich and creamy blend of vanilla bean, milk and ice topped with whipped cream takes va-va-vanilla flavor to another level. ", MenuImage = "Assets/vanilla_frappuccino.jpg" });
            menuItems.Add(new BakeryMenu() { ID = 11, Flavor = "Raspberry Lemonade", Type = "Lemonade", Price = 8.95, Category = "Drink", Description = "Go all-natural with a refreshing lemonade made from naturally-sweet mashed raspberries, lemon juice, and water.", MenuImage = "Assets/raspberry_lemonade.jpg" });
            
            await DataServiceXML.SaveObjectToXml(menuItems, "BakeryMenu.xml");
        }
    }
}
