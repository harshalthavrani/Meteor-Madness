// GAME MUSIC: https://www.youtube.com/watch?v=L_OYo2RS8iU&list=PLwJjxqYuirCLkq42mGw4XKGQlpZSfxsYd&index=8

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NJHTFinalProject.Scenes;

namespace NJHTFinalProject
{
    public class GameScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private SoundEffect _menuMusic;
        private SoundEffect _buttonSelected;
        private SoundEffectInstance _buttonSelectedIntance;
        private SoundEffectInstance _menuInstance;
        private KeyboardState oldState;
        private GamePadState oldGPState;
        // Declares all scenes
        private MenuScene startScene;
        private GameScene gameScene;
        private LeaderBoardScene leaderBoardScene;
        private AboutScene aboutScene;
        private HelpScene helpScene;
        private GameOverScene gameOverScene;
        private UsernameScene usernameScene;

        private int count = 0;

        private void HideAllScenes()
        {
            foreach (SceneManager component in Components)
            {
                component.Hide();
            }
        }

        public GameScreen()
        {

            Window.Title = "Meteor Madness";


            _graphics = new GraphicsDeviceManager(this);

            _graphics.IsFullScreen = true;



            _graphics.GraphicsProfile = GraphicsProfile.HiDef;

            if (_graphics.IsFullScreen)
            {
                _graphics.PreferredBackBufferWidth = 1920;
                _graphics.PreferredBackBufferHeight = 1080;
                _graphics.ApplyChanges();
            }
            else
            {
                Window.AllowUserResizing = true;
                _graphics.PreferredBackBufferWidth = 1916;
                _graphics.PreferredBackBufferHeight = 1020;
                _graphics.ApplyChanges();
            }

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Shared.PlayerLives = 3;
            Shared.PlayerScore = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            startScene = new MenuScene(this);
            gameScene = new GameScene(this);
            leaderBoardScene = new LeaderBoardScene(this);
            aboutScene = new AboutScene(this);
            helpScene = new HelpScene(this);
            gameOverScene = new GameOverScene(this);
            usernameScene = new UsernameScene(this);

            _menuMusic = Content.Load<SoundEffect>("Sounds/MenuMusic");
            _buttonSelected = Content.Load<SoundEffect>("Sounds/ButtonSelected");

            this.Components.Add(startScene);
            this.Components.Add(gameScene);
            this.Components.Add(aboutScene);
            this.Components.Add(helpScene);
            this.Components.Add(gameOverScene);
            this.Components.Add(leaderBoardScene);
            this.Components.Add(usernameScene);

            _menuInstance = _menuMusic.CreateInstance();
            _menuInstance.IsLooped = true;
            _menuInstance.Play();

            _buttonSelectedIntance = _buttonSelected.CreateInstance();

            usernameScene.Show();
        }

        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = startScene.Menu.SelectedIndex;

            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (startScene.Enabled)
            {
                if ((keyboardState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
                    || (gamePadState.Buttons.A == ButtonState.Pressed && oldGPState.Buttons.A == ButtonState.Released))
                {
                    if (selectedIndex == 0)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes();
                        gameScene.Show(); // Goes to play scene
                        _menuInstance.Stop();
                        gameScene.PlaySound();

                        
                    }
                    else if (selectedIndex == 1)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes(); // Goes to options scene
                        leaderBoardScene.Show();
                        _menuInstance.Stop();
                    }
                    else if (selectedIndex == 2)
                    {
                        _buttonSelectedIntance.Play();

                        HideAllScenes(); // Goes to help scene
                        helpScene.Show();
                    }
                    else if (selectedIndex == 3)
                    {
                        _buttonSelectedIntance.Play();
                        HideAllScenes(); // Goes to about scene

                        aboutScene.Show();
                    }
                    else if (selectedIndex == 4)
                    {
                        _buttonSelectedIntance.Play();
                        _menuInstance.Stop();

                        Exit(); // Exits the program
                    }
                }
                oldGPState = gamePadState;
                oldState = keyboardState;
            }
            else if (aboutScene.Enabled)
            {
                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    aboutScene.Hide();
                    startScene.Show();
                }
            }
            else if (helpScene.Enabled)
            {
                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    helpScene.Hide();
                    startScene.Show();
                }
            }
            else if (gameOverScene.Enabled)
            {
                gameScene.StopSound();
                if ((keyboardState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter)) || (gamePadState.Buttons.A == ButtonState.Pressed) && oldGPState.Buttons.A == ButtonState.Released)
                {
                    gameOverScene.Hide();
                    startScene.Show();
                    Shared.LastGameScore = Shared.PlayerScore;
                    leaderBoardScene.SaveHighscore(Shared.LastGameScore);
                    Shared.PlayerScore = 0;
                }
                
            }
            else if (gameScene.Enabled)
            { 
                
                if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    gameScene.Hide();
                    startScene.Show();
                    gameScene.StopSound();
                    _menuInstance.Play();
                }

                if (Shared.PlayerLives == -1)
                {
                    HideAllScenes();
                    Shared.PlayerLives = 3;
                    gameOverScene.Show();
                    _menuInstance.Play();
                    MediaPlayer.Stop();
                }
            }
            else if (leaderBoardScene.Enabled)
            {
                if ((keyboardState.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape)) || (gamePadState.Buttons.B == ButtonState.Pressed) && oldGPState.Buttons.B == ButtonState.Released)
                {
                    HideAllScenes();
                    startScene.Show();
                }
            }
            else if (usernameScene.Enabled)
            {
                if (!string.IsNullOrWhiteSpace(Shared.PlayerName))
                {
                    usernameScene.Hide();
                    startScene.Show();
                }
            }
            oldState = keyboardState;
            oldGPState = gamePadState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            count++;
            base.Draw(gameTime);
        }
    }
}