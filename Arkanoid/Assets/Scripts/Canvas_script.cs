using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_script : MonoBehaviour
{
    public static Canvas_script instance = null;

    private Text scoreText;
    private Text lifes;
    private Slider lifesSlider;
    private Text gameText;

    void Awake(){
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        scoreText = transform.GetChild(1).GetComponent<Text>();
        lifes = transform.GetChild(2).GetComponent<Text>();
        lifesSlider = transform.GetChild(3).GetComponent<Slider>();
        gameText = transform.GetChild(4).GetComponent<Text>();

        gameText.text = "";
    }

    public void Score(int scoreValue){

        string ZeroString = "";
        int ZerosInScore = 8 - scoreValue.ToString().Length;       

        for (int i = 0; i < ZerosInScore; i++){
            ZeroString = "0" + ZeroString; 
        }

        scoreText.text = ZeroString + scoreValue.ToString() + "00";
    }


    public void Lifes(int lifesValue){
        lifes.text = "Lifes: " + lifesValue;
        lifesSlider.value = lifesValue;
    }


    public void SetGameText(string textValue){
        gameText.gameObject.SetActive(true);
        gameText.text = textValue;
    }


}
