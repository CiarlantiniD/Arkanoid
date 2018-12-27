using UnityEngine;

public class Shere_Script : MonoBehaviour
{
    public float ballInicialForce = 300f;
    public float maxBallVelocity = 25f;

    private bool playBall = false;
    private float timeD = 0;

    Rigidbody rb;
    Transform tBase;
    
    private Base_Script parentScript;

    void Awake ()
    {
        MainGame.instance.ResetBase += Reset;

        rb = GetComponent<Rigidbody>();
        tBase = transform.parent;
        parentScript = tBase.GetComponent<Base_Script>();
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && !playBall){

           transform.parent = null;
           playBall = true;
           rb.isKinematic = false;
           rb.AddForce(new Vector3(ballInicialForce,ballInicialForce,0));
           
       }

       if(playBall){
           

           timeD += Time.deltaTime;
           if(timeD > 3){
               AddVelocity();
               timeD = 0;
           }
       }
    }

    void OnTriggerEnter(){
        gameObject.SetActive(false);
        MainGame.instance.LooseLife();
    }

    void OnCollisionEnter(){
        
        AddVelocity();
    }


    private void AddVelocity(){       
        if(rb.velocity.magnitude < maxBallVelocity){
            rb.velocity = rb.velocity * 1.02f;
        }
    }





    public void Reset(){
        Debug.Log("SE RESETEO LA BOLA");
        rb.velocity = Vector3.zero;
        transform.parent = tBase;
        playBall = false;
        gameObject.SetActive(true);
        parentScript.RestartChildPosition();
    }
}
