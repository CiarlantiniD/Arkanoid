using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class MainGame : MonoBehaviour
{
    public static MainGame instance = null;

    public delegate void ResetAction();
    public delegate void ResetGameAction();
    public delegate void StopAction();
    public delegate void PauseAction(bool pauseStatus);


    public event ResetAction ResetBase;
    public event ResetGameAction ResetGame;
    public event StopAction StopGame;
    public event PauseAction PauseStatus;
    

    private int score;
    private int lifes;
    private int bricks;



    private bool inGame;
    private bool inPause;

    void Awake()
    {
         if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        ResetGame += ResetMain;
        ResetMain();


    }

    
    void Update()
    {
        if(!inGame && Input.GetKeyDown(KeyCode.R) && ResetGame != null){
            ResetGame();
        }
    }

    private void ResetMain(){
        inGame= true;
        score = 0;
        lifes = 3;
        bricks = 40;
    }




    private void GameOver(bool win){
        if(win){
            Debug.Log("WIN GAME");
        }
        else{
            Debug.Log("LOSE GAME");
        }
        inGame = false;
    }
    private void CheckGameOver(){
        if(lifes <= 0){
            GameOver(false);
        }
        else if(lifes > 0 && bricks <= 0){
            GameOver(true);
        }
    }


    public void LooseLife(){
        Debug.Log("Se Perdio una vida");
        lifes--;
        Canvas_script.instance.Lifes(lifes);
        CheckGameOver();
        if(ResetBase != null)
            ResetBase();
            //Invoke("Reset" ,1f);
    }

    public void PiezaRota(){
        bricks--;
        score += 3;
        Canvas_script.instance.Score(score);
        CheckGameOver();
    }


}
