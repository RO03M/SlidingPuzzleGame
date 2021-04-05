using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlidingPuzzle.src.libs {
    public class Sprite : Component {

        private Rectangle rect;
        private Texture2D texture;

        public Color color = Color.White;
        public string texturePath;
        public int x;
        public int y;
        public int width;
        public int height;

        public Vector2 Position {
            get {
                return new Vector2(x, y);
            } set {
                x = (int)value.X;
                y = (int)value.Y;
            }
        }

        public Rectangle Rect {
            get {
                return rect;
            }
        }

        public Sprite(string texturePath, int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.texturePath = texturePath;
            this.texture = Main.main.Content.Load<Texture2D>(texturePath);
        }

        public Sprite(Texture2D texture, int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.texture = texture;
        }

        public override void Update() {
            rect = new Rectangle(x, y, width, height);
        }

        public override void Draw() {
            Main.main._spriteBatch.Draw(texture, rect, color);
            base.Draw();
        }

    }
}
