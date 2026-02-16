using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private string[] _enemyType;
    [SerializeField] private bool _canSpawn; 
    [SerializeField] private float spawnTime;
    private float spawnCooldown = 1;
    
    void Update()
    {   
        spawnTime += Time.deltaTime;

        if(spawnTime >= spawnCooldown)
        {
            int NumeroElegido = Random.Range(0,_spawnPoints.Length);
            int NombreElegido = Random.Range(0,_enemyType.Length);
            Transform spawnElegido = _spawnPoints[NumeroElegido];
            string tipoElegido = _enemyType[NombreElegido];
            GameObject enemy = PoolManager.Instance.GetPooledObject(tipoElegido, spawnElegido.position, spawnElegido.rotation);
            enemy.SetActive(true);
            spawnTime = 0;
        }
    }
}


