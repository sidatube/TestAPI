using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestAPI.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }
        private void Gv_Loaded(object sender, RoutedEventArgs e)
        {

            RenderData();

        }
        public async void RenderData()
        {
            //Services.MenuSevices sevices = new Services.MenuSevices();
            //Models.RootHome root = await sevices.GetHome();
            //if (root != null)
            //{

            //    foreach (Models.Food c in root.data)
            //    {
            //        Gv.Items.Add(new ProductModel()
            //        {
            //            name = c.name,
            //            id = c.id,
            //            image = c.image,
            //            description = "A hamburger is a food, typically considered a sandwich.A Pizza is a food, typically considered a sandwich.......,,,,,,,A Pizza is a food, typically considered a sandwich.......,,,,,,,A Pizza is a food, typically considered a sandwich.......,,,,,,,",
            //            price = c.price.ToString() + " VND"
            //        });
            //    }
            //}
            Services.MenuSevices service = new Services.MenuSevices();
            var categoryDetail = await service.GetHome();
            if (categoryDetail != null)
            {
                Gv.ItemsSource = categoryDetail.data;
            }
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Food food = Gv.SelectedItem as Food;
            MainPage._frame.Navigate(typeof(Details),food);
        }

       
    }
}
