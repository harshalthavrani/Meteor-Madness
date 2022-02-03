using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;
using NJHTFinalProject.Managers;
using NJHTFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NJHTFinalProject.Scenes
{
    public class LeaderBoardScene : SceneManager
    {
        private LeaderBoardComponent LeaderBoardComponent { get; set; }

        private SpriteBatch _spriteBatch;

        private Vector2 _position;
        private ScoreManager _scoreManager;
        Random Random;
        public LeaderBoardScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;
            //Create new spritebatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scoreManager = ScoreManager.Load();
            //_font = g.Content.Load<SpriteFont>("Fonts/regularFont");
           

            ScoreManager.Save(_scoreManager);
            const int startingXCoord = 750;
            const int startingYCoord = 450;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;


            //GameScreen g = (GameScreen)game;
            //_spriteBatch = g._spriteBatch;
            //SpriteFont authorFont = g.Content.Load<SpriteFont>("Fonts/authorFont");
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D background = g.Content.Load<Texture2D>("Images/Background");

            
            

            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            LeaderBoardComponent = new LeaderBoardComponent(game, _spriteBatch, background, regularFont, screenSize, _position, _scoreManager);

            this.Components.Add(LeaderBoardComponent);
        }
        public override void Initialize()
        {
            Random = new Random();
            base.Initialize();
        }
         public void SaveHighscore(int score)
        {
            _scoreManager.Add(new Models.Score()
            {
                PlayerName = Shared.PlayerName,
                Value = score,
            }
           );
        }
        
    }
}