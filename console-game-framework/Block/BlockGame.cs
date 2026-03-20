using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;

   public class BlockGame : GameApp
{
    private readonly SceneManager<Scene> _scenes = new SceneManager<Scene>();
    public BlockGame() : base(40, 20)
    {

    }
    protected override void Draw()
    {
        _scenes.CurrentScene?.Draw(Buffer);
    }

    protected override void Initialize()
    {
        ChangeToTitle();
    }

    protected override void Update(float deltaTime)
    {
        _scenes.CurrentScene?.Update(deltaTime);
    }
    private void ChangeToTitle()
    {
        var title = new TitleScene();
        title.StartRequested += ChangeToPlay;
        _scenes.ChangeScene(title);
    }
    private void ChangeToPlay() 
    {
        var play = new PlayScene();
        play.PlayAgainRequested += ChangeToPlay;
        _scenes.ChangeScene(play);
    }
}
