using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Framework.Sets {
    public abstract class RuntimeSet<T> : ScriptableObject {
        public List<T> Items = new List<T>();

        public void Add(T thing) {
            if (!this.Items.Contains(thing)) {
                this.Items.Add(thing);
            }
        }

        public void Remove(T thing) {
            if (this.Items.Contains(thing)) {
                this.Items.Remove(thing);
            }
        }
    }
}