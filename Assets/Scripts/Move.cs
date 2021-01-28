using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class Move : MonoBehaviour
{
    
    public GameObject player;

    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombPosition;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private Text healthDisplay;
    [SerializeField] private GameObject gameOver;
    public int health = 3;
    public Transform bombTrailPosition;
    
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
            CameraController.instance.DisableScript();
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (player.transform.position.x > -9f)
            {
                player.transform.Translate(Time.deltaTime * playerMoveSpeed * Vector2.left);
                player.transform.localScale = new Vector2(0.7f, 0.7f);
            }
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (player.transform.position.x < 9f)
            {
                player.transform.Translate(Time.deltaTime * playerMoveSpeed * Vector2.right);
                player.transform.localScale = new Vector2(-0.7f, 0.7f);
            }
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (player.transform.position.y < 8f)
            {
                player.transform.Translate(Time.deltaTime * playerMoveSpeed * Vector2.up);
            }
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (player.transform.position.y > -8f)
            {
                player.transform.Translate(Time.deltaTime * playerMoveSpeed * Vector2.down);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, bombPosition.position, bombPosition.rotation);
            
            /*
            DetonationOfBomb bomb = Instantiate(_bomb, _bombPosition.position, _bombPosition.rotation).GetComponent<DetonationOfBomb>();
            bomb.SetMoveComponent(this);
            */
        }
    }
}
