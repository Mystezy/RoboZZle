using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace RoboZZle_by_Mystezy.Classы
{
    public class Game
    {
        Position StartPos;

        Direction StartDir;

        public Position NowPos;

        public Direction NowDir;

        public int functions;

        public int[] Max = new int[5];

        public Action[][] Actions = new Action[5][];

        public Color[][] DefaultField = new Color[12][];

        public Dictionary<Position, bool> Stars = new Dictionary<Position, bool>();

        public List<Action> ActionQueue = new List<Action>();

        bool Lose;

        public bool stop;

        public void Execute()
        {
            if (DefaultField[NowPos.Y][NowPos.X] == ActionQueue[0].color || ActionQueue[0].color == Color.Default)
                switch (ActionQueue[0].command)
                {
                    case Command.Default:
                        break;
                    case Command.Left:
                        if (NowDir == Direction.Up)
                            NowDir = Direction.Left;
                        else if (NowDir == Direction.Right)
                            NowDir = Direction.Up;
                        else if (NowDir == Direction.Down)
                            NowDir = Direction.Right;
                        else
                            NowDir = Direction.Down;

                        ActionQueue.RemoveAt(0);
                        break;
                    case Command.Right:
                        if (NowDir == Direction.Up)
                            NowDir = Direction.Right;
                        else if (NowDir == Direction.Right)
                            NowDir = Direction.Down;
                        else if (NowDir == Direction.Down)
                            NowDir = Direction.Left;
                        else
                            NowDir = Direction.Up;

                        ActionQueue.RemoveAt(0);
                        break;
                    case Command.Up:
                        if (NowDir == Direction.Up)
                            NowPos.Y--;
                        else if (NowDir == Direction.Right)
                            NowPos.X++;
                        else if (NowDir == Direction.Down)
                            NowPos.Y++;
                        else
                            NowPos.X--;

                        if (StartPos.X > 15 || StartPos.X < 0 || StartPos.Y > 11 || StartPos.Y < 0)
                            Lose = true;
                        else if (DefaultField[NowPos.Y][NowPos.X] == Color.None)
                            Lose = true;

                        ActionQueue.RemoveAt(0);
                        break;
                    case Command.F1:
                        ActionQueue.RemoveAt(0);
                        for (int i = Max[0] - 1; i >= 0; i--)
                            ActionQueue.Insert(0, Actions[0][i]);
                        break;
                    case Command.F2:
                        ActionQueue.RemoveAt(0);
                        for (int i = Max[1] - 1; i >= 0; i--)
                            ActionQueue.Insert(0, Actions[1][i]);
                        break;
                    case Command.F3:
                        ActionQueue.RemoveAt(0);
                        for (int i = Max[2] - 1; i >= 0; i--)
                            ActionQueue.Insert(0, Actions[2][i]);
                        break;
                    case Command.F4:
                        ActionQueue.RemoveAt(0);
                        for (int i = Max[3] - 1; i >= 0; i--)
                            ActionQueue.Insert(0, Actions[3][i]);
                        break;
                    case Command.F5:
                        ActionQueue.RemoveAt(0);
                        for (int i = Max[4] - 1; i >= 0; i--)
                            ActionQueue.Insert(0, Actions[4][i]);
                        break;
                }
            else if (ActionQueue[0].color == Color.None)
                Lose = true;
            else
                ActionQueue.RemoveAt(0);
        }



        public bool CheckLose()
        {
            if (Lose == true)
                return true;
            else
                return false;
        }

        public Game(string Name)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Game)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("RoboZZle by Mystezy.Maps." + Name + ".txt");

            using (var reader = new StreamReader(stream))
            {
                string line;
                for (int i = 0; i < 12; i++)
                {
                    DefaultField[i] = new Color[16];
                    line = reader.ReadLine();
                    var Mas = line.Split();
                    for (int j = 0; j < 16; j++)
                    {
                        var Mass = Mas[j].Split('_');
                        switch (Mass[0])
                        {
                            case "R":
                                DefaultField[i][j] = Color.Red;
                                break;
                            case "G":
                                DefaultField[i][j] = Color.Green;
                                break;
                            case "B":
                                DefaultField[i][j] = Color.Blue;
                                break;
                            case "N":
                                DefaultField[i][j] = Color.None;
                                break;
                        }

                        if (Mass[1] == "1")
                        {
                            Position Pos = new Position();
                            Pos.Y = i;
                            Pos.X = j;
                            Stars.Add(Pos, true);
                        }
                    }
                }

                line = reader.ReadLine();
                var MAS = line.Split();
                Position POS = new Position();
                POS.X = int.Parse(MAS[0]);
                POS.Y = int.Parse(MAS[1]);
                StartPos = POS;

                line = reader.ReadLine();
                switch (line)
                {
                    case "Up":
                        StartDir = Direction.Up;
                        break;
                    case "Right":
                        StartDir = Direction.Right;
                        break;
                    case "Down":
                        StartDir = Direction.Down;
                        break;
                    case "Left":
                        StartDir = Direction.Left;
                        break;
                }
                NowPos = StartPos;
                NowDir = StartDir;

                line = reader.ReadLine();
                MAS = line.Split();
                functions = MAS.Length;

                for (int i = 0; i < functions; i++)
                    Max[i] = int.Parse(MAS[i]);
            }

            Action NEW = new Action(Command.F1, Color.Default, 0);
            ActionQueue.Add(NEW);

            Lose = false;

            stop = false;
        }

        public void NewGame()
        {
            NowPos = StartPos;
            NowDir = StartDir;

            foreach (var el in Stars)
                Stars[el.Key] = true;

            Lose = false;
            stop = false;

            Action NEW = new Action(Command.F1, Color.Default, 0);
            ActionQueue.Add(NEW);
        }
    }

    public class Action
    {
        public Command command;
        public Color color;
        public int id;

        public Action(Command comm, Color col)
        {
            command = comm;
            color = col;
        }

        public Action()
        {

        }

        public Action(int i)
        {
            command = Command.Null;
            color = Color.None;
            id = i;
        }

        public Action(Command comm, Color col, int i)
        {
            command = comm;
            color = col;
            id = i;
        }
    }
    public enum Command
    {
        Up,
        Right,
        Left,
        Default,
        F1,
        F2,
        F3,
        F4,
        F5,
        Null
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public enum Color
    {
        Default,
        Red,
        Green,
        Blue,
        None
    }

    public struct Position
    {
        public int X;
        public int Y;
    }
}
