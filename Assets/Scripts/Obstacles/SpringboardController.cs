using UnityEngine;

public class SpringboardController : MonoBehaviour
{
    [SerializeField] private float _springForce;
    [SerializeField] private GameObject _springIn;
    [SerializeField] private GameObject _springOut;

    private float _cooldown = 0.2f;
    private float _cooldownTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Launch(collision.gameObject);
    }

    private void Launch(GameObject player)
    {
        if (_cooldownTimer <= 0)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * _springForce, ForceMode2D.Force);
            _cooldownTimer = _cooldown;
            _springOut.SetActive(true);
            _springIn.SetActive(false);
        }
    }

    private void Update()
    {
        if (_cooldownTimer > 0)
            _cooldownTimer -= Time.deltaTime;
        else
        {
            _springOut.SetActive(false);
            _springIn.SetActive(true);
        }
    }
}
