using System.Collections.Generic;
using System.Linq;

namespace SlidingPuzzle.src.libs {
    public class CompDrawer {

        public static Dictionary<int, Component> components = new Dictionary<int, Component>();

        public void Update() {
            for (int i = 0; i < components.Count; i++) {
                var component = components.ElementAt(i);
                component.Value.Update();
            }
        }

        public void Draw() {
            for (int i = 0; i < components.Count; i++) {
                var component = components.ElementAt(i);
                component.Value.Draw();
            }
        }

    }
}
