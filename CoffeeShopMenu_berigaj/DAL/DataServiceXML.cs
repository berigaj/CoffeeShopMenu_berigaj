using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMenu_berigaj
{
    public class DataServiceXML
    {
        public static async Task<T> ReadObjectFromXmlFileAsync<T>(string filename)
        {
            T objectFromXml = default(T);

            var serializer = new XmlSerializer(typeof(T));

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(filename);
            Stream stream = await file.OpenStreamForReadAsync();

            objectFromXml = (T)serializer.Deserialize(stream);

            stream.Dispose();

            return objectFromXml;
        }

        public static async Task SaveObjectToXml<T>(T objectToSave, string filename)
        {
            var serializer = new XmlSerializer(typeof(T));

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();

            using (stream)
            {
                serializer.Serialize(stream, objectToSave);
            }
        }
    }
}
