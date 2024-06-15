using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float Upforce = 1f;
    public float SideForce = 1f;
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float xforce = Random.Range(-SideForce,SideForce);
        float yforce = Random.Range(Upforce/2f,Upforce);
        float zforce = Random.Range(-SideForce,SideForce);

        Vector3 force = new Vector3(xforce,yforce,zforce);
        rb.velocity = force;

    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("ground")){

            StartCoroutine(remove_cube());
           // Destroy(this.gameObject,2f);
        }
    }

    IEnumerator remove_cube()
    {
      yield return new WaitForSeconds(1);
      object_pooler.instance.Return_to_Pool(this.gameObject);
    }

}
