using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public static MainGame instance = null;
    
    int score = 0;

    void Awake()
    {
         if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);



    }

    
    void Update()
    {
        
    }

    public void LooseLife(){
        Debug.Log("Se Perdio una vida");
    }

    public void PiezaRota(){
        score += 3;
        Canvas_script.instance.Score(score);
    }
}
