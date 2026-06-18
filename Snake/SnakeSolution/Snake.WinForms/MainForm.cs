using Snake.Core;

namespace Snake.WinForms;

public partial class MainForm : Form
{
    private SnakeGame game = null!;

    private DifficultyLevel currentDifficulty;

    private const int CellSize = 20;

    public MainForm()
    {
        InitializeComponent();

        DoubleBuffered = true;

        currentDifficulty = DifficultyLevel.Medium;
        StartNewGame(currentDifficulty);
    }

    private void StartNewGame(DifficultyLevel level)
    {
        game = new SnakeGame(level);

        timer1.Interval = level switch
        {
            DifficultyLevel.Easy => 250,
            DifficultyLevel.Medium => 150,
            DifficultyLevel.Hard => 80,
            _ => 150
        };

        timer1.Start();

        Invalidate();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        game.Update();

        lblScore.Text = $"Score: {game.Score}";

        if (game.State == GameState.GameOver)
        {
            timer1.Stop();

            MessageBox.Show(
                $"Game Over.\nScore: {game.Score}");
        }

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        for (int y = 0; y < SnakeGame.FieldSize; y++)
        {
            for (int x = 0; x < SnakeGame.FieldSize; x++)
            {
                g.DrawRectangle(
                    Pens.LightGray,
                    x * CellSize,
                    y * CellSize,
                    CellSize,
                    CellSize);
            }
        }

        foreach (var food in game.Foods)
        {
            g.FillRectangle(
                Brushes.Red,
                food.Position.X * CellSize,
                food.Position.Y * CellSize,
                CellSize,
                CellSize);
        }

        foreach (var part in game.Snake.Body)
        {
            g.FillRectangle(
                Brushes.Green,
                part.X * CellSize,
                part.Y * CellSize,
                CellSize,
                CellSize);
        }
    }

    protected override bool ProcessCmdKey(
        ref Message msg,
        Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Up:
                game.ChangeDirection(Direction.Up);
                break;

            case Keys.Down:
                game.ChangeDirection(Direction.Down);
                break;

            case Keys.Left:
                game.ChangeDirection(Direction.Left);
                break;

            case Keys.Right:
                game.ChangeDirection(Direction.Right);
                break;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }
    private void newGameToolStripMenuItem_Click(
    object sender,
    EventArgs e)
    {
        StartNewGame(currentDifficulty);
    }

    private void easyToolStripMenuItem_Click(
    object sender,
    EventArgs e)
    {
        currentDifficulty = DifficultyLevel.Easy;
        StartNewGame(currentDifficulty);
    }

    private void mediumToolStripMenuItem_Click(
    object sender,
    EventArgs e)
    {
        currentDifficulty = DifficultyLevel.Medium;
        StartNewGame(currentDifficulty);
    }

    private void hardToolStripMenuItem_Click(
     object sender,
     EventArgs e)
    {
        currentDifficulty = DifficultyLevel.Hard;
        StartNewGame(currentDifficulty);
    }

    private void exitToolStripMenuItem_Click(
        object sender,
        EventArgs e)
    {
        Close();
    }
}