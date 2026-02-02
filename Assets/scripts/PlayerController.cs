using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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
            ShootRight();
        }

        Movement();
    }

    void Movement()
    {
        _rb.linearVelocity = _moveInput * _movementSpeed;
    }

    void ShootLeft()
    {
        //Instantiate(_bulletPrefab, _gunPosition.position, _gunPosition.rotation); //instantiate cutre que crea morralla

        GameObject bullet = PoolManager.Instance.GetPooledObject("balas", _leftGunPosition.position, _leftGunPosition.rotation);
        bullet.SetActive(true); //necesitas activarlo pq la funcion de pooling instance lo unico que hace es llevarlo a la posicion, por eso necesitas activarlo despues.
    }

    void ShootRight()
    {
        //Instantiate(_bulletPrefab, _gunPosition.position, _gunPosition.rotation); //instantiate cutre que crea morralla

        GameObject bullet = PoolManager.Instance.GetPooledObject("balas", _rightGunPosition.position, _rightGunPosition.rotation);
        bullet.SetActive(true); //necesitas activarlo pq la funcion de pooling instance lo unico que hace es llevarlo a la posicion, por eso necesitas activarlo despues.
    }
}
