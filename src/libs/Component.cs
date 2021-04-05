using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

//A component have Update and Draw methods for each entity

namespace SlidingPuzzle.src.libs {

    public class Component {

        protected List<Component> componentList = new List<Component>();

        public int entityID;

        public void Start() {
            entityID = CompDrawer.components.Count;
            CompDrawer.components.Add(entityID, this);
        }

        public virtual void Update() {
            for (int i = 0; i < componentList.Count; i++) {
                componentList[i].Update();
            }
        }

        public virtual void Draw() {
            for (int i = 0; i < componentList.Count; i++) {
                componentList[i].Draw();
            }
        }

    }
}
