using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using NJHTFinalProject.Components;
using System;
using System.Collections.Generic;

namespace NJHTFinalProject.Scenes
{
    public class GameScene : SceneManager
    {
        public GameScreenComponent GameComponent { get; set; }

        private List<Texture2D> meteors = new List<Texture2D>();
        List<Background> Backgrounds;
        private Game _game;
        private SoundEffect soundEffect;
        private SoundEffect soundEffect2;

        private SoundEffectInstance soundEffect2Instance;
        public List<MeteorComponent> MeteorComponents { get; set; }
        private SpriteBatch _spriteBatch;

        private Vector2 _position;

        public GameScene(Game game) : base(game)
        {
            int startingXCoord = (int)Shared.stage.X / 2 - 150;
            int startingYCoord = (int)Shared.stage.Y / 2 - 120;

            _position.X = startingXCoord;
            _position.Y = startingYCoord;

            GameScreen g = (GameScreen)game;
            _spriteBatch = g._spriteBatch;

            Texture2D spaceship = g.Content.Load<Texture2D>("Images/Spaceship");
            //Texture2D background = g.Content.Load<Texture2D>("Images/Space/Space_Stars10");
            //Load the background images
            Backgrounds = new List<Background>();
            Backgrounds.Add(new Background(g.Content.Load<Texture2D>("Images/Space/Space_Stars10"), new Vector2(300, 300), 0.6f));
            Backgrounds.Add(new Background(g.Content.Load<Texture2D>("Images/Space/Space_Stars11"), new Vector2(500, 500), 0.8f));
            Backgrounds.Add(new Background(g.Content.Load<Texture2D>("Images/Space/Space_Stars12"), new Vector2(700, 700), 1.1f));
            Rectangle screenSize = new Rectangle(0, 0, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);
            SpriteFont spriteFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Texture2D healthPlanet = g.Content.Load<Texture2D>("Images/HealthPlanet");

            for (int i = 1; i <= 21; i++)
            {
                var texture = g.Content.Load<Texture2D>($"Images/Meteor/Meteor/rotationY{i}");
                meteors.Add(texture); 
            }

            soundEffect = g.Content.Load<SoundEffect>("Sounds/Collision");
            soundEffect2 = g.Content.Load<SoundEffect>("Sounds/GameMusic");

            _game = game;

            GameComponent = new GameScreenComponent(game, _spriteBatch, _position, spaceship, Backgrounds, screenSize, spriteFont, healthPlanet, this);
            MeteorComponents = new List<MeteorComponent>();

            this.Components.Add(GameComponent);

            foreach (var meteors in MeteorComponents)
            {
                this.Components.Add(meteors);
            }

            soundEffect2Instance = soundEffect2.CreateInstance();
        }

        public void CreateMeteor()
        {
            GameScreen g = (GameScreen)_game;
            _spriteBatch = g._spriteBatch;
            Random rand = new Random();

            Vector2 position = new Vector2(rand.Next((int)Shared.stage.X), -7);

            Rectangle hitBox = new Rectangle((int)position.X, (int)position.Y, 100, 100);

            var meteorSprite = new MeteorComponent(_game, _spriteBatch, meteors, position, hitBox, GameComponent, soundEffect, 10);

            MeteorComponents.Add(meteorSprite);
        }

        public void PlaySound()
        {
            soundEffect2Instance.Volume = 0.3f;
            soundEffect2Instance.Play();
        }

        public void StopSound()
        {
            soundEffect2Instance.Stop();
        }
    }
}