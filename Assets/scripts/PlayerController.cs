using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction _shootAction;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunPosition;

    void Awake()
    {
        _shootAction = InputSystem.actions["Attack"];
    }

    void Update()
    {
        if(_shootAction.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Instantiate(_bulletPrefab, _gunPosition.position, _gunPosition.rotation); //instantiate cutre que crea morralla

        GameObject bullet = PoolManager.Instance.GetPooledObject("balas", _gunPosition.position, _gunPosition.rotation);
        bullet.SetActive(true); //necesitas activarlo pq la funcion de pooling instance lo unico que hace es llevarlo a la posicion, por eso necesitas activarlo despues.
    }
}
