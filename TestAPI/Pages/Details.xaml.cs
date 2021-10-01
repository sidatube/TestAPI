using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestAPI.Models;
using TestAPI.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestAPI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
         

        }
        private Food _food;
        public async void Render(Food e)
        {
            Services.MenuSevices sevices = new Services.MenuSevices();
            Models.RootDetail root = await sevices.GetDetail(e.id.ToString());
            if( root != null)
            {
                Price.Text = root.data.price.ToString();
                Name.Text = root.data.name;
                Img.Source = new BitmapImage(new Uri(root.data.image));
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Food food = e.Parameter as Food;
            _food = food;
            Render(food);
        }

        private void AddToCard(object sender, RoutedEventArgs e)
        {
            CardSevice cart = new CardSevice();
            CardItem item = new CardItem()
            {
                id = _food.id,
                name = _food.name,
                image = _food.image,
                price = _food.price,
                qty = 1
            };
            cart.addToCard(item);
            var list = cart.getCart();
            return;
        }
    }
}
