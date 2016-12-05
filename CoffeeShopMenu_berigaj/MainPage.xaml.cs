using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CoffeeShopMenu_berigaj;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CoffeeShopMenu_berigaj
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<BakeryMenu> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeDataContext();
        }

        private async void InitializeDataContext()
        {
            // write date to data file
            InitializeBakeryMenu.WriteDataToFileXml();

            // read and deserialize XML data
            MenuItems = await DataServiceXML.ReadObjectFromXmlFileAsync<List<BakeryMenu>>("BakeryMenu.xml");
            BakeryMenuDataManagerXml bakeryMenuDataManager = new BakeryMenuDataManagerXml(MenuItems);   
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (BakeryMenu)e.ClickedItem;
            MenuItemName.Text = menuItem.Flavor;

            BitmapImage bitmapImage = new BitmapImage(new Uri(this.BaseUri, $"/{menuItem.MenuImage}"));
            MenuImage.Source = bitmapImage;
        }
        private void FilterListView_btn_Click(object sender, RoutedEventArgs e)
        {
            List<BakeryMenu> filteredListMenuItems = new List<BakeryMenu>();

            foreach (BakeryMenu menuItem in MenuItems)
            {
                if (menuItem.Category == ViewCategory.Text)
                {
                    filteredListMenuItems.Add(menuItem);
                }
            }

            MenuItems = filteredListMenuItems;

            MenuItemListView.ItemsSource = filteredListMenuItems;
        }

        private void ViewCategory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
