using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class object_pooler : MonoBehaviour
{
   
    public static object_pooler instance;// singleton instance//

    [SerializeField] private GameObject cube_prefeb;
    private Queue<GameObject> cube_pool = new Queue<GameObject>(); 
    [SerializeField] private int cube_pool_Size;

    private void Awake() 
    {
       // reference instance to this class // 
       if(instance == null){
        instance = this;
       }
    }

    void Start()
    {
        // creating the gameobject and store in Queue and disable the object//
        for (int i = 0; i < cube_pool_Size ; i++)
        {
            GameObject obj = Instantiate(cube_prefeb);
            cube_pool.Enqueue(obj);
            obj.SetActive(false);
        }
            
    }
    
    // call the fuction from where to spawn by using "singleton instance"//
    public GameObject GetCube_FromPool()
    {
        if(cube_pool.Count > 0){

           GameObject cube = cube_pool.Dequeue();// use the gameobject and out from queue//
           cube.SetActive(true);
           return cube;
        }
        else{
             
            //for adding more prefebs if the queue is empty//
            GameObject cube = Instantiate(cube_prefeb);
            return cube;   
        }
    }
    
    // call the function for destroy or to remove the object from scene by using "Singleton instance"//
    public void Return_to_Pool(GameObject obj)
    {
       cube_pool.Enqueue(obj);
       obj.SetActive(false);
    }
}
