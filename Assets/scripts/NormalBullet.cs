using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    #region General

    private Rigidbody _rb;
    private float _bulletSpeed = 20;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }

    #endregion
    #region Desactivación

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 7)
        {
            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(5);
            }
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
