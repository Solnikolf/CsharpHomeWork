using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core;

public class Food
{
    public Position Position { get; set; }

    public Food(Position position)
    {
        Position = position;
    }
}