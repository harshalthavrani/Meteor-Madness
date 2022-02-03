using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NJHTFinalProject.Components
{
    public class AboutUsComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _screenSize;
        private Vector2 _position;
        private SpriteFont _authorFont;
        private SpriteFont _regularFont;
        private string _authorOne;
        private string _authorTwo;

        public AboutUsComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D background,
            SpriteFont authorFont,
            SpriteFont regularFont,
            Rectangle screenSize,
            Vector2 position,
            string authorOne,
            string authorTwo) : base(game)
        {
            _spriteBatch = spriteBatch;
            _authorFont = authorFont;
            _regularFont = regularFont;
            _authorOne = authorOne;
            _authorTwo = authorTwo;
            _position = position;
            _screenSize = screenSize;
            _background = background;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.DrawString(_authorFont, _authorOne, _position, Color.White);
            _spriteBatch.DrawString(_authorFont, _authorTwo, new Vector2(_position.X, _position.Y + 60), Color.White);

            _spriteBatch.DrawString(_regularFont, "Press escape or B to go back!", new Vector2(10, Shared.stage.Y - 30), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}