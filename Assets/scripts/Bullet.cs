using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private float _bulletSpeed = 10;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider Collider)
    {
        gameObject.SetActive(false);
    }
}
