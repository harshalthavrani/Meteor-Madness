using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NJHTFinalProject.Components
{
    public class GameOverComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _headerFont;
        private SpriteFont _regularFont;

        private Rectangle _screenSize;

        private Texture2D _background;

        private Vector2 _position;

        private string _header;
        private string _score;
        private string _controllerMessage;

        public GameOverComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont headerFont,
            SpriteFont regularFont,
            Rectangle screenSize,
            Texture2D background,
            Vector2 position,
            string header,
            string score,
            string controllerMessage) : base(game)
        {
            _spriteBatch = spriteBatch;
            _headerFont = headerFont;
            _regularFont = regularFont;
            _screenSize = screenSize;
            _background = background;
            _position = position;
            _header = header;
            _score = score;
            _controllerMessage = controllerMessage;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);

            _spriteBatch.DrawString(_headerFont, _header, _position, Color.White);
            _spriteBatch.DrawString(_headerFont, _score + Shared.GetPlayerScore(), new Vector2(_position.X, _position.Y + 60), Color.White);
            _spriteBatch.DrawString(_regularFont, _controllerMessage, new Vector2(_position.X, _position.Y + 120), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}