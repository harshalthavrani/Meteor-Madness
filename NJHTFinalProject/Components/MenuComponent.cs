using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Components
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Texture2D[] _menuButtons;
        private Rectangle _screenSize;
        private SoundEffect _buttonSound;
        private Vector2 _position;
        private SpriteFont _font;
        private Texture2D _menuTitle;

        private KeyboardState oldState;
        private GamePadState oldGPState;

        public int SelectedIndex { get; set; }

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D background,
            Rectangle screenSize,
            SoundEffect buttonSound,
            Texture2D[] menuButtons,
            SpriteFont font,
            Texture2D menuTitle) : base(game)
        {
            _spriteBatch = spriteBatch;
            _position = new Vector2(Shared.stage.X / 2 - 150, Shared.stage.Y / 2 - 50);
            _screenSize = screenSize;
            _background = background;
            _buttonSound = buttonSound;
            _menuButtons = menuButtons;
            _font = font;
            _menuTitle = menuTitle;
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPosition = _position;

            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.Draw(_menuTitle, new Vector2(690, 70), Color.White);

            for (int i = 0; i < 5; i++)
            {
                if (SelectedIndex == i)
                {
                    _spriteBatch.Draw(_menuButtons[i + 5], tempPosition, Color.White);
                    tempPosition.Y += 90;
                }
                else
                {
                    _spriteBatch.Draw(_menuButtons[i], tempPosition, Color.White);
                    tempPosition.Y += 90;
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            var instance = _buttonSound.CreateInstance();

            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if ((keyboardState.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
                || (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed && oldGPState.DPad.Down == ButtonState.Released)
                || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && oldGPState.ThumbSticks.Left.Y == 0))
            {
                SelectedIndex++;

                instance.Play();

                if (SelectedIndex == 5)
                {
                    SelectedIndex = 0;
                }
            }

            if ((keyboardState.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
                || (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed && oldGPState.DPad.Up == ButtonState.Released)
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 && oldGPState.ThumbSticks.Left.Y == 0)
            {
                SelectedIndex--;

                instance.Play();
                if (SelectedIndex == -1)
                {
                    SelectedIndex = 4;
                }
            }

            oldState = keyboardState;
            oldGPState = gamePadState;

            base.Update(gameTime);
        }
    }
}