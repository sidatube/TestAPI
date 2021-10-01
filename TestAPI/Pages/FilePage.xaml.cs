using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestAPI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilePage : Page
    {
        public FilePage()
        {
            this.InitializeComponent();
            //Adapters.SQLiteHelper Helper = Adapters.SQLiteHelper.GetIntance();
        }

        private void WriteFile(object sender, RoutedEventArgs e)
        {
            //var storage = ApplicationData.Current.LocalFolder;
            //var demo = await storage.CreateFileAsync("T2008M.txt", CreationCollisionOption.ReplaceExisting);
            //FileIO.WriteTextAsync(demo, "Hello mother fker");
            Services.FileHandSevice.WriteFile("T2008M", "Hello mother fucker!");
        }

        private async void ReadFile(object sender, RoutedEventArgs e)
        {
            //var storage = ApplicationData.Current.LocalFolder;
            //var demo = await storage.CreateFileAsync("T2008M.txt", CreationCollisionOption.OpenIfExists);
            //string content = await FileIO.ReadTextAsync(demo);
            string content = await Services.FileHandSevice.ReadFile("T2008M");
            abc.Text = content;
        }
    }
}
