using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;

public class PlayScene : Scene
{
    private Board board;
    private Blocks blocks;
    private int score;
    private bool isGameOver;

    public event GameAction PlayAgainRequested;

    public override void Load()
    {
        score = 0;
        isGameOver = false;

        board = new Board(this);
        AddGameObject(board);

        blocks = new Blocks(this);
        blocks.Spawn();
        AddGameObject(blocks);


    }
    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);
    }


    public override void Unload()
    {
        ClearGameObjects();
    }

    public override void Update(float deltaTime)
    {
        UpdateGameObjects(deltaTime);
    }
}
