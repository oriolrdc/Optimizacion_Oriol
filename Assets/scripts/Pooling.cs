using UnityEngine;
using System.Collections.Generic;

public class Pooling : MonoBehaviour
{
    public static Pooling Instance;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<GameObject> _pooledObjects;
    [SerializeField] private string _parentName;

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
        GameObject parent = new GameObject(_parentName);
        for (int i = 0; i < _poolSize; i++)
        {
            obj = Instantiate(_prefab); //lo metes dentro de la variable obj para poder controlarlo
            obj.transform.SetParent(parent.transform); //le metes de hijo (igual que yo tengo de hijo al pelordo el muy sanchista)
            obj.SetActive(false); //Lo desactivas
            _pooledObjects.Add(obj); //Y lo metes en la lista
        }
    }

    public GameObject GetPooledObject(Vector3 position, Quaternion rotation) //Instantiete personalizado raro
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy) //comprueba si esta desactivado
            {
                GameObject objectToSpawn;
                objectToSpawn = _pooledObjects[i]; //Metes el objeto en una variable apra poder modificarlo again
                objectToSpawn.transform.position = position; //el segundo position viene de las condiciones de la funcion
                objectToSpawn.transform.rotation = rotation; //lo mismo que con el position
                return objectToSpawn; //return necesario para la funcion para que sepa que coño tiene que instanciar
            }
        }

        Debug.Log("No hay balas disponibles para disparar");
        return null; //si el bucle se acaba y no hay objetos return null para que de error y tal.
    }
}
