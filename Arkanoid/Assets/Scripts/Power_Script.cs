using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Script : MonoBehaviour
{
    


    void Start()
    {
    }

   
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
    }

/*     void OnCollisionEnter(Collision collision){

         Debug.Log(collision.gameObject.name );

        if(collision.gameObject.name == "Base"){

            Destroy(this);
        }  
     } */

      void OnTriggerEnter(Collider col){

          Debug.Log(col.gameObject.name);

          Debug.Log("Atravezo el Trigger");
          gameObject.SetActive(false);
      }


}
