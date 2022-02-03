using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class AboutScene : SceneManager
    {
        private AboutUsComponent AboutUsComponent { get; set; }

        private SpriteBatch _spriteBatch;

        private Vector2 _position;

        public AboutScene(Game game) : base(game)
        {
            const int startingXCoord = 750;
            const int startingYCoord = 450;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;

            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            SpriteFont authorFont = g.Content.Load<SpriteFont>("Fonts/authorFont");
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D background = g.Content.Load<Texture2D>("Images/Background");

            string authorOne = "Nikk Jackson";
            string authorTwo = "Harshal Thavrani";

            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            AboutUsComponent = new AboutUsComponent(game, _spriteBatch, background, authorFont, regularFont, screenSize, _position, authorOne, authorTwo);

            this.Components.Add(AboutUsComponent);
        }
    }
}