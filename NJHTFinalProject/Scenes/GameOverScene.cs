using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class GameOverScene : SceneManager
    {
        public GameOverComponent GameOverComponent { get; set; }

        public int Score { get; set; }

        private SpriteBatch _spriteBatch;
        private SpriteFont _headerFont;
        private SpriteFont _regularFont;

        private Rectangle _screenSize;

        private Texture2D _background;

        private Vector2 _position;

        private string _header;
        private string _score;
        private string _controllerMessage;

        public GameOverScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            _screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            _background = g.Content.Load<Texture2D>("Images/Background");
            _headerFont = g.Content.Load<SpriteFont>("Fonts/authorFont");
            _regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");

            _header = "Game Over!";

            _score = "Your score was: ";
            _controllerMessage = "Press ENTER or Press the A button to continue!";

            _position = new Vector2(700, 450);

            GameOverComponent = new GameOverComponent(game, _spriteBatch, _headerFont, _regularFont, _screenSize, _background, _position, _header, _score, _controllerMessage);

            this.Components.Add(GameOverComponent);
        }
    }
}