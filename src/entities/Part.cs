using SlidingPuzzle.src.libs;
using Microsoft.Xna.Framework;

namespace SlidingPuzzle.src.entities {
    public class Part : Entity {

        private Color color = Color.White;
        private Sprite thisSprite;
        private int width;
        private int height;
        private bool canMove = false;

        protected bool isMouseOver = false;

        public int x;
        public int y;
        public int xTable;
        public int yTable;

        int sNumber;

        public Part(int number) {
            this.sNumber = number;
        }

        public override void Update() {
            MouseOver();
            if (isMouseOver) {
                for (int i = 0; i < Table.besidesNull.Count; i++) {
                    if (Table.besidesNull[i].Equals(new Vector2(xTable, yTable))) {
                        color = Color.Green;
                        canMove = true;
                        break;
                    } else color = Color.Red;
                }
                ClickOver();
            } else color = Color.White;

            thisSprite.color = this.color;
            base.Update();
        }

        public void MouseOver() {
            if (thisSprite.Rect.Contains(MouseGet.Position())) isMouseOver = true;
            else isMouseOver = false;
        }

        public void ClickOver() {
            if (!MouseGet.LeftClick()) return;
            if (!canMove) return;
            Vector2 nullPosition = (Vector2)Table.NullPosition();
            Vector2 newPos = Table.TablePosToWindowPos(nullPosition);
            Table.tableEntities[xTable, yTable] = null;
            Table.tableEntities[(int)nullPosition.X, (int)nullPosition.Y] = sNumber;
            thisSprite.Position = newPos;
            x = (int)newPos.X;
            y = (int)newPos.Y;
            xTable = x / width;
            yTable = y / height;
        }

        public override void OnAddComponent() {
            thisSprite = this.GetComponent<Sprite>();
            if (thisSprite == null) return;

            this.x = thisSprite.x;
            this.y = thisSprite.y;
            this.width = thisSprite.width;
            this.height = thisSprite.height;

            xTable = x / width;
            yTable = y / height;

            base.OnAddComponent();
        }

        public override void Draw() {
            base.Draw();
            Main.main._spriteBatch.DrawString(Main.globalFont, sNumber.ToString(), new Vector2(x + width / 2, y + height / 2), Color.White);

        }

    }
}
