using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMenu_berigaj
{
    class BakeryMenuManager
    {
        public static async Task<T> ReadXMLFileAsync<T>(string filename)
        {
             private List<BakeryMenu> _skiRuns;

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
        /// <param name="BakeryMenu"></param>
        /// <returns>int ID</returns>
        private int GetItemsByIndex(int ID)
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
        /// method to add a new menu item
        /// </summary>
        /// <param name="_menuItems"></param>
        public async void InsertBakeryMenu(BakeryMenu menuItem)
        {
            _menuItems.Add(menuItem);

            await DataServiceXml.SaveObjectToXml(_menuItems, "BakeryMenu.xml");
        }

        /// <summary>
        /// method to delete a menu item by ID
        /// </summary>
        /// <param name="ID"></param>
        public async void DeleteMenuItem(int ID)
        {
            _menuItems.RemoveAt(GetMenuItemByIndex(ID));

            await DataServiceXml.SaveObjectToXml(_skiRuns, "SkiRuns.xml");
        }

        /// <summary>
        /// method to update an existing ski run
        /// </summary>
        /// <param name="skiRun">ski run object</param>
        public async void UpdateSkiRun(SkiRun skiRun)
        {
            DeleteSkiRun(skiRun.ID);
            InsertSkiRun(skiRun);

            await SkiRunsDataServiceXml.SaveObjectToXml(_skiRuns, "SkiRuns.xml");
        }

        /// <summary>
        /// method to return a ski run object given the ID
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>ski run object</returns>
        public SkiRun GetSkiRunByID(int ID)
        {
            SkiRun skiRun = null;

            skiRun = _skiRuns[GetSkiRunByIndex(ID)];

            return skiRun;
        }

        /// <summary>
        /// method to query the data by the vertical of each ski run in feet
        /// </summary>
        /// <param name="minimumVertical">int minimum vertical</param>
        /// <param name="maximumVertical">int maximum vertical</param>
        /// <returns></returns>
        public List<SkiRun> QueryByVertical(int minimumVertical, int maximumVertical)
        {
            List<SkiRun> matchingSkiRuns = new List<SkiRun>();

            foreach (var skiRun in _skiRuns)
            {
                if ((skiRun.Vertical >= minimumVertical) && (skiRun.Vertical <= maximumVertical))
                {
                    matchingSkiRuns.Add(skiRun);
                }
            }

            return matchingSkiRuns;
        }

        /// <summary>
        /// method to handle the IDisposable interface contract
        /// </summary>
        public void Dispose()
        {
            _skiRuns = null;
        }
    }
}
