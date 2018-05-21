using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private GameObject[] _enemiesToSpawn;
        [SerializeField] private float _timeBetweenSpawns = 2f;
        [SerializeField] private float _horizontalSpawnRadius = 5f;
        [SerializeField] private float _verticalSpawnRadius = 5f;

        private void Start() {
            this.StartCoroutine(this.SpawnEnemies());
        }

        private void Update() {
            
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