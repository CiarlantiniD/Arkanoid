using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_script : MonoBehaviour
{
    public static Canvas_script instance = null;

    Text scoreText;
    void Awake()
    {
  if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        scoreText = transform.GetChild(0).GetComponent<Text>();
    }

    public void Score(int scoreValue){
        scoreText.text = scoreValue.ToString();
    }

}
