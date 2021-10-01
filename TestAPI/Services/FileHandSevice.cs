using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TestAPI.Services
{
    class FileHandSevice
    {
        public static async void WriteFile(string Name, string content)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var demoFile = await storage.CreateFileAsync(Name, CreationCollisionOption.ReplaceExisting);
            FileIO.WriteTextAsync(demoFile, content);
        }
        public static async Task<string> ReadFile(string Name)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var demoFile = await storage.CreateFileAsync(Name, CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(demoFile);
        }
    }
}
