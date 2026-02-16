using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour, IDamageable
{
    private InputAction _shootLAction;
    private InputAction _shootRAction;
    [SerializeField] private Transform _leftGunPosition;
    [SerializeField] private Transform _rightGunPosition;
    [SerializeField] private GameObject _bulletPrefab;

    private InputAction _move;
    private Vector2 _moveInput;
    private Rigidbody _rb;
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] float _health = 20;

    void Awake()
    {
        _shootLAction = InputSystem.actions["AttackLeft"];
        _shootRAction = InputSystem.actions["AttackRight"];
        _move = InputSystem.actions["Move"];
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveInput = _move.ReadValue<Vector2>();

        if(_shootLAction.WasPressedThisFrame())
        {
            ShootLeft();
        }

        if(_shootRAction.WasPressedThisFrame())
        {
            StartCoroutine(ShootRight());
        }

        Movement();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);
        _rb.linearVelocity = direction.normalized * _movementSpeed;
    }

    void ShootLeft()
    {
        //Instantiate(_bulletPrefab, _gunPosition.position, _gunPosition.rotation); //instantiate cutre que crea morralla

        GameObject bullet = PoolManager.Instance.GetPooledObject("balas", _leftGunPosition.position, _leftGunPosition.rotation);
        bullet.SetActive(true); //necesitas activarlo pq la funcion de pooling instance lo unico que hace es llevarlo a la posicion, por eso necesitas activarlo despues.
    }

    IEnumerator ShootRight()
    {
        //Instantiate(_bulletPrefab, _gunPosition.position, _gunPosition.rotation); //instantiate cutre que crea morralla

        GameObject bullet = PoolManager.Instance.GetPooledObject("balas", _rightGunPosition.position, _rightGunPosition.rotation);
        bullet.SetActive(true); //necesitas activarlo pq la funcion de pooling instance lo unico que hace es llevarlo a la posicion, por eso necesitas activarlo despues.
        yield return new WaitForSeconds(1);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
