using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMenu_berigaj
{
   public class BakeryMenuDataManagerXml : IDisposable
        {
            private List<BakeryMenu> _menuItems;

            public BakeryMenuDataManagerXml(List<BakeryMenu> menuItems)
            {
                _menuItems = menuItems;
            }

            /// <summary>
            /// method to return a list of menu items
            /// </summary>
            /// <returns>list of menu item objects</returns>
            public List<BakeryMenu> GetAllMenuItems()
            {
                return _menuItems;
            }

            /// <summary>
            /// method to return the index of a given menu item
            /// <param name="menuItem"></param>
            /// <returns>int ID</returns>
            private int GetMenuItemByIndex(int ID)
            {
                int menuItemIndex = 0;

                for (int index = 0; index < _menuItems.Count(); index++)
                {
                    if (_menuItems[index].ID == ID)
                    {
                        menuItemIndex = index;
                    }
                }

                return menuItemIndex;
            }

            /// <summary>
            /// method to add a new menu Item
            /// </summary>
            /// <param name="_menuItems"></param>
            public async void InsertMenuItem(BakeryMenu menuItem)
            {
                _menuItems.Add(menuItem);

                await DataServiceXML.SaveObjectToXml(_menuItems, "BakeryMenu.xml");
            }

            /// <summary>
            /// method to delete a menu item by ID
            /// </summary>
            /// <param name="ID"></param>
            public async void DeleteMenuItem(int ID)
            {
                _menuItems.RemoveAt(GetMenuItemByIndex(ID));

                await DataServiceXML.SaveObjectToXml(_menuItems, "BakeryMenu.xml");
            }

            /// <summary>
            /// method to update an existing menu item
            /// </summary>
            /// <param name="menuItem">menu item object</param>
            public async void UpdateMenuItem(BakeryMenu menuItem)
            {
                DeleteMenuItem(menuItem.ID);
                InsertMenuItem(menuItem);

                await DataServiceXML.SaveObjectToXml(_menuItems, "BakeryMenu.xml");
            }

            /// <summary>
            /// method to return a ski run object given the ID
            /// </summary>
            /// <param name="ID">int ID</param>
            /// <returns>ski run object</returns>
            public BakeryMenu GetMenuItemByID(int ID)
            {
                BakeryMenu menuItem = null;

                menuItem = _menuItems[GetMenuItemByIndex(ID)];

                return menuItem;
            }
        
            public List<BakeryMenu> QueryByPrice(double minPrice, double maxPrice)
            {
                List<BakeryMenu> matchingMenuItems = new List<BakeryMenu>();

                foreach (var menuItem in _menuItems)
                {
                    if ((menuItem.Price >= minPrice) && (menuItem.Price <= maxPrice))
                    {
                        matchingMenuItems.Add(menuItem);
                    }
                }

                return matchingMenuItems;
            }

            /// <summary>
            /// method to handle the IDisposable interface contract
            /// </summary>
            public void Dispose()
            {
                _menuItems = null;
            }
        }
    }
