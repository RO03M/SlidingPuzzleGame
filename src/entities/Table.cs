using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SlidingPuzzle.src.libs;

namespace SlidingPuzzle.src.entities {
    public class Table : Entity{

        public static int?[,] tableEntities; //Here is where the information about the order of the parts lies
        public List<Part> parts = new List<Part>();
        public static Vector2 tableSize = new Vector2(4, 4); //here is just the size of the table in form of a vector2
        public static List<Vector2> besidesNull = new List<Vector2>();

        public int width;
        public int height;

        public Table(int width, int height) {
            this.width = width;
            this.height = height;

            tableEntities = new int?[(int)tableSize.X, (int)tableSize.Y];
            PopulateTable();
        }

        public void PopulateTable() {
            int num = 1;
            int partWidth = (int)(width / tableSize.X);
            int partHeight = (int)(height / tableSize.X);

            for (int y = 0; y < tableSize.Y; y++) {
                for (int x = 0; x < tableSize.X; x++) {
                    int maxValue = (int)(tableSize.X * tableSize.Y);
                    if (num == maxValue) tableEntities[x, y] = null;
                    else {
                        tableEntities[x, y] = num;

                        Part tempPart = new Part(num);
                        tempPart.AddComponent(new Sprite("textures/piece", x * partWidth, y * partHeight, partWidth, partHeight));

                        parts.Add(tempPart);
                    }
                    num++;
                }
            }
        }

        public override void Update() {
            besidesNull = BesidesNull((Vector2)NullPosition());
            //for (int x = 0; x < tableSize.X; x++) {
            //    for (int y = 0; y < tableSize.X; y++) {
            //        Debug.Log(tableEntities[y, x]);
            //    }
            //}
            base.Update();
        }

        public static Vector2? NullPosition() {
            for (int x = 0; x < tableSize.X; x++) {
                for (int y = 0; y < tableSize.Y; y++) {
                    if (tableEntities[x, y] == null) return new Vector2(x, y);
                }
            }
            return null;
        }

        public List<Vector2> BesidesNull(Vector2 nullPos) {
            if (nullPos == null) return null;
            List<Vector2> besides = new List<Vector2>();

            if (nullPos.Y > 0) { //UP
                Vector2 upPart = new Vector2(nullPos.X, nullPos.Y - 1);
                besides.Add(upPart);
            }
            if (nullPos.X < tableSize.X - 1) { //RIGHT
                Vector2 rightPart = new Vector2(nullPos.X + 1, nullPos.Y);
                besides.Add(rightPart);
            }
            if (nullPos.Y < tableSize.Y - 1) { //DOWN
                Vector2 downPart = new Vector2(nullPos.X, nullPos.Y + 1);
                besides.Add(downPart);
            } 
            if (nullPos.X > 0) { //LEFT
                Vector2 leftPart = new Vector2(nullPos.X - 1, nullPos.Y);
                besides.Add(leftPart);
            }

            return besides;
        }

        public static Vector2 TablePosToWindowPos(int x, int y) {
            int screenX = x * (int)(Main.main.GetWidth / tableSize.X);
            int screenY = y * (int)(Main.main.GetHeight / tableSize.Y);
            Vector2 position = new Vector2(screenX, screenY);
            return position;
        }

        public static Vector2 TablePosToWindowPos(Vector2 pos) {
            int xTemp = (int)pos.X;
            int yTemp = (int)pos.Y;
            int screenX = xTemp * (int)(Main.main.GetWidth / tableSize.X);
            int screenY = yTemp * (int)(Main.main.GetHeight / tableSize.Y);
            Vector2 position = new Vector2(screenX, screenY);
            return position;
        }

    }
}
