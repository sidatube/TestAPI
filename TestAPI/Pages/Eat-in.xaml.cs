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
    public sealed partial class Eat_in : Page
    {
        public Eat_in()
        {
            this.InitializeComponent();
        }

        private void Gv_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        //public async void RenderData()
        //{
        //    Services.MenuSevices sevices = new Services.MenuSevices();
        //    Models.RootEat root = await sevices.GetData("1");
        //    if(root != null)
        //    {
        //        foreach (Models.Food c in root.data.foods)
        //        {
        //            Gv.Items.Add(new ProductModel() { Name = c.name, Image = c.image, Description = "A hamburger is a food, typically considered a sandwich", 
        //                Price = c.price.ToString()+" VND",});
        //        }
        //    }
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataMenu dataMenu = e.Parameter as DataMenu;
            Title.Text = dataMenu.name;
            RenderFoods(dataMenu);
        }
        public async void RenderFoods(DataMenu data)
        {
            Services.MenuSevices service = new Services.MenuSevices();
            var categoryDetail = await service.GetData(data.id.ToString());
            if (categoryDetail != null)
            {
                Gv.ItemsSource = categoryDetail.data.foods;
            }
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Food food = Gv.SelectedItem as Food;
            MainPage._frame.Navigate(typeof(Details), food);
        }
    }
}
