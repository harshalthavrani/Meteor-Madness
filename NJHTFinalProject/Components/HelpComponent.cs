using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NJHTFinalProject.Components
{
    public class HelpComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _screenSize;
        private SpriteFont _regularFont;

        public HelpComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D background,
            Rectangle screenSize,
            SpriteFont regularFont) : base(game)
        {
            _spriteBatch = spriteBatch;
            _background = background;
            _screenSize = screenSize;
            _regularFont = regularFont;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, _screenSize, Color.White);

            string mouseHeader = "Mouse and Keyboard\n\n";
            string mouseControls = "W: Move up\nA: Left left\nS: Move down\nD: Move right\n\n\n";
            string controllerHeader = "Controller:\n\n";
            string controllerControls = "Left stick up: Move up\nLeft stick left: Move left\nLeft stick down: Move down\nLeft stick right: Move right\n" +
                "\nMeteor Madness is a survival game that summons a shining rock from the top of the screen, smashing into the floor \nand dealing damage " +
                "in an area of effect. In this game, the Player is in a spaceship and has to move his spaceship\n back and forth, left and right, to avoid" +
                " colliding with meteors. Here the point is not why can't WE destroy meteors? \nBut how long can you hold your spaceship with just three lives" +
                " and avoid colliding with meteors? So are you ready \nto show the world how competent you are? Gear up and launch your spaceship NOW!";

            _spriteBatch.DrawString(_regularFont, mouseHeader + mouseControls + controllerHeader + controllerControls, new Vector2(Shared.stage.X / 2 - 150, 250), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}