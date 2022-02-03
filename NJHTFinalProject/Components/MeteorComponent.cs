using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NJHTFinalProject.Components
{
    public class MeteorComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;

        private List<Texture2D> _meteorSprites;
        private Vector2 _position;
        private int direction = 0;
        private Rectangle _hitBox;
        private int _delay;
        private int delayCounter;
        private int meteorIndex;

        private bool playerHit = false;

        private GameScreenComponent _gameScreenComponent;
        private SoundEffect _soundEffect;

        public MeteorComponent(Game game,
            SpriteBatch spriteBatch,
            List<Texture2D> meteorSprites,
            Vector2 position,
            Rectangle hitBox,
            GameScreenComponent gameScreenComponent,
            SoundEffect soundEffect,
            int delay) : base(game)
        {
            _meteorSprites = meteorSprites;
            _position = position;
            _hitBox = hitBox;
            _spriteBatch = spriteBatch;
            _gameScreenComponent = gameScreenComponent;

            Random rand = new Random();
            direction = rand.Next(2);

            _delay = delay;

            delayCounter = 0;
            meteorIndex = 0;

            _soundEffect = soundEffect;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (meteorIndex >= 0)
            {
                if (!playerHit)
                {
                    _spriteBatch.Draw(_meteorSprites[meteorIndex], _hitBox, Color.White);
                }
                
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (direction == 1)
            {
                _hitBox.X += 2;
            }
            else
            {
                _hitBox.X -= 2;
            }

            _hitBox.Y += 4;

            var meteorBounds = this.GetBounds();
            var playerBounds = Shared.GetBounds();

            if (playerBounds.Intersects(meteorBounds) && !playerHit)
            {
                Shared.PlayerLives--;
                playerHit = true;

                _soundEffect.Play(volume: 0.1f, pitch: 0.0f, pan: 0.0f);
            }

            delayCounter++;
            if (delayCounter > _delay)
            {
                meteorIndex++;

                if (meteorIndex == _meteorSprites.Count)
                {
                    meteorIndex = 0;
                    delayCounter = 0;
                }
            }

            base.Update(gameTime);
        }

        public Rectangle GetBounds()
        {
            return _hitBox;
        }
    }
}