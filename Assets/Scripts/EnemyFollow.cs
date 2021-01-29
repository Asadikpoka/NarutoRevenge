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

        if (Move.instance.transform.position.x <= gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector2(-1f,1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(1f,1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager.instance.DecreaseScore();
            Destroy(gameObject);
        }
    }
}
