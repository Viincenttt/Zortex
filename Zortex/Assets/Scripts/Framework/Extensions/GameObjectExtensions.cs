using UnityEngine;

namespace Assets.Scripts.Framework.Extensions {
    public static class GameObjectExtensions {
        public static bool IsDestroyed(this GameObject gameObject) {
            return gameObject == null || gameObject.Equals(null);
        }
    }
}