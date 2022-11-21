using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentification : MonoBehaviour
{
    [SerializeField] private GameObject _playerToFollow;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _playerToFollow.transform.position + _offset;
    }
}
