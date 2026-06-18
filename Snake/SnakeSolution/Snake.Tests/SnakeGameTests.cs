using Snake.Core;

namespace Snake.Tests;

public class SnakeGameTests
{
    [Fact]
    public void SnakeMovesRight()
    {
        var game =
            new SnakeGame(DifficultyLevel.Medium);

        Position oldHead = game.Snake.Head;

        game.Update();

        Assert.Equal(
            oldHead.X + 1,
            game.Snake.Head.X);
    }

    [Fact]
    public void ScoreStartsFromZero()
    {
        var game =
            new SnakeGame(DifficultyLevel.Easy);

        Assert.Equal(0, game.Score);
    }

    [Fact]
    public void FoodCreated()
    {
        var game =
            new SnakeGame(DifficultyLevel.Easy);

        Assert.NotEmpty(game.Foods);
    }

    [Fact]
    public void DirectionCannotReverse()
    {
        var game =
            new SnakeGame(DifficultyLevel.Easy);

        game.ChangeDirection(Direction.Left);

        Assert.Equal(
            Direction.Right,
            game.Snake.Direction);
    }
}