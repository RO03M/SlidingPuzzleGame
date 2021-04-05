using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlidingPuzzle.src.libs {
    public class Debug {

        public static List<string> logList = new List<string>();
        public static List<string> logOnceList = new List<string>();

        public SpriteFont font;

        public Debug() {
            font = Main.main.Content.Load<SpriteFont>("fonts/Debug");
        }

        public static void Log(object? text) {
            if (text == null) {
                logList.Add("null");
                return;
            }

            logList.Add(text.ToString());
        }

        public static void LogOnce(object? text) {
            if (text == null) {
                logOnceList.Add("null");
                return;
            }

            logOnceList.Add(text.ToString());
        }

        public void Update() {
            logList.Clear();
        }

        public void Draw() {
            List<string> mergeLog = logList.Concat(logOnceList).ToList();
            for (int i = 0; i < mergeLog.Count; i++) {
                try {
                    Main.main._spriteBatch.DrawString(font, mergeLog[i], new Vector2(0, i * font.LineSpacing), Color.Blue);
                } catch (System.ArgumentException e) {
                    Main.main._spriteBatch.DrawString(font, "Remove accents, no problem at all", new Vector2(0, i * font.LineSpacing), Color.White);
                }
            }
        }

    }
}
