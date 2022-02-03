using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class HelpScene : SceneManager
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _regularFont;

        public HelpComponent HelpComponent { get; set; }

        public HelpScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            _background = g.Content.Load<Texture2D>("Images/Background");
            _regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");

            _screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            HelpComponent = new HelpComponent(game, _spriteBatch, _background, _screenSize, _regularFont);

            this.Components.Add(HelpComponent);
        }
    }
}