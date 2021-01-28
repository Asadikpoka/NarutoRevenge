using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 offset;

    void Start ()
    {
        offset = transform.position - _player.transform.position;
    }
    void LateUpdate ()
    { 
        transform.position = _player.transform.position + offset;
    }
}