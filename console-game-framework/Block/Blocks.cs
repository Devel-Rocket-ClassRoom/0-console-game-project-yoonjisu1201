using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

public  class Blocks : GameObject
{
    private List<(int X, int Y)> _position;
    private ConsoleColor _color;
    public List<(int X, int Y)> Position => _position;
    public ConsoleColor Color => _color;

    Random _random = new Random();
    private List<List<(int x, int y)>> _shapes = new List<List<(int x, int y)>>   //16개 모양
    {
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), (2, 1), (2, 2) },  // 3*3 'ㄱ'
        new List<(int x, int y)> { (0, 0), (1, 0), (1, 1), (1, 2) },  // 2*3 'ㄱ'
        new List<(int x, int y)> { (0, 0), (0, 1), (0, 2), (1, 2), (2, 2) },  // 3*3 'ㄴ'
        new List<(int x, int y)> { (0, 0), (1, 0), (1, 1), (2, 1) },  // 3*2 'ㄴ'
        new List<(int x, int y)> { (0, 0), (0, 1), (0, 2), },  // 1*3 'ㅣ'
        new List<(int x, int y)> { (0, 0), (0, 1), (0, 2), (0, 3) },  // 1*4 'ㅣ'
        new List<(int x, int y)> { (0, 0), (0, 1), (0, 2), (0, 3), (0, 4) },  // 1*5 'ㅣ'
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), },  // 3*1 'ㅡ'
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), (3, 0) },  // 4*1 'ㅡ'
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), (3, 0), (4, 0) },  // 5*1 'ㅡ'
        new List<(int x, int y)> { (1, 0), (0, 1), (1, 1), (2, 1) },  //  'ㅗ'
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), (1, 1) },  //  'ㅜ'
        new List<(int x, int y)> { (0, 1), (1, 0), (1, 1), (1, 2) },  //  'ㅓ'
        new List<(int x, int y)> { (0, 0), (0, 1), (0, 2), (1, 1) },  //  'ㅏ'
        new List<(int x, int y)> { (0, 0), (0, 1), (1, 0), (1, 1) },  //  2*2 'ㅁ'
        new List<(int x, int y)> { (0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2), (2, 2) },  //  3*3 'ㅁ'
    };

    private ConsoleColor[] _colors = { 
     ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Yellow,
     ConsoleColor.Blue, ConsoleColor.Cyan};


    public Blocks(Scene scene) : base(scene)
    {
        Name = "Blocks";
    }
    public override void Draw(ScreenBuffer buffer)
    {
        foreach (var pos in _position)
        {
            int drawX = (pos.X * 2) + 14;
            int drawY = pos.Y + 14;

            buffer.SetCell(drawX, drawY, '▣', _color, _color);
            buffer.SetCell(drawX +1, drawY, '▣', _color, _color);
        }
    }

    public override void Update(float deltaTime)
    {


    }
    public void Spawn()  // 블록을 놓으면 새로 생성 , (지정된 위치에, 랜덤 블럭)
    {
        var randomblock = GetRandomBlock();
        _position = randomblock.Shape;
        _color = randomblock.Color;
    }

    public BlockData GetRandomBlock()
    {
        var shape = _shapes[_random.Next(_shapes.Count)];
        var color = _colors[_random.Next(_colors.Length)];
        return new BlockData(color, shape);
    }

}
