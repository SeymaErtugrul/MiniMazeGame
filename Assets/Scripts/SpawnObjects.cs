using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnObjects : MonoBehaviour
{
    public GameObject prefab; 
    public int poolSize; 

    private List<GameObject> pooledObjects; 
    private int nextObjectIndex = 0; 


    public GameObject Poison;

    public GameObject player;
    Vector3 Pos;
    public Camera cam;
    private void Start()
    {
        InitializePool();
        StartCoroutine("Spawn");
    }

   
    private void InitializePool()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
       
        GameObject obj = pooledObjects[nextObjectIndex];
        nextObjectIndex++;

        // Eğer havuzdaki nesnelerin sonuna geldiysek başa dön
        if (nextObjectIndex >= pooledObjects.Count)
        {
            nextObjectIndex = 0;
        }

        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        // Nesneyi havuza geri koy
        obj.SetActive(false);
    }


    IEnumerator Spawn()
    {

        for (int i = 0; i < poolSize; i++)
        {
            Pos.y = Random.RandomRange(-30, -20);
            Pos.x = Random.RandomRange(-20,35);
            Pos.z = 0;
            GetPooledObject().transform.position = Pos;
            GetPooledObject().SetActive(true);
        }
      
        yield return new WaitForSeconds(30f);

        Instantiate(Poison);

        for (int i = 0; i < poolSize; i++)
        {
            Pos.y = Random.RandomRange(-13, -20);
            Pos.x = Random.RandomRange(-20, 35);
            Pos.z = 0;
            GetPooledObject().transform.position = Pos;
            GetPooledObject().SetActive(true);
        }

   
        yield return new WaitForSeconds(30f);


    }
}
