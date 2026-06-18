using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core;

public class SnakeGame
{
    private readonly Random random = new();

    public const int FieldSize = 25;

    public Snake Snake { get; private set; }

    public List<Food> Foods { get; private set; }

    public int Score { get; private set; }

    public GameState State { get; private set; }

    public DifficultyLevel Difficulty { get; }

    public SnakeGame(DifficultyLevel difficulty)
    {
        Difficulty = difficulty;

        Snake = new Snake();
        Foods = new List<Food>();

        CreateFood(StartFoodCount());
        State = GameState.Running;
    }

    private int StartFoodCount()
    {
        return Difficulty switch
        {
            DifficultyLevel.Easy => 5,
            DifficultyLevel.Medium => 3,
            DifficultyLevel.Hard => 1,
            _ => 3
        };
    }

    private void CreateFood(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            bool created = false;

            for (int attempt = 0; attempt < 1000; attempt++)
            {
                var pos = new Position(
                    random.Next(FieldSize),
                    random.Next(FieldSize));

                if (!Snake.Body.Contains(pos)
                    && !Foods.Any(f => f.Position == pos))
                {
                    Foods.Add(new Food(pos));
                    created = true;
                    break;
                }
            }

            if (!created)
                return;
        }
    }

    public void ChangeDirection(Direction direction)
    {
        if (Snake.Direction == Direction.Up && direction == Direction.Down)
            return;

        if (Snake.Direction == Direction.Down && direction == Direction.Up)
            return;

        if (Snake.Direction == Direction.Left && direction == Direction.Right)
            return;

        if (Snake.Direction == Direction.Right && direction == Direction.Left)
            return;

        Snake.Direction = direction;
    }

    public void Update()
    {
        if (State == GameState.GameOver)
            return;

        Position head = Snake.Head;

        Position newHead = Snake.Direction switch
        {
            Direction.Up => head with { Y = head.Y - 1 },
            Direction.Down => head with { Y = head.Y + 1 },
            Direction.Left => head with { X = head.X - 1 },
            Direction.Right => head with { X = head.X + 1 },
            _ => head
        };

        if (newHead.X < 0 ||
            newHead.Y < 0 ||
            newHead.X >= FieldSize ||
            newHead.Y >= FieldSize)
        {
            State = GameState.GameOver;
            return;
        }

        var bodyToCheck = Snake.Body.Take(Snake.Body.Count - 1);

        if (bodyToCheck.Contains(newHead))
        {
            State = GameState.GameOver;
            return;
        }

        Snake.Body.AddFirst(newHead);

        Food? food = Foods.FirstOrDefault(f => f.Position == newHead);

        if (food != null)
        {
            Foods.Remove(food);
            Score++;
            CreateFood();
        }
        else
        {
            Snake.Body.RemoveLast();
        }
    }
}