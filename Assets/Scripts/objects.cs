using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) 
    {
      if(other.gameObject.CompareTag("ground")){
        StartCoroutine(remove_object());
      }
    }

    IEnumerator remove_object()
    {
      yield return new WaitForSeconds(1);
      multiple_object_pooling.instance.Return_to_Pool(gameObject.tag,this.gameObject);
    }
}
