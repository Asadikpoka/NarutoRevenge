using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance = null;
    
    [SerializeField] private GameObject _player;
    private Vector3 offset;
    
    [SerializeField] private float _top;
    [SerializeField] private float _bottom;
    [SerializeField] private float _right;
    [SerializeField] private float _left;

    void Start ()
    {
        instance = this;
        offset = transform.position - _player.transform.position;
    }
    
    void LateUpdate ()
    {
        var currentPosition = transform.position;
        
        currentPosition = _player.transform.position + offset;

        currentPosition.x = Mathf.Clamp(currentPosition.x, _left, _right);

        currentPosition.y = Mathf.Clamp(currentPosition.y, _bottom, _top);

        transform.position = currentPosition;
    }

    public void DisableScript()
    {
        gameObject.GetComponent<CameraController>().enabled = false;
    }
}