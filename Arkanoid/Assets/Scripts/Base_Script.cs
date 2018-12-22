using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Script : MonoBehaviour
{
    
    public float baseVelocidad = 0.5f;
    private float maxRange = 0.55f;
    
    Vector3 playerPos = new Vector3(0, -0.2f, 0);


    private Vector3 inicialPosition;
    private Vector3 inicialPositionBall;
    void Awake(){
        inicialPosition = transform.position;
        inicialPositionBall = transform.GetChild(0).transform.position;
    }

    
    void Update()
    {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * baseVelocidad);
        playerPos = new Vector3(Mathf.Clamp(xPosition,-maxRange,maxRange),-0.2f,0);
        transform.position = playerPos;

        if(Input.GetKeyDown(KeyCode.R)){
            Reset();
        }

    }

    public void Reset(){
        transform.position = inicialPosition;
        transform.GetChild(0).position = inicialPositionBall;
        transform.GetChild(0).gameObject.SetActive(true);
    }

}
