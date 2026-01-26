using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable] //si no pones esto la clase no es visible en el inspector
    public class Pool //creamos una clase para poder crear mas de una pool con diferentes cosas
    {
        public string parentName;
        public GameObject prefab;
        public int poolSize;
        public List<GameObject> pooledObjects;
    }

    [SerializeField] private List<Pool> _pools;
    [SerializeField] private Dictionary<string, Pool> _poolsDictionary = new Dictionary<string, Pool>();

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        GameObject obj;
        foreach (Pool pool in _pools)
        {
            GameObject parent = new GameObject(pool.parentName); //crea un empty con el nombre de la variable que teniamos en cada caso (haciendo que cada uno tenga el suyo propio)

            for (int i = 0; i < pool.poolSize; i++)
            {
                obj = Instantiate(pool.prefab); //lo metes dentro de la variable obj para poder controlarlo
                obj.transform.SetParent(parent.transform); //le metes de hijo (igual que yo tengo de hijo al pelordo el muy sanchista)
                obj.SetActive(false); //Lo desactivas
                pool.pooledObjects.Add(obj); //Y lo metes en la lista
            }
        }

        foreach (Pool pool in _pools)
        {
            _poolsDictionary.Add(pool.parentName, pool);
        }
    }
    
    /*public GameObject GetPooledObject(int selectedPool, Vector3 position, Quaternion rotation) //el int de las condiciones es para saber a que pool quieres acceder :3
    {
        for (int i = 0; i < _pools[selectedPool].poolSize; i++)
        {
            if(!_pools[selectedPool].pooledObjects[i].activeInHierarchy)
            {
                GameObject objectToSpawn;
                objectToSpawn = _pools[selectedPool].pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }            
        }

        Debug.Log("No hay nada");
        return null;
    }*/

    public GameObject GetPooledObject(string poolName, Vector3 position, Quaternion rotation) //el int de las condiciones es para saber a que pool quieres acceder :3
    {
        for (int i = 0; i < _poolsDictionary[poolName].poolSize; i++)
        {
            if(!_poolsDictionary[poolName].pooledObjects[i].activeInHierarchy)
            {
                GameObject objectToSpawn;
                objectToSpawn = _poolsDictionary[poolName].pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }            
        }

        Debug.Log("No hay nada");
        return null;
    }
}
