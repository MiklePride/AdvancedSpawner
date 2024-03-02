using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy InitializeSpawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position + Vector3.up, Quaternion.identity);

        return enemy;
    }
}
