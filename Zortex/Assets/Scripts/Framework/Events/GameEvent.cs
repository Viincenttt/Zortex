using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Framework.Events {
    [CreateAssetMenu(menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject {
        private List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Raise() {
            for (int i = this._listeners.Count - 1; i >= 0; i--) {
                this._listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener) {
            this._listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener) {
            this._listeners.Remove(listener);
        }
    }
}