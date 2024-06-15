using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_spawner : MonoBehaviour
{
    //public GameObject cube_prefeb;

    private void Update() 
    {
       GameObject cube_ = object_pooler.instance.GetCube_FromPool();
       cube_.transform.position = transform.position;
       cube_.transform.rotation = transform.rotation;
       //Instantiate(cube_prefeb,transform.position,transform.rotation); 
    }

   
    
}
