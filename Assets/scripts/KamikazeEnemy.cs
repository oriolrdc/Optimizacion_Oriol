using UnityEngine;

public class KamikazeEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] private float _health = 10;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        _agent.SetDestination(_player.position);
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

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
