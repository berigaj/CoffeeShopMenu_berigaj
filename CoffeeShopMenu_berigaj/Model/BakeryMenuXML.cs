using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoffeeShopMenu_berigaj
{
    class BakeryMenuXML
    {
        [XmlRoot("BakeryMenu")]
        public class BakeryMenu
        {
            [XmlElement("BakeryMenu")]
            public List<BakeryMenu> menuItems = new List<BakeryMenu>();
        }
    }
}
