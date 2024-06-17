using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiple_object_pooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
       public string tag;
       public GameObject prefeb;
       public int size;
    }
    
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;

    // singleton //
    public static multiple_object_pooling instance;
    private void Awake() 
    {
       if(instance == null)
       {
          instance = this;
       }    
    }
    
    void Start()
    {
      poolDictionary = new Dictionary<string, Queue<GameObject>>();

      foreach (Pool pool in pools)
      {
        Queue<GameObject> objectpool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefeb);
            obj.SetActive(false);
            objectpool.Enqueue(obj);
        }

        poolDictionary.Add(pool.tag,objectpool);
      }    
    }

    public void spawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
       if(!poolDictionary.ContainsKey(tag))
       {
          Debug.LogWarning("Pool with tag" + tag + "Dosen't exist");
       }

       GameObject object_to_spawn = poolDictionary[tag].Dequeue();

       object_to_spawn.SetActive(true);
       object_to_spawn.transform.position = position;
       object_to_spawn.transform.rotation = rotation;
       
       //poolDictionary[tag].Enqueue(object_to_spawn);// this is used to auto return object to pool//
    }

    public void Return_to_Pool( string tag ,GameObject obj)// this fuction is call from where to remove or to return object//
    {
       poolDictionary[tag].Enqueue(obj);
       obj.SetActive(false);
    }

    
}
