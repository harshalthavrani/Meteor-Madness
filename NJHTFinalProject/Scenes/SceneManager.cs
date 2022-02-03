using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace NJHTFinalProject.Scenes
{
    public abstract class SceneManager : DrawableGameComponent
    {
        // List of GameComponents
        public List<GameComponent> Components { get; set; }

        /// <summary>
        /// Enables game scene
        /// </summary>
        public virtual void Show()
        {
            // Enables
            this.Enabled = true;

            // Makes visible
            this.Visible = true;
        }

        /// <summary>
        /// Disables the game scene
        /// </summary>
        public virtual void Hide()
        {
            // Disables
            this.Enabled = false;

            // Makes invisible
            this.Visible = false;
        }

        /// <summary>
        /// GameScene Constructor
        /// </summary>
        /// <param name="game">Game</param>
        protected SceneManager(Game game) : base(game)
        {
            // Instantiates the list of components
            Components = new List<GameComponent>();

            // Hides the GameScene by default
            Hide();
        }

        /// <summary>
        /// Used to draw the components to the screen
        /// </summary>
        /// <param name="gameTime">Game Time</param>
        public override void Draw(GameTime gameTime)
        {
            // Creates a null game component
            DrawableGameComponent gameComponent = null;

            // Goes through the component list
            foreach (GameComponent component in Components)
            {
                // Checks to see if the component is a drawable component
                if (component is DrawableGameComponent)
                {
                    // Saves the component to gameComponent
                    gameComponent = (DrawableGameComponent)component;

                    // Checks if its visible
                    if (gameComponent.Visible)
                    {
                        // Draws the component
                        gameComponent.Draw(gameTime);
                    }
                }
            }

            // Draws on gameTime
            base.Draw(gameTime);
        }

        /// <summary>
        /// Runs every update every frame
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public override void Update(GameTime gameTime)
        {
            // Goes through the list of components
            foreach (Microsoft.Xna.Framework.GameComponent component in Components)
            {
                // Checks if its enabled
                if (component.Enabled)
                {
                    // Calls update
                    component.Update(gameTime);
                }
            }

            // Updates on game time
            base.Update(gameTime);
        }
    }
}