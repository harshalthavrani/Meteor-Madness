using System;

namespace NJHTFinalProject
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var game = new GameScreen())
                game.Run();
        }
    }
}