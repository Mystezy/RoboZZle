using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace RoboZZle_by_Mystezy
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TopPanel.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
            MainPanel.BackgroundColor = Color.FromRgba(0, 0, 0, 0.5);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MapPage)).Assembly;
            string text = "";
            foreach (var res in assembly.GetManifestResourceNames())
            {
                string name = res;
                name = name.Substring(25);
                name = name.Substring(0, name.Length - 4);
                text += name + " ";
            }
            var titles = text.Split(' ');
            string[] TITLES = new string[titles.Length - 1];
            for (int i = 0; i < titles.Length - 1; i++)
                TITLES[i] = titles[i];
            MainPanel.ItemsSource = TITLES;

        }

        private void Cube_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Question_Clicked(object sender, EventArgs e)
        {

        }

        private async void MainPanel_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new MapPage(e.Item.ToString()));
        }

    }
}
