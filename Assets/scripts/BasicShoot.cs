using UnityEngine;
using System.Collections;

public class BasicShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shooter;
    [SerializeField] private bool _canShoot = true;

    void Update()
    {
        if(_canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        _canShoot = false;
        GameObject EnemyBullet = PoolManager.Instance.GetPooledObject("enemyBullets", _shooter.position, _shooter.rotation);
        EnemyBullet.SetActive(true);
        yield return new WaitForSeconds(3);
        _canShoot = true;
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
