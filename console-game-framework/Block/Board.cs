using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

public class Board : GameObject
{
    public const int Left = 1;
    public const int Top = 2;
    public const int Right = 9;
    public const int Bottom = 10;
    public Board(Scene scene) : base(scene)
    {
        Name = "Board";
    }
    public override void Draw(ScreenBuffer buffer)
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int drawX = (j * 2) + 8;
                int drawY = i + 4;

                buffer.SetCell(drawX, drawY, '*', ConsoleColor.DarkGray, ConsoleColor.DarkGray);
                buffer.SetCell(drawX + 1, drawY, '*', ConsoleColor.DarkGray, ConsoleColor.DarkGray);
            }
        }

    }

    public override void Update(float deltaTime)
    {
    }
}
