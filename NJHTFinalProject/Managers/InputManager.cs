using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace NJHTFinalProject.Managers
{
    public static class InputManager
    {
        private static Dictionary<Keys, char> inputs = new Dictionary<Keys, char>()
        {
            { Keys.A, 'A' },
            { Keys.B, 'B' },
            { Keys.C, 'C' },
            { Keys.D, 'D' },
            { Keys.E, 'E' },
            { Keys.F, 'F' },
            { Keys.G, 'G' },
            { Keys.H, 'H' },
            { Keys.I, 'I' },
            { Keys.J, 'J' },
            { Keys.K, 'K' },
            { Keys.L, 'L' },
            { Keys.M, 'M' },
            { Keys.N, 'N' },
            { Keys.O, 'O' },
            { Keys.P, 'P' },
            { Keys.Q, 'Q' },
            { Keys.R, 'R' },
            { Keys.S, 'S' },
            { Keys.T, 'T' },
            { Keys.U, 'U' },
            { Keys.V, 'V' },
            { Keys.W, 'W' },
            { Keys.X, 'X' },
            { Keys.Y, 'Y' },
            { Keys.Z, 'Z' }
        };

        public static char GetInputCharacter(Keys key)
        {
            if (inputs.ContainsKey(key))
            {
                return inputs[key];
            }
            else
            {
                return '\0';
            }
        }
    }
}
