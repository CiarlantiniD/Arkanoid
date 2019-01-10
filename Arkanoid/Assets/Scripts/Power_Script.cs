using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Script : MonoBehaviour
{
    [SerializeField] private int addHP = 200;
    [SerializeField] private int loseHP = 200;
    [SerializeField] private Material powerUpMaterial = null;
    [SerializeField] private Material powerDwonMaterial = null;

    delegate void ActionPower();
    ActionPower action;


    private bool inGame = true;

    private Renderer ren;

    void Awake(){
        MainGame.instance.StopGame += Stop;
        MainGame.instance.ResumeGame += Resume;
        MainGame.instance.ResetGame += Restart;

        ren = GetComponent<Renderer>();

        if(Random.Range(0,100) < 50)
            SetPowerUp();
        else
            SetPowerDwon();
    }

    void Update()
    {
        if(inGame) transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
    }

    private void SetPowerUp(){
        ren.material = powerUpMaterial;
        action = AddHPAction;
    }

    private void SetPowerDwon(){
        ren.material = powerDwonMaterial;
        action = LoseHPAction;
    }

     void OnTriggerEnter(Collider col){
         
        if(col.gameObject.name == "Base"){
            action();
            gameObject.SetActive(false);
        }
        else if (col.gameObject.name == "Dead"){
            gameObject.SetActive(false);
        }
    }

    private void Stop(){
        inGame = false;
    }

    private void Resume(){
        inGame = true;
    }

    private void Restart(){
        gameObject.SetActive(false);
        //Destroy(this);
    }



    private void AddHPAction(){
        MainGame.instance.AddHP(addHP);
    }

     private void LoseHPAction(){
        MainGame.instance.LoseHP(loseHP);
    }

}
