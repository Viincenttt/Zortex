using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemySpawner : MonoBehaviour {
        [Header("Timing")]
        [SerializeField][Range(0, 10)] private float _timeBetweenSpawns = 2f;
        [SerializeField][Range(0, 5)] private float _timeBetweenSpawnsDecrementPerMinute = 1f;
        [SerializeField][Range(0, 3)] private float _minimumTimeBetweenSpawns = 0.25f;

        [Header("Bounds")]
        [SerializeField] [Range(1, 10)] private float _horizontalSpawnRadius = 5f;
        [SerializeField] [Range(1, 10)] private float _verticalSpawnRadius = 1.75f;

        [Header("Enemies")]
        [SerializeField] private GameObject[] _enemiesToSpawn;

        private void Start() {
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

        private void SpawnEnemy() {
            Vector3 spawnPosition = this.GetRandomSpawnPosition();
            GameObject enemyToSpawn = this.GetRandomEnemyToSpawn();
            GameObject.Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity, this.transform);
        }
        
        private GameObject GetRandomEnemyToSpawn() {
            int randomEnemyIndex = Random.Range(0, this._enemiesToSpawn.Length);
            return this._enemiesToSpawn[randomEnemyIndex];
        }

        private Vector3 GetRandomSpawnPosition() {
            float randomX = Random.Range(this.transform.transform.position.x - this._horizontalSpawnRadius, this.transform.position.x + this._horizontalSpawnRadius);
            float randomY = Random.Range(this.transform.transform.position.y - this._verticalSpawnRadius, this.transform.position.y + this._verticalSpawnRadius);
            float randomZ = Random.Range(this.transform.position.z - this._horizontalSpawnRadius, this.transform.position.z + this._horizontalSpawnRadius);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
}