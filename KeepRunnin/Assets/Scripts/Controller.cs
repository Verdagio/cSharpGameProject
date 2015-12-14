using UnityEngine;

public class Controller : MonoBehaviour {

    //movement & speed control
    public float movement;
    public float multiplier;
    public float milestoneTracker;
    private float trackerCount;
    private float movementStore;
    private float milestoneStore;
    private float countStore;

    //jump control
    public float jump;
    public float jumpTimer;
    private float jumpCounter;
    public bool grounded;
    public LayerMask whatsGround;
    public Transform groundCheck;
    public float checkRadius;
    private bool doubleJump;
    private bool finishedJumping;

    //Misc 
    private Rigidbody2D rigBod;
    //private Collider2D collider;
    public bool moving;
    private Animator anime;
    public GameManager gameManager;


    // Use this for initialization
    void Start () {
        anime = GetComponent<Animator>();
        rigBod = GetComponent<Rigidbody2D>();
       // collider = GetComponent<Collider2D>();
        jumpCounter = jumpTimer;

        movementStore = movement;
        milestoneStore = milestoneTracker;
        countStore = trackerCount;
        finishedJumping = true;
    }
	
	// Update is called once per frame
	void Update () {
        moving = true;

       // grounded = Physics2D.IsTouchingLayers(collider, whatsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatsGround);

        if(transform.position.x > trackerCount)
        {
            trackerCount += milestoneTracker;

            milestoneTracker = milestoneTracker * multiplier;
            movement = movement * multiplier;

        }//if player position > milestone

        rigBod.velocity = new Vector2(movement, rigBod.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rigBod.velocity = new Vector2(rigBod.velocity.x, jump);
                moving = false;
                finishedJumping = false;
                doubleJump = true;

                if (!grounded && doubleJump == true)
                {
                    rigBod.velocity = new Vector2(rigBod.velocity.x, jump);
                    jumpCounter = jumpTimer;
                    finishedJumping = true;
                    doubleJump = false;

                }
            }//grounded
        }//get key down

        if (Input.GetKey(KeyCode.Space) && !finishedJumping)
        {
            if(jumpCounter > 0)
            {
                rigBod.velocity = new Vector2(rigBod.velocity.x, jump);
                jumpCounter -= Time.deltaTime;
            }//if counter > 0
        }//if space bar is held

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCounter = 0;
            finishedJumping = true;
        }//if key up

        if (grounded){
            jumpCounter = jumpTimer;
            doubleJump = true;
        }//if grounded reset counter

        anime.SetFloat("Movement", rigBod.velocity.x);
        anime.SetBool("Grounded", grounded);
    }//update

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "deathbox")
        {
            gameManager.Respawn();
            movement = movementStore;
            milestoneTracker = milestoneStore;
            trackerCount = countStore;
        }//if the player hits the death box
    }


      


}

