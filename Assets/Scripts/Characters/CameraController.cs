using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;

    private Vector2 _center;
    private Vector3 _offset = new Vector3(0, 1f, -10f);

    private Camera _camera;

    private float _distance;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        _center = Vector2.Lerp(_playerOne.transform.position, _playerTwo.transform.position, 0.5f);
        _distance = Vector2.Distance(_playerOne.transform.position, _playerTwo.transform.position);
        
        if (_distance > 7f)
        {
            float size = _distance;

            if (size <= 20) _camera.orthographicSize = size;
        }

        transform.position = new Vector3(_center.x, _center.y + _offset.y, _offset.z);
    }
}
