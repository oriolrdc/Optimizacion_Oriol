using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.AddForce(transform.forward.normalized * _speed, ForceMode.Impulse);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(10);
            }
            gameObject.SetActive(false);
        }
    }
}