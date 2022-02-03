using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class UsernameScene : SceneManager
    {
        public UsernameComponent UsernameComponent { get; set; }

        private SpriteBatch _spriteBatch;

        public UsernameScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D textBox = g.Content.Load<Texture2D>("Images/Textbox");
            SpriteFont font = g.Content.Load<SpriteFont>("Fonts/titleFont");
            SpriteFont regular = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D background = g.Content.Load<Texture2D>("Images/Background");

            Vector2 position = new Vector2(Shared.stage.X / 2 - 230, Shared.stage.Y / 2 - 80);
            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            UsernameComponent = new UsernameComponent(game, _spriteBatch, textBox, background, position, screenSize, font, regular);

            this.Components.Add(UsernameComponent);
        }
    }
}
