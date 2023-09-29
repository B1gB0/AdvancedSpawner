using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private bool isWork = true;

    private void Start()
    {
        Initialize(_enemy.gameObject);
        StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while(isWork)
        {
            if (TryGetObject(out GameObject enemyPrefab))
            {
                SetEnemy(enemyPrefab, transform.position);

                Enemy enemy = enemyPrefab.GetComponent<Enemy>();
                enemy.SetDirection(_target);

                yield return waitForSeconds;
            }
        }
    }
}