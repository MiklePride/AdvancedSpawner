using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField]private SpawnPoint[] _enemySpawnPoints;

    private float _pauseDuration = 2f;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(InitializeSpawn());
    }

    private IEnumerator InitializeSpawn()
    {
        var twoSeconds = new WaitForSeconds(_pauseDuration);

        while (true)
        {
            _enemySpawnPoints[GetRandomIndex(_enemySpawnPoints)].InitializeSpawn();

            yield return twoSeconds;
        }
    }

    private int GetRandomIndex(SpawnPoint[] spawnPoints)
    {
        int index = Random.RandomRange(0, spawnPoints.Length);

        return index;
    }
}
