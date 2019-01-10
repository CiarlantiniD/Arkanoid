using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas_Script : MonoBehaviour
{
    [SerializeField] private Transform powerUp = null;
    [SerializeField] private float probability = 18f;
    private float randPowerUP;

    void Start()
    {
        MainGame.instance.ResetGame += ResetBrick;
        randPowerUP = Random.Range(0,probability +2);
    }

     void OnCollisionEnter (Collision other){
         MainGame.instance.PiezaRota();

        if(randPowerUP > probability){
            Instantiate(powerUp,transform.position,Quaternion.Euler(0,0,90));
        }

         gameObject.SetActive(false);
     }

     public void ResetBrick(){
         gameObject.SetActive(true);
     }

}
