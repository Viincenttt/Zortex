﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemySpawner : MonoBehaviour {
        [Header("Timing")]
        [SerializeField][Range(0, 10)] private float _timeBetweenSpawns = 2f;
        [SerializeField][Range(0, 5)] private float _timeBetweenSpawnsDecrementPerMinute = 1f;
        [SerializeField][Range(0, 3)] private float _minimumTimeBetweenSpawns = 0.25f;

        [Header("Bounds")]
        [SerializeField] [Range(1, 10)] private float _xSpawnSize = 5f;
        [SerializeField] [Range(1, 10)] private float _ySpawnSize = 1.75f;
        [SerializeField] [Range(1, 10)] private float _zSpawnSize = 2f;

        [Header("Enemies")]
        [SerializeField] private GameObject[] _enemiesToSpawn;

        [Header("Effects")]
        [SerializeField] private GameObject _effectToSpawn;

        public void StartSpawningEnemies() {
            this.StartCoroutine(this.SpawnEnemies());
        }

        private void Update() {
            float timeBetweenSpawnsDecrementValue = this._timeBetweenSpawnsDecrementPerMinute / 60 * Time.deltaTime;
            this._timeBetweenSpawns -= timeBetweenSpawnsDecrementValue;
            this._timeBetweenSpawns = Mathf.Clamp(this._timeBetweenSpawns, this._minimumTimeBetweenSpawns, this._timeBetweenSpawns);
        }

        private IEnumerator SpawnEnemies() {
            while (true) {
                yield return new WaitForSeconds(this._timeBetweenSpawns);
                this.SpawnEnemy();
            }
        }

        private void SpawnEffect(Vector3 position) {
            GameObject.Instantiate(this._effectToSpawn, position, Quaternion.identity, this.transform);
        }

        private void SpawnEnemy() {
            Vector3 spawnPosition = this.GetRandomSpawnPosition();
            GameObject enemyToSpawn = this.GetRandomEnemyToSpawn();
            GameObject.Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity, this.transform);

            this.SpawnEffect(spawnPosition);
        }
        
        private GameObject GetRandomEnemyToSpawn() {
            int randomEnemyIndex = Random.Range(0, this._enemiesToSpawn.Length);
            return this._enemiesToSpawn[randomEnemyIndex];
        }

        private Vector3 GetRandomSpawnPosition() {
            return new Vector3(
                this.GetRandomSpawnCoordinate(this.transform.transform.position.x, this._xSpawnSize),
                this.GetRandomSpawnCoordinate(this.transform.transform.position.y, this._ySpawnSize),
                this.GetRandomSpawnCoordinate(this.transform.transform.position.z, this._zSpawnSize));
        }

        private float GetRandomSpawnCoordinate(float axisPosition, float spawnSize) {
            float minimumPosition = axisPosition - spawnSize / 2;
            float maximumPosition = axisPosition + spawnSize / 2;

            return Random.Range(minimumPosition, maximumPosition);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position, new Vector3(this._xSpawnSize, this._ySpawnSize, this._zSpawnSize));
        }
    }
}
