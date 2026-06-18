using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core;

public class Snake
{
    public LinkedList<Position> Body { get; } = new();

    public Direction Direction { get; set; }

    public Snake()
    {
        Body.AddFirst(new Position(12, 12));
        Direction = Direction.Right;
    }

    public Position Head => Body.First!.Value;
}
