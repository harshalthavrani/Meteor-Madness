using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using NJHTFinalProject.Managers;
using System.Linq;

namespace NJHTFinalProject.Components
{
    public class LeaderBoardComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _screenSize;
        private Vector2 _position;
        
        private SpriteFont _regularFont;
        private ScoreManager _scoreManager;


        public LeaderBoardComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D background,
            SpriteFont regularFont,
            Rectangle screenSize,
            Vector2 position,
            ScoreManager scoreManager) : base(game)
        {
            _spriteBatch = spriteBatch;
            
            _regularFont = regularFont;

            _scoreManager = scoreManager;
            _position = position;
            _screenSize = screenSize;
            _background = background;
        }

        public override void Draw(GameTime gameTime) //additional
        {
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.DrawString(_regularFont, "HighScores: ", new Vector2(Shared.stage.X / 2 - 100, 300), Color.White);
            _spriteBatch.DrawString(_regularFont, "" + string.Join("\n",_scoreManager.Highscores.Select(h => h.PlayerName + ": " + h.Value).ToArray()), new Vector2(_position.X, _position.Y - 120), Color.White);
            

            _spriteBatch.DrawString(_regularFont, "Press escape or B to go back!", new Vector2(10, Shared.stage.Y - 30), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            ScoreManager.Save(_scoreManager);
            base.Update(gameTime);

        }
    }
    
}
