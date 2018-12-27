using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas_Script : MonoBehaviour
{

    void Awake()
    {
        //MainGame.instance.ResetGame += ResetBrick;
    }

     void OnCollisionEnter (Collision other){
         MainGame.instance.PiezaRota();
         gameObject.SetActive(false);
     }

     public void ResetBrick(){
         gameObject.SetActive(true);
     }

}
