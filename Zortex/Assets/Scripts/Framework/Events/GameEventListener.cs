﻿using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Framework.Events {
    public class GameEventListener : MonoBehaviour {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable() {
            this.Event.RegisterListener(this);
        }

        private void OnDisable() {
            this.Event.UnregisterListener(this);
        }

        public void OnEventRaised() {
            this.Response.Invoke();
        }
    }
}