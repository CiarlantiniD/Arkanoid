using UnityEngine;

public class Shere_Script : MonoBehaviour
{
    [SerializeField] private float ballInicialForce = 300f;
    [SerializeField] private float maxBallVelocity = 20f;
    [SerializeField] private bool addVelocityBall = true;
    private float trailBall = 0.4f;

    private bool playBall = false;
    private bool stopBall = false;
    private float timeD = 0;


    private Rigidbody rb;

    private Transform parentBall;
    private Vector3 localPositionBall;
    private TrailRenderer trail;
    private Vector3 lastVelocity;

    void Awake ()
    {
        MainGame.instance.ResetBase += Reset;
        MainGame.instance.ResetGame += Reset;
        MainGame.instance.StopGame += Stop;
        MainGame.instance.ResumeGame += Resume;

        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        trail.startWidth = 0;
        
        parentBall = transform.parent;
        localPositionBall = transform.localPosition;

        
    }

    void Start(){
        MainGame.instance.ShareMaxVelocity(maxBallVelocity);
        MainGame.instance.ShareVelocity(rb.velocity.magnitude);
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && !playBall && !stopBall){

           transform.parent = null;
           playBall = true;
           rb.isKinematic = false;
           //trail.Clear();
           trail.startWidth = trailBall;
           rb.AddForce(new Vector3(ballInicialForce,ballInicialForce,0));
           MainGame.instance.SetStartGame();
       }

       if(playBall && !stopBall && addVelocityBall){
           timeD += Time.deltaTime;
           if(timeD > 3){
               AddVelocity();
               timeD = 0;
           }
       }
    }

    void OnTriggerEnter(Collider col){
        //trail.Clear();
        if(col.gameObject.name == "Dead"){
            trail.startWidth = 0;
            gameObject.SetActive(false);
            MainGame.instance.LooseLife();
        }
    }

    void OnCollisionEnter(){
        AddVelocity();
    }


    private void AddVelocity(){       
        if(rb.velocity.magnitude < maxBallVelocity && addVelocityBall){
            rb.velocity = rb.velocity * 1.008f;
            MainGame.instance.ShareVelocity(rb.velocity.magnitude);
        }
    }


    public void Reset(){
        gameObject.SetActive(true);
        stopBall = false; // Testing
        rb.velocity = Vector3.zero;
        transform.parent = parentBall;
        transform.localPosition = localPositionBall;        
        playBall = false;
        MainGame.instance.ShareVelocity(rb.velocity.magnitude);
    }

    public void Stop(){
        stopBall = true;
        trail.time = 10000f;
        lastVelocity = rb.velocity;
        rb.velocity = Vector3.zero;
    }

     public void Resume(){
        stopBall = false;
        trail.time = 1f;
        rb.velocity = lastVelocity;
    }
}
