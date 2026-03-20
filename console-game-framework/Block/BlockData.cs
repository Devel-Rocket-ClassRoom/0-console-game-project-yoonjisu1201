using System;
using System.Collections.Generic;
using System.Text;

public struct BlockData
{
    //public string Name { get; set; }
    public ConsoleColor Color { get; set; }
    public List<(int x, int y)> Shape {  get; set; }
    

    public BlockData(ConsoleColor color, List<(int x, int y)> shape)
    {
        //Name = name;
        Color = color;
        Shape = shape;
    }
}
