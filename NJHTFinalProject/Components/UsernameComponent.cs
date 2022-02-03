using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using NJHTFinalProject.Managers;

namespace NJHTFinalProject.Components
{
    public class UsernameComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _textBox;
        private Texture2D _background;
        private Rectangle _screenSize;
        private Vector2 _position;
        private SpriteFont _font;
        private SpriteFont _regularFont;
        private string username;
        private KeyboardState _keyboardState;

        public UsernameComponent(Game game, SpriteBatch spriteBatch, Texture2D textBox, Texture2D background, Vector2 position, Rectangle screenSize, SpriteFont font, SpriteFont regularFont) : base(game)
        {
            _spriteBatch = spriteBatch;
            _textBox = textBox;
            _position = position;
            _font = font;
            username = "";
            _background = background;
            _regularFont = regularFont;
            _screenSize = screenSize;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, _screenSize, Color.White);
            _spriteBatch.DrawString(_font, "Username:", new Vector2(_position.X - 320, _position.Y - 10), Color.White);
            _spriteBatch.Draw(_textBox, _position, Color.White);
            _spriteBatch.DrawString(_font, username, _position, Color.Black);
            _spriteBatch.DrawString(_regularFont, "If username is not empty, press enter to continue!\nPress escape to exit", new Vector2(_position.X - 320, _position.Y + 80), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            

            Keys[] keysPressed = keyboardState.GetPressedKeys();

            Keys key = Keys.None;

            if (keysPressed.Length > 0)
            {
                if (keyboardState.IsKeyDown(keysPressed[0]) && _keyboardState.IsKeyUp(keysPressed[0]))
                {
                    key = keysPressed[0];
                }
            }
            
            if (key != Keys.None)
            {
                if (username.Length < 12)
                {
                    if (key == Keys.Back)
                    {
                        if (username.Length > 0)
                        {
                            username = username.Remove(username.Length - 1);
                        }
                    }
                    else if (key == Keys.Enter)
                    {
                        Shared.PlayerName = username;
                    }
                    else if (key == Keys.Escape)
                    {
                        Game.Exit();
                    }
                    else
                    {
                        char character = InputManager.GetInputCharacter(key);

                        if (character != '\0')
                        {
                            username += character;
                        }
                    }
                }
            }

            _keyboardState = keyboardState;

            base.Update(gameTime);
        }
    }
}
