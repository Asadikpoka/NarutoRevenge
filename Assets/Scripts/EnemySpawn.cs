using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private float startSpawTime;
    private float _timeBtwSpawn;

    private void Start()
    {
        _timeBtwSpawn = startSpawTime;
    }

    private void Update()
    {
        if (_timeBtwSpawn <= 0)
        {
            int randPosition = Random.Range(0, spawnPosition.Length - 1);
            Instantiate(enemy, spawnPosition[randPosition].position, Quaternion.identity);
            _timeBtwSpawn = startSpawTime;
        }
        else
        {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }
}
