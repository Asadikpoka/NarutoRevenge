using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public static EnemyFollow instance = null; 
    public GameObject enemy;
    [SerializeField] private float enemyMoveSpeed;
    public int damage = 1;
    private Transform _playerTarget;
    private Move _playerPosition;

    private void Start()
    {
        instance = this;
        _playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, _playerTarget.position, enemyMoveSpeed * Time.deltaTime);

        if (_playerPosition.transform.localScale.x == -0.7f)
        {
            transform.localScale = new Vector2(-1,1);
        }
        else
        {
            transform.localScale = new Vector2(1,1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Move>().health -= damage;
            Destroy(gameObject);
        }
    }

    
    /*
    public void EnemyLeft()
    {
        transform.localScale = new Vector2(-1,1);
    }

    public void EnemyRight()
    {
        transform.localScale = new Vector2(1,1);
    }
    */
}
