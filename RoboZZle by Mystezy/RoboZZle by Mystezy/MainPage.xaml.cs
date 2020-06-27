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
            DisplayAlert("Правила", "Игровое поле - прямоугольник 16х12. Каждая клетка может быть раскрашена в 1 из 3х цветов: красный, синий или зелёный. В некоторых клетках лежат звёзды. Цель вашей программы-робота собрать все эти звёзды, не выходя за пределы окрашенных клеток.\n\nВы контроллируете робота с помощью программы. В программе разрешено до 5 функций в зависимости от задачи. В каждой функции может быть до 10 инструкций для робота. Максимальное количество операций для каждой функции указано в заголовке формы ввода. Доступные инструкции: Правый(Right) и левый(Left) поворот, шаг вперёд(Up) и вызовы функций(F1, F2, F3, F4, F5). Инструкции указываются в формате \"NameCom\"_\"NameCol\", где NameCom - первая буквы исполняемой команды(Up/Right/Left) или наименование функции(F1, F2, F3, F4, F5), NameCol - первая буква цвета команды(Default, Green, Blue, Red).", "OK");
        }

        private async void MainPanel_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new MapPage(e.Item.ToString()));
        }

    }
}
