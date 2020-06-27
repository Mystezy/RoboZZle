using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoboZZle_by_Mystezy.Classы;
using System.Drawing;
using System.Xml.Schema;

namespace RoboZZle_by_Mystezy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public Grid grid;
        public Game zxc;
        public Button StartB;
        public Button[][] FuncB = new Button[5][];
        public Label[][] FuncL = new Label[5][];
        public string F1 = "";
        public string F2 = "";
        public string F3 = "";
        public string F4 = "";
        public string F5 = "";

        public MapPage(string str)
        {
            InitializeComponent();
            TopPanel.BackgroundColor = Xamarin.Forms.Color.FromRgba(0, 0, 0, 0.7);
            PanelTitle.Text = str;
            zxc = new Game(str);

            grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                RowSpacing = 1,
                ColumnSpacing = 1,
            };

            Image Start = new Image
            {
                Source = "start.png",
            };

            Image Stop = new Image
            {
                Source = "stop.png",
            };

            StartB = new Button
            {
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = Application.Current.MainPage.Width / 12,
            };
            StartB.Clicked += StartB_Clicked;

            Button StopB = new Button
            {
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = Application.Current.MainPage.Width / 12,
            };
            StopB.Clicked += StopB_Clicked;

            grid.Children.Add(Start, 6, 12);
            grid.Children.Add(Stop, 9, 12);
            grid.Children.Add(StartB, 6, 12);
            grid.Children.Add(StopB, 9, 12);

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 16; j++)
                {
                    if (zxc.DefaultField[i][j] == Classы.Color.Blue)
                        grid.Children.Add(new BoxView
                        {
                            BackgroundColor = Xamarin.Forms.Color.Blue,
                        }, j, i);
                    else if (zxc.DefaultField[i][j] == Classы.Color.Red)
                        grid.Children.Add(new BoxView
                        {
                            BackgroundColor = Xamarin.Forms.Color.Red,
                        }, j, i);
                    else if (zxc.DefaultField[i][j] == Classы.Color.Green)
                        grid.Children.Add(new BoxView
                        {
                            BackgroundColor = Xamarin.Forms.Color.Green,
                        }, j, i);
                }

            foreach (var el in zxc.Stars)
                if (el.Value == true)
                    grid.Children.Add(new Image
                    {
                        Source = "Zvizda.png",
                    }, el.Key.X, el.Key.Y);

            var droid = new Image
            {
                Source = "android.png",
            };

            switch (zxc.NowDir)
            {
                case Direction.Right:
                    droid.Rotation = 90;
                    break;
                case Direction.Down:
                    droid.Rotation = 180;
                    break;
                case Direction.Left:
                    droid.Rotation = 270;
                    break;
            }

            grid.Children.Add(droid, zxc.NowPos.X, zxc.NowPos.Y);

            GameGrid.Children.Add(grid, 0, 0);


            grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(Application.Current.MainPage.Width / 16) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                RowSpacing = 1,
                ColumnSpacing = 1,
            };


            for (int i = 0; i < zxc.functions; i++)
            {
                grid.Children.Add(new BoxView
                {
                    BackgroundColor = Xamarin.Forms.Color.Gray,
                }, 1, 2 * i + 1);

                grid.Children.Add(new Label
                {
                    Text = "F" + (i + 1).ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                }, 1, 2 * i + 1);

                Button but = new Button()
                {
                    BackgroundColor = Xamarin.Forms.Color.Transparent,
                };

                if (i == 0)
                    but.Clicked += f1_Clicked;
                else if (i == 1)
                    but.Clicked += f2_Clicked;
                else if (i == 2)
                    but.Clicked += f3_Clicked;
                else if (i == 3)
                    but.Clicked += f4_Clicked;
                else if (i == 4)
                    but.Clicked += f5_Clicked;

                grid.Children.Add(but, 1, 2 * i + 1);

                FuncB[i] = new Button[zxc.Max[i]];
                FuncL[i] = new Label[zxc.Max[i]];

                for (int j = 0; j < zxc.Max[i]; j++)
                {
                    FuncB[i][j] = new Button() 
                    {
                        IsEnabled = false,
                        BackgroundColor = Xamarin.Forms.Color.DarkGray,
                    };
                    grid.Children.Add(FuncB[i][j], j + 3, 2 * i + 1);

                    FuncL[i][j] = new Label()
                    {
                        Text = (j + 1).ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    grid.Children.Add(FuncL[i][j], j + 3, 2 * i + 1);
                }
            }
            GameGrid.Children.Add(grid, 0, 1);
        }

        public bool Chek(int i, string str)
        {
            var mas = str.Split();
            if (mas.Length != zxc.functions)
                return false;
            foreach(var el in mas)
            {
                var mass = el.Split('_');
                if (mass[0][0] == 'F') 
                {
                    if (int.Parse(mass[0][1].ToString()) > zxc.functions)
                        return false;
                }
                /*else if (mass[0][0] != 'U' && mass[0][0] != 'R' && mass[0][0] != 'L')
                    return false;
                else if */

            }
            return true;
        }

        private void Question_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Правила", "Игровое поле - прямоугольник 16х12. Каждая клетка может быть раскрашена в 1 из 3х цветов: красный, синий или зелёный. В некоторых клетках лежат звёзды. Цель вашей программы-робота собрать все эти звёзды, не выходя за пределы окрашенных клеток.\n\nВы контроллируете робота с помощью программы. В программе разрешено до 5 функций в зависимости от задачи. В каждой функции может быть до 10 инструкций для робота. Максимальное количество операций для каждой функции указано в заголовке формы ввода. Доступные инструкции: Правый(Right) и левый(Left) поворот, шаг вперёд(Up) и вызовы функций(F1, F2, F3, F4, F5). Инструкции указываются в формате \"NameCom\"_\"NameCol\", где NameCom - первая буквы исполняемой команды(Up/Right/Left) или наименование функции(F1, F2, F3, F4, F5), NameCol - первая буква цвета команды(Default, Green, Blue, Red).", "OK");
        }

        private void StartB_Clicked(object sender, EventArgs args)
        {
            for (int i = 0; i < zxc.functions; i++)
            {
                zxc.Actions[i] = new Classы.Action[zxc.Max[i]];
                for (int j = 0; j < zxc.Max[i]; j++)
                {
                    Classы.Color clr = Classы.Color.Default;
                    Classы.Command cmd = Classы.Command.Null;
                    if (FuncB[i][j].BackgroundColor == Xamarin.Forms.Color.Red)
                        clr = Classы.Color.Red;
                    else if (FuncB[i][j].BackgroundColor == Xamarin.Forms.Color.Blue)
                        clr = Classы.Color.Blue;
                    else if (FuncB[i][j].BackgroundColor == Xamarin.Forms.Color.Green)
                        clr = Classы.Color.Green;
                    else if (FuncB[i][j].BackgroundColor == Xamarin.Forms.Color.Gray)
                        clr = Classы.Color.Default;

                    switch (FuncL[i][j].Text)
                    {
                        case "U":
                            cmd = Classы.Command.Up;
                            break;
                        case "R":
                            cmd = Classы.Command.Right;
                            break;
                        case "L":
                            cmd = Classы.Command.Left;
                            break;
                        case "F1":
                            cmd = Classы.Command.F1;
                            break;
                        case "F2":
                            cmd = Classы.Command.F2;
                            break;
                        case "F3":
                            cmd = Classы.Command.F3;
                            break;
                        case "F4":
                            cmd = Classы.Command.F4;
                            break;
                        case "F5":
                            cmd = Classы.Command.F5;
                            break;
                    }

                    zxc.Actions[i][j] = new Classы.Action(cmd, clr, j);
                }
            }

            zxc.Execute();

            while(true)
            {
                zxc.Execute();

            }
        }

        private void StopB_Clicked(object sender, EventArgs args)
        {

        }

        public void FPaint(string str, int i)
        {
            var mas = str.Split();
            for (int j = 0; j < zxc.Max[i]; j++)
            {
                var mass = mas[j].Split('_');

                switch (mass[0])
                {
                    case "U":
                        FuncL[i][j].Text = "U";
                        break;
                    case "R":
                        FuncL[i][j].Text = "R";
                        break;
                    case "L":
                        FuncL[i][j].Text = "L";
                        break;
                    case "F1":
                        FuncL[i][j].Text = "F1";
                        break;
                    case "F2":
                        FuncL[i][j].Text = "F2";
                        break;
                    case "F3":
                        FuncL[i][j].Text = "F3";
                        break;
                    case "F4":
                        FuncL[i][j].Text = "F4";
                        break;
                    case "F5":
                        FuncL[i][j].Text = "F5";
                        break;
                }

                switch (mass[1])
                {
                    case "R":
                        FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.Red;
                        break;
                    case "G":
                        FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.Green;
                        break;
                    case "B":
                        FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.Blue;
                        break;
                    case "D":
                        FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.Gray;
                        break;
                }

                grid.Children.Add(FuncB[i][j], j + 3, 2 * i + 1);
                grid.Children.Add(FuncL[i][j], j + 3, 2 * i + 1);
            }

            GameGrid.Children.Add(grid, 0, 1);
        }

        private async void f1_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync(null, "Максимальное количество команд: " + zxc.Max[0].ToString());
            if (result != null)
            {
                result = result.ToUpper();
                if (Chek(zxc.Max[0], result))
                {
                    F1 = result;
                    FPaint(result, 0);
                }
                else
                    await DisplayAlert("Ошибка", "Функция содержит недпустимые вызовы функций или неправильное количество инструкций. Попробуйте заного.", "OK");
            }
        }
        private async void f2_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync(null, "Максимальное количество команд: " + zxc.Max[1].ToString());
            if (result != null)
            {
                result = result.ToUpper();
                if (Chek(zxc.Max[1], result))
                {
                    F2 = result;
                    FPaint(result, 1);
                }
                else
                    await DisplayAlert("Ошибка", "Функция содержит недпустимые вызовы функций или неправильное количество инструкций. Попробуйте заного.", "OK");
            }
        }
        private async void f3_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync(null, "Максимальное количество команд: " + zxc.Max[2].ToString());
            if (result != null)
            {
                result = result.ToUpper();
                if (Chek(zxc.Max[2], result))
                {
                    F3 = result;
                    FPaint(result, 2);
                }
                else
                    await DisplayAlert("Ошибка", "Функция содержит недпустимые вызовы функций или неправильное количество инструкций. Попробуйте заного.", "OK");
            }
        }
        private async void f4_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync(null, "Максимальное количество команд: " + zxc.Max[3].ToString());
            if (result != null)
            {
                result = result.ToUpper();
                if (Chek(zxc.Max[3], result))
                {
                    F4 = result;
                    FPaint(result, 3);
                }
                else
                    await DisplayAlert("Ошибка", "Функция содержит недпустимые вызовы функций или неправильное количество инструкций. Попробуйте заного.", "OK");
            }
        }
        private async void f5_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync(null, "Максимальное количество команд: " + zxc.Max[4].ToString());
            if (result != null)
            {
                result = result.ToUpper();
                if (Chek(zxc.Max[4], result))
                {
                    F5 = result;
                    FPaint(result, 4);
                }
                else
                    await DisplayAlert("Ошибка", "Функция содержит недпустимые вызовы функций или неправильное количество инструкций. Попробуйте заного.", "OK");
            }
        }
    }
}