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
    public delegate void ResumeAction();


    public event ResetAction ResetBase;
    public event ResetGameAction ResetGame;
    public event StopAction StopGame;
    public event ResumeAction ResumeGame;
    

    private int score;
    private int hp;
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
        
    }

    void Start(){
        ResetMain();
        Canvas_script.instance.Lifes(hp);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && ResetGame != null){ // !inGame && 
            ResetMain();
            ResetGame();
            Canvas_script.instance.SetGameText("");
            Canvas_script.instance.Score(score);
            Canvas_script.instance.Lifes(hp);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && inGame && ResumeGame != null && StopGame != null){
            if(inPause){
                inPause = false;
                ResumeGame();
                Canvas_script.instance.SetGameText("");
            }else{
                inPause = true;
                StopGame();
                Canvas_script.instance.SetGameText("PAUSE");
            }
        }
    }

    private void ResetMain(){
        inGame = true;
        inPause = false;
        score = 0;
        hp = 12500;
        bricks = 54;
    }




 
    private void CheckGameOver(){
        if(hp <= 0){
            Debug.Log("GAME OVER");
            StopGame();
            Canvas_script.instance.SetGameText("Game Over");
            inGame = false;
        }
        else if(hp > 0 && bricks <= 0){
            Debug.Log("WIN GAME");
            StopGame();
            Canvas_script.instance.SetGameText("Congratulations!");
            inGame = false;
        }
    }


    public void LooseLife(){
        hp-= 2500;
        Canvas_script.instance.Lifes(hp);
        CheckGameOver();
        if(ResetBase != null && inGame)
            Invoke("ResetBaseDalay" ,2f);
    }

    private void ResetBaseDalay(){
        ResetBase();
    }

    public void PiezaRota(){
        bricks--;
        score += 3;
        
        if(hp > 150)
            hp -= 150;

        Canvas_script.instance.Score(score);
        Canvas_script.instance.Lifes(hp);
        CheckGameOver();
    }

    public void ShareMaxVelocity(float value){
       Canvas_script.instance.SetSliderMaxVelocity(value);
    }

    public void ShareVelocity(float value){
        Canvas_script.instance.SetSliderVelocity(value);
    }


}
