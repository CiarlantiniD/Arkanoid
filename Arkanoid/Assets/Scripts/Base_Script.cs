using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Script : MonoBehaviour
{
    
    public float baseVelocidad = 0.6f;
    public float maxRange = 8f;
    

    private Vector3 inicialPosition;
    private Vector3 inicialPositionBall;


    private bool inGame = true;
   
    void Awake(){
        MainGame.instance.ResetBase += Reset;
        MainGame.instance.ResetGame += Reset;
        MainGame.instance.StopGame += Stop;
        MainGame.instance.ResumeGame += Resume;

        inicialPosition = transform.position;
        inicialPositionBall = transform.GetChild(0).localPosition;
    }
    
    void Update()
    {   
        if(inGame){
            float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * baseVelocidad);
            transform.position = new Vector3(Mathf.Clamp(xPosition,-maxRange,maxRange), transform.position.y, 0);
        }
    }

    public void Reset(){
        inGame = false;
        transform.position = inicialPosition;
        Invoke("Delay",0.3f);        
    }
    void Delay(){inGame = true;}

    public void Stop(){
        inGame = false;
    }

    public void Resume(){
        inGame = true;
    }


   




    

}
