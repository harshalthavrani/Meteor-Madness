using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using NJHTFinalProject.Components;

namespace NJHTFinalProject.Scenes
{
    public class MenuScene : SceneManager
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch _spriteBatch;

        private Texture2D[] menuButtons = new Texture2D[10];

        public MenuScene(Game game) : base(game)
        {
            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D background = g.Content.Load<Texture2D>("Images/Background"); // SOURCE: https://www.freepik.com/free-vector/space-banner-with-purple-planet-landscape_13778479.htm#page=1&query=cartoon%20space&position=13&from_view=keyword
            SoundEffect buttonSound = g.Content.Load<SoundEffect>("Sounds/ButtonSound"); // SOURCE: https://www.youtube.com/watch?v=ILaQFzeuamU

            menuButtons[0] = g.Content.Load<Texture2D>("Images/MenuButtons/PlayButton");
            menuButtons[1] = g.Content.Load<Texture2D>("Images/MenuButtons/LeaderBoardButton");
            menuButtons[2] = g.Content.Load<Texture2D>("Images/MenuButtons/HelpButton");
            menuButtons[3] = g.Content.Load<Texture2D>("Images/MenuButtons/AboutUsButton");
            menuButtons[4] = g.Content.Load<Texture2D>("Images/MenuButtons/ExitButton");
            menuButtons[5] = g.Content.Load<Texture2D>("Images/MenuButtons/PlayButtonSelected");
            menuButtons[6] = g.Content.Load<Texture2D>("Images/MenuButtons/LeaderBoardButtonSelected");
            menuButtons[7] = g.Content.Load<Texture2D>("Images/MenuButtons/HelpButtonSelected");
            menuButtons[8] = g.Content.Load<Texture2D>("Images/MenuButtons/AboutUsButtonSelected");
            menuButtons[9] = g.Content.Load<Texture2D>("Images/MenuButtons/ExitButtonSelected");

            Texture2D menuTitle = g.Content.Load<Texture2D>("Images/title");

            SpriteFont font = g.Content.Load<SpriteFont>("Fonts/titleFont");

            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            Menu = new MenuComponent(game, _spriteBatch, background, screenSize, buttonSound, menuButtons, font, menuTitle);
            this.Components.Add(Menu);
        }
    }
}