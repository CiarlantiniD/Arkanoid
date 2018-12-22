using UnityEngine;

public class Shere_Script : MonoBehaviour
{
    public float ballInicialForce = 20f;
    private bool playBall = false;
    private float timeD = 0;


    Rigidbody rb;


    Transform parentBall;
    
    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        parentBall = transform.parent;
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

           if(timeD > 5){
               rb.velocity = rb.velocity * 1.2f;
               timeD = 0;
           }
       }
    }

    void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
        transform.parent = parentBall;
        playBall = false;
        gameObject.SetActive(false);
        MainGame.instance.LooseLife();
    }

    


}
