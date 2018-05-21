using UnityEngine;

namespace Assets.Scripts.Actors.Enemy.Behaviour {
    public abstract class BaseEnemyBehaviour : ScriptableObject {
        public abstract void UpdateState(Enemy enemy);
    }
}