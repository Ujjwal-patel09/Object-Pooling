using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class object_spawner : MonoBehaviour
{
    [SerializeField] private Transform cube_spawner;
    [SerializeField] private Transform sphere_spawner;
    [SerializeField] private Transform capsule_spawner;
    [SerializeField] private Transform cylinder_spawner;
    [SerializeField] private Transform plane_spawner;    

    private void Update() 
    {
       /* // used in single object pooling//
       GameObject cube_ = object_pooler.instance.GetCube_FromPool();
       cube_.transform.position = transform.position;
       cube_.transform.rotation = transform.rotation;*/
       
       // used in multiple obeject pooling system//
       // spawn cube//
       multiple_object_pooling.instance.spawnFromPool("cube",cube_spawner.transform.position,Quaternion.identity);
       
       // spawn sphere //
       multiple_object_pooling.instance.spawnFromPool("sphere",sphere_spawner.transform.position,Quaternion.identity);

        // spawn capsule //
       multiple_object_pooling.instance.spawnFromPool("capsule",capsule_spawner.transform.position,Quaternion.identity);

        // spawn cylinder //
       multiple_object_pooling.instance.spawnFromPool("cylinder",cylinder_spawner.transform.position,Quaternion.identity);

        // spawn plane //
       multiple_object_pooling.instance.spawnFromPool("cube",plane_spawner.transform.position,Quaternion.identity);
    }

}
