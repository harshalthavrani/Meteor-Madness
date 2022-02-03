using Microsoft.Xna.Framework;

namespace NJHTFinalProject
{
    public class Shared
    {
        public static Vector2 stage;

        public static Rectangle PlayerHitBox;

        public static int PlayerLives;

        public static int PlayerScore;

        public static int LastGameScore;

        public static string PlayerName;

        public static int GetPlayerScore()
        {
            return PlayerScore;
        }

        public static Rectangle GetBounds()
        {
            return new Rectangle(PlayerHitBox.X, PlayerHitBox.Y, 200, 250);
        }
    }
}