using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _target;

    public void InitializeSpawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position + Vector3.up, Quaternion.identity);
        enemy.GetTargetPoint(_target.transform);
    }
}
