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
using System.Threading;

namespace RoboZZle_by_Mystezy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public Grid OUG;
        public Grid UpGrid;
        public Grid LowGrid;
        public Game zxc;
        public Button StartB;
        public Image droid;
        public Image[] stars;
        public Button[][] FuncB = new Button[5][];
        public Label[][] FuncL = new Label[5][];

        public MapPage(string str)
        {
            InitializeComponent();
            TopPanel.BackgroundColor = Xamarin.Forms.Color.FromRgba(0, 0, 0, 0.7);
            PanelTitle.Text = str;

            zxc = new Game(str);

            int z = 0;
            stars = new Image[zxc.Stars.Count];
            foreach(var el in zxc.Stars)
            {
                var item = (new Image
                {
                    Source = "Zvizda.png",
                });
                stars[z] = item;
                z++;
            }

            BuildUpGrid();
            OUG = UpGrid;
            UpGridPainter();

            BuildLowGrid();

            var g = LowGrid;
            for (int i = 0; i < zxc.functions; i++)
            {
                FuncB[i] = new Button[zxc.Max[i]];
                FuncL[i] = new Label[zxc.Max[i]];

                for (int j = 0; j < zxc.Max[i]; j++)
                {
                    FuncL[i][j] = new Label()
                    {
                        Text = (j + 1).ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    g.Children.Add(FuncL[i][j], j + 3, 2 * i + 1);

                    FuncB[i][j] = new Button()
                    {
                        BackgroundColor = Xamarin.Forms.Color.FromRgba(255, 169, 169, 0.5),
                    };
                    g.Children.Add(FuncB[i][j], j + 3, 2 * i + 1);
                    FuncB[i][j].Clicked += But_Clicked;
                }
            }
            GameGrid.Children.Add(g, 0, 1);
        }

        public void BuildUpGrid()
        {
            UpGrid = new Grid
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
                TextColor = Xamarin.Forms.Color.Blue,
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

            UpGrid.Children.Add(Stop, 9, 12);
            UpGrid.Children.Add(StopB, 9, 12);

            UpGrid.Children.Add(Start, 6, 12);
            UpGrid.Children.Add(StartB, 6, 12);

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 16; j++)
                {
                    if (zxc.DefaultField[i][j] == Classы.Color.Blue)
                        UpGrid.Children.Add(new Button
                        {
                            IsEnabled = false,
                            BackgroundColor = Xamarin.Forms.Color.Blue,
                        }, j, i);
                    else if (zxc.DefaultField[i][j] == Classы.Color.Red)
                        UpGrid.Children.Add(new Button
                        {
                            IsEnabled = false,
                            BackgroundColor = Xamarin.Forms.Color.Red,
                        }, j, i);
                    else if (zxc.DefaultField[i][j] == Classы.Color.Green)
                        UpGrid.Children.Add(new Button
                        {
                            IsEnabled = false,
                            BackgroundColor = Xamarin.Forms.Color.Green,
                        }, j, i);
                }

            droid = new Image
            {
                Source = "android.png",
            };
        }

        public void UpGridPainter()
        {
            int z = 0;
            foreach (var el in zxc.Stars)
            {
                if (OUG.Children.Contains(stars[z]))
                    OUG.Children.Remove(stars[z]);
                z++;
            }

            z = 0;
            foreach (var el in zxc.Stars)
            {
                if (el.Value == true)
                    OUG.Children.Add(stars[z], el.Key.X, el.Key.Y);
                z++;
            }

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
                case Direction.Up:
                    droid.Rotation = 0;
                    break;
            }

            OUG.Children.Add(droid, zxc.NowPos.X, zxc.NowPos.Y);

            GameGrid.Children.Add(OUG, 0, 0);
        }

        public void BuildLowGrid()
        {
            LowGrid = new Grid
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
                LowGrid.Children.Add(new Button
                {
                    IsEnabled = false,
                    BackgroundColor = Xamarin.Forms.Color.Gray,
                }, 1, 2 * i + 1);

                LowGrid.Children.Add(new Label
                {
                    Text = "F" + (i + 1).ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                }, 1, 2 * i + 1);
            }
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

            }
            return true;
        }

        private void Question_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Правила", "Игровое поле - прямоугольник 16х12. Каждая клетка может быть раскрашена в 1 из 3х цветов: красный, синий или зелёный. В некоторых клетках лежат звёзды. Цель вашей программы-робота собрать все эти звёзды, не выходя за пределы окрашенных клеток.\n\nВы контроллируете робота с помощью программы. В программе разрешено до 5 функций в зависимости от задачи. В каждой функции может быть до 10 инструкций для робота, также в зависимости от задачи. Доступные инструкции: Правый(Right) и левый(Left) поворот, шаг вперёд(Up), остаться на месте(Stay) и вызовы функций(F1, F2, F3, F4, F5). Команда указанная с цветом не Default будет выполняться только тогда, когда робот стоит на ячейке с цветом соответствующим выбранному цвету команды.", "OK");
        }

        private async void StartB_Clicked(object sender, EventArgs args)
        {
            StartB.IsEnabled = false;
            for (int i = 0; i < zxc.functions; i++)
            {
                zxc.Actions[i] = new Classы.Action[zxc.Max[i]];
                for (int j = 0; j < zxc.Max[i]; j++)
                {
                    Classы.Color clr = Classы.Color.Default;
                    Classы.Command cmd = Classы.Command.Null;
                    if (FuncB[i][j].Text != null)
                    {
                        var mas = FuncB[i][j].Text.Split();

                        switch (mas[0])
                        {
                            case "Stay":
                                cmd = Classы.Command.Default;
                                break;
                            case "Up":
                                cmd = Classы.Command.Up;
                                break;
                            case "Right":
                                cmd = Classы.Command.Right;
                                break;
                            case "Left":
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

                        switch (mas[1])
                        {
                            case "Red":
                                clr = Classы.Color.Red;
                                break;
                            case "Green":
                                clr = Classы.Color.Green;
                                break;
                            case "Blue":
                                clr = Classы.Color.Blue;
                                break;
                            case "Default":
                                clr = Classы.Color.Default;
                                break;
                        }
                    }

                    zxc.Actions[i][j] = new Classы.Action(cmd, clr, j);
                }
            }

            zxc.Started = true;
            zxc.Execute();

            while (true)
            {

                if (zxc.Stop == true)
                {
                    zxc.NewGame();
                    UpGridPainter();
                    break;
                }

                zxc.Execute();
                if (zxc.CheckLose())
                {
                    zxc.NewGame();
                    await Task.Delay(150);
                    UpGridPainter();
                    await DisplayAlert(null, "вы проиграли :), придумайте что-нибудь новенькое", "OK");
                    break;
                }
                else if (zxc.ActionQueue.Count == 0)
                {
                    UpGridPainter();
                    await Task.Delay(150);
                    zxc.NewGame();
                    UpGridPainter();
                    await DisplayAlert(null, "инструкции закончились.. слабовато как-то :с", "OK");
                    await Task.Delay(150);
                    break;
                }
                else if (zxc.CheckWin())
                {
                    UpGridPainter();
                    await Task.Delay(150);
                    zxc.NewGame();
                    await DisplayAlert(null, "Воу-воу, все звёзды собраны :О, да ты вообще красавчик! :р", "OK");
                    UpGridPainter();
                    break;
                }

                if (zxc.ActionQueue[0].command == Classы.Command.Default || zxc.ActionQueue[0].command == Classы.Command.Left || zxc.ActionQueue[0].command == Classы.Command.Right || zxc.ActionQueue[0].command == Classы.Command.Up)
                {
                    UpGridPainter();
                    await Task.Delay(150);
                }
                else
                {
                    UpGridPainter();
                    await Task.Delay(50);
                }
            }
            StartB.IsEnabled = true;
            zxc.Started = false;
        }

        private void StopB_Clicked(object sender, EventArgs args)
        {
            if (zxc.Started)
                zxc.Stop = true;
        }
        private async void But_Clicked(object sender, EventArgs args)
        {
            string[] mas = new string[4 + zxc.functions];
            mas[0] = "Stay";
            mas[1] = "Up";
            mas[2] = "Right";
            mas[3] = "Left";
            string coloract;
            for (int i = 0; i < zxc.functions; i++)
                mas[4 + i] = "F" + (i + 1).ToString();
            string action = await DisplayActionSheet("Выберите действие", "Отмена", null, mas);
            
            if (action != null)
            {
                var g = LowGrid;
                if (action != "Stay")
                {
                    coloract = await DisplayActionSheet("Цвет действия", "Отмена", null, "Default", "Red", "Green", "Blue");
                    if (coloract != null)
                        (sender as Button).Text = action + " " + coloract;
                }
                else
                {
                    coloract = "Default";
                    (sender as Button).Text = action + " " + coloract;
                }
                for (int i = 0; i < zxc.functions; i++)
                    for (int j = 0; j < zxc.Max[i]; j++)
                    {
                        if (FuncB[i][j].Text != null)
                        {
                            string txt = FuncB[i][j].Text;
                            var mastxt = txt.Split();

                            switch(mastxt[0])
                            {
                                case "Stay":
                                    FuncL[i][j].Text = "S";
                                    break;
                                case "Up":
                                    FuncL[i][j].Text = "U";
                                    break;
                                case "Left":
                                    FuncL[i][j].Text = "L";
                                    break;
                                case "Right":
                                    FuncL[i][j].Text = "R";
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

                            switch(mastxt[1])
                            {
                                case "Default":
                                    FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.FromRgba(128, 128, 128, 0.5);
                                    break;
                                case "Red":
                                    FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.FromRgba(255, 0, 0, 0.5);
                                    break;
                                case "Green":
                                    FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.FromRgba(0, 255, 0, 0.5);
                                    break;
                                case "Blue":
                                    FuncB[i][j].BackgroundColor = Xamarin.Forms.Color.FromRgba(0, 0, 255, 0.8);
                                    break;
                            }

                            g.Children.Add(FuncB[i][j], j + 3, 2 * i + 1);
                            g.Children.Add(FuncL[i][j], j + 3, 2 * i + 1);
                        }
                    }
                GameGrid.Children.Add(g, 0, 1);
            }
        }
    }
}