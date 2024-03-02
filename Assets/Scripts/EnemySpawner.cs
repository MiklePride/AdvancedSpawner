using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private SpawnPoint[] _enemySpawnPoints;
    [SerializeField] private Transform[] _players;

    private float _pauseDuration = 2f;

    private void Start()
    {
        StartCoroutine(InitializeSpawn());
    }

    private IEnumerator InitializeSpawn()
    {
        var twoSeconds = new WaitForSeconds(_pauseDuration);

        while (true)
        {
            int index = GetRandomIndex(_enemySpawnPoints);
            var enemy = _enemySpawnPoints[index].InitializeSpawn();
            enemy.GetTargetPoint(_players[index]);

            yield return twoSeconds;
        }
    }

    private int GetRandomIndex(SpawnPoint[] spawnPoints)
    {
        int index = Random.RandomRange(0, spawnPoints.Length);

        return index;
    }
}
