using System.Collections.Generic;
using System.Linq;

using SlidingPuzzle.src.libs;

namespace SlidingPuzzle.src.entities {
    public class Entity : Component {

        public List<Component> entityComponents = new List<Component>();

        public Entity() {
            Start();
        }

        public void AddComponent(Component component) {
            componentList.Add(component);
            OnAddComponent();
        }

        public void RemoveComponent(Component component) {
            componentList.Remove(component);
        }

        public virtual void OnAddComponent() {}

        public T GetComponent<T>() where T : Component {
            var component = componentList.FirstOrDefault(item => item.GetType() == typeof(T));
            if (component != null) return (T)component;
            return null;
        }


    }
}
