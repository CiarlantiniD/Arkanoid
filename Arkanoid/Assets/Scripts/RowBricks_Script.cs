using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBricks_Script : MonoBehaviour
{
    [SerializeField] private Transform brick = null;

    private float[] BricksPosition_1 = {-6.5f,-4.4f,-2.3f,-0.2f,1.9f,4f,6.1f}; //2.1f

    void Awake(){

        for (int i = 0; i < BricksPosition_1.Length; i++)
        {
            Transform temp;
            temp = Instantiate(brick,transform);
            temp.position = new Vector3(BricksPosition_1[i], transform.position.y, transform.position.z);
        }

    }

    void Start(){}
    void Update(){}
    
}
