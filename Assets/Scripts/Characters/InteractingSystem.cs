using UnityEngine;
using UnityEngine.Events;

public class InteractingSystem : MonoBehaviour
{
    private Vector2 _innatePosition = new Vector2(0, -380);
    private float _textOffset = 65f;
    [SerializeField] private Transform _contentHolder;
    [SerializeField] private Transform _inactiveElements;
    [SerializeField] private RectTransform _interactPopup;
    [SerializeField] private RectTransform _interactPrePopup;
    [SerializeField] private UnityEvent _startInteraction;
    [SerializeField] private UnityEvent _stopInteraction;

    private bool _canInteract;
    private bool _currentlyInteracting;
    private int _collided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _collided++;
            if (_collided == 1) Invoke("ShowPrePopup", 0f);
            if (_collided == 2) Invoke("ShowPopup", 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _collided--;
            if (_collided == 1) Invoke("ShowPrePopup", 0f);      
            if (_collided == 0) Invoke("HidePopup", 0f);      
        }
    }

    private void ShowPrePopup()
    {
        _interactPopup.transform.SetParent(_inactiveElements.transform);
        _canInteract = false;
        _interactPrePopup.transform.SetParent(_contentHolder.transform);
    }

    private void ShowPopup()
    {
        _interactPopup.localPosition = new Vector2(_innatePosition.x, _innatePosition.y);
        for (int i = 0; i < _contentHolder.childCount; i++)
        {
            _interactPopup.localPosition = new Vector2(_interactPopup.localPosition.x, _interactPopup.localPosition.y + _textOffset);
        }
        _interactPrePopup.transform.SetParent(_inactiveElements.transform);
        _interactPopup.transform.SetParent(_contentHolder.transform);
        _canInteract = true;
    }

    private void HidePopup()
    {
        for (int i = 0; i < _contentHolder.childCount; i++)
        {
            if (i != 0)
            {
                RectTransform _transform = _contentHolder.GetChild(i).gameObject.GetComponent<RectTransform>();
                _transform.localPosition = new Vector2(_transform.localPosition.x, _transform.localPosition.y - _textOffset);
            }
        }

        _interactPopup.position = new Vector2(_innatePosition.x, _innatePosition.y);
        _interactPopup.transform.SetParent(_inactiveElements.transform);
        _interactPrePopup.transform.SetParent(_inactiveElements.transform);
        _canInteract = false;
        InteractionStopped();
    }

    private void Update()
    {
        if (!_canInteract) return;
        if (Input.GetKeyDown(KeyCode.Space))
            Invoke(_currentlyInteracting ? "InteractionStopped" : "InteractionStarted", 0f);
    }
    
    private void InteractionStarted()
    {
        _currentlyInteracting = true;
        _startInteraction.Invoke();
    }
    private void InteractionStopped()
    {
        _currentlyInteracting = false;
        _stopInteraction.Invoke();
    }
}
