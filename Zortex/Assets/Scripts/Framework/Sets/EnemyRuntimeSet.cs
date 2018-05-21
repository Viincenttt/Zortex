﻿using Assets.Scripts.Actors.Enemy;
using UnityEngine;

namespace Assets.Scripts.Framework.Sets {
    [CreateAssetMenu(menuName = "Sets/EnemySet")]
    public class EnemyRuntimeSet : RuntimeSet<BaseEnemy> { }
}