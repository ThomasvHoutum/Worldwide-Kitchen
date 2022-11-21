using System.Collections;
using UnityEngine;

public class KitchenDoorController : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private GameObject _linkedDoor;
    [SerializeField] private GameObject _fadeUI;
    [SerializeField] private Camera _camera;

    private Animator _animator;
    private CameraController _cameraController;
    private bool _faded;
    private Vector3 _insideCamPos = new Vector3(179.5f, 5.43f, -10);

    private void Start()
    {
        _cameraController = _camera.GetComponent<CameraController>();
        _animator = _fadeUI.GetComponent<Animator>();
    }

    public void InteractDoor() { StartCoroutine(Fade()); }

    private IEnumerator Fade()
    {
        if (_faded == false) _animator.SetBool("Faded", true);
        else _animator.SetBool("Faded", false);

        if (_faded == false)
        {
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

            Vector2 _doorPos = _linkedDoor.transform.position;
            

            _player1.transform.position = new Vector2(_doorPos.x - 1.5f, _doorPos.y);
            _player2.transform.position = new Vector2(_doorPos.x + 1.5f, _doorPos.y);

            _faded = true;
            StartCoroutine(Fade());
            if (_linkedDoor.CompareTag("InsideDoor")) InsideView();
            else OutsideView();
        }
        else _faded = false;
    }

    private void InsideView()
    {
        _cameraController.enabled = false;
        _cameraController.gameObject.transform.position = _insideCamPos;
        _camera.orthographicSize = 3.7f;
    }

    private void OutsideView()
    {
        _camera.orthographicSize = 7.001f;
        _cameraController.enabled = true;
    }
}
