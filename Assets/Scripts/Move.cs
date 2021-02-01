using System;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using System.Collections.Generic;

public class Move : MonoBehaviour
{
    public static Move instance = null;
    public GameObject player;

    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombPosition;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private GameObject gameOver;
    
    public Transform bombTrailPosition;
    private List<Collider2D> _colliders2D = new List<Collider2D>();

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (HealthManager.instance._health <= 0)
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
        }
    }

    public void HealthDecrease()
    {
        int count = _colliders2D.Count;
        if (count >= 0)
            HealthManager.instance.DecreaseScore();
         
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            _colliders2D.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            _colliders2D.Remove(other);
        }
    }
}
