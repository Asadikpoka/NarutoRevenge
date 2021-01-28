using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private float enemyMoveSpeed;
    public int damage = 1;
    private Transform _playerTarget;

    private void Start()
    {
        _playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, _playerTarget.position, enemyMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Move>().health -= damage;
            Destroy(gameObject);
        }
    }
}
