using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Script : MonoBehaviour
{

    private Text highScoreText;

    void Awake(){
        highScoreText = transform.GetChild(2).GetComponent<Text>();
        Score(PlayerPrefs.GetInt("highScore"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Game",LoadSceneMode.Single);
        }
    }

    private void Score(int scoreValue){

        string ZeroString = "";
        int ZerosInScore = 8 - scoreValue.ToString().Length;       

        for (int i = 0; i < ZerosInScore; i++){
            ZeroString = "0" + ZeroString; 
        }

        highScoreText.text = "High Score: " + ZeroString + scoreValue.ToString() + "00";
    }
}
