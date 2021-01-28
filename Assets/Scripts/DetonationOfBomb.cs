using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonationOfBomb : MonoBehaviour
{
    [SerializeField] private float bombLifeTime;
    [SerializeField] private GameObject bombParticle;
    [SerializeField] private GameObject bombTrail;
    private Move _bombTrailParent;
    private List<Collider2D> _colliders2D = new List<Collider2D>();
    
    void Start()
    {
        _bombTrailParent = FindObjectOfType<Move>();
        StartCoroutine(PlayParticle());
        Destroy(gameObject, bombLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _colliders2D.Add(other);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _colliders2D.Remove(other);
        }
    }

    IEnumerator PlayParticle()
    {
        yield return new WaitForSeconds(1.3f);
        bombParticle.SetActive(true);
        bombTrail.SetActive(true);
        bombTrail.transform.SetParent(_bombTrailParent.bombTrailPosition);

        int count = _colliders2D.Count;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(_colliders2D[i].gameObject);
                ScoreManager.instance.IncreaseScore();
            }
        }

    }
}



    /*
    public void SetMoveComponent(Move move)
    {
        _endParent = move;
    }
    */