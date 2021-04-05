using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SlidingPuzzle.src.libs {
    public static class MouseGet {

        public static Point Position() {
            return Mouse.GetState(Main.main.Window).Position;
        }

        public static bool LeftClick() {
            return Mouse.GetState(Main.main.Window).LeftButton == ButtonState.Pressed;
        }

    }
}
