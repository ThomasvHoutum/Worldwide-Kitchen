using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{
    [Header("When lever turns on")]
    [SerializeField] private UnityEvent FlickOn;
    [Header("When lever turns off")]
    [SerializeField] private UnityEvent FlickOff;

    private GameObject _onSprite;
    private GameObject _offSprite;

    // false = off, true = on
    private bool _state;

    private void Awake()
    {
        _onSprite = transform.GetChild(1).gameObject;
        _offSprite = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        FlickOff.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _state = !_state;
        if (_state)
        {
            _onSprite.SetActive(true);
            _offSprite.SetActive(false);

            FlickOn.Invoke();
        }
        else
        {
            _onSprite.SetActive(false);
            _offSprite.SetActive(true);
            FlickOff.Invoke();
        }
    }
}
