using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent _btnDown;
    [SerializeField] private UnityEvent _btnUp;
    
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ButtonDown();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ButtonUp();
    }

    private void ButtonDown()
    {
        _renderer.enabled = false;
        _btnDown.Invoke();
    }

    private void ButtonUp()
    {
        _renderer.enabled = true;
        _btnUp.Invoke();
    }
}
