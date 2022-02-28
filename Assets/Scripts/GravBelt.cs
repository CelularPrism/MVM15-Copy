using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBelt : MonoBehaviour
{
    private Collision collision;
    private PlayerController playerController;
    private Rigidbody2D myRigidbody2D;

    [SerializeField] private float inverseMaxDuration = 10f;
    private int rechargeTime = 60;

    private bool canInverse = true;
    private bool doubleJumping;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<Collision>();
        playerController = GetComponent<PlayerController>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.onGround) { canDoubleJump = true; }
        if (collision.onRoof) { canDoubleJump = true; }

        //If jump is pressed while in the air then the player will preform a second jump
        if (Input.GetButtonDown("Jump") && PauseMenu.gameIsPaused == false && canDoubleJump)
        {
            doubleJumping = true; // triggers the jump method to be called
            canDoubleJump = false; // prevents the player from having more than two jumps
        }
        if (!collision.onGround) return;
        if (!canInverse) return;
        if (Input.GetButtonDown("Fire2")) //input setting can be changed later
        {
            ReverseGravity();
        }
    }
    private void FixedUpdate()
    {
        if (doubleJumping)
        {
            GetComponent<Jump>().doJump(myRigidbody2D, playerController.jumpForce); //Calling the jump method
            doubleJumping = false;                                                  // return doubleJumping bool to the false
        }
    }

    public void ReverseGravity()
    {
        StartCoroutine(ReverseGravityCoroutine());
        StartCoroutine(RechargeBeltCoroutine());
    }

    //Reverse the gravity for the player
    private IEnumerator ReverseGravityCoroutine()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1;
        int timer = 0;
        collision.bottomOffset = new Vector2(collision.bottomOffset.x, collision.bottomOffset.y * -1);
        PlatformEffector2D[] oneWayPlatforms;
        oneWayPlatforms = FindObjectsOfType<PlatformEffector2D>();
        
        foreach(PlatformEffector2D oneWay in oneWayPlatforms)
        {
            oneWay.rotationalOffset = 180;
        }
        while (inverseMaxDuration > timer)
        {
            timer += 1;
            yield return new WaitForSeconds(1);
            if (timer >= inverseMaxDuration)
            {
                GetComponent<Rigidbody2D>().gravityScale *= -1;
                collision.bottomOffset = new Vector2(collision.bottomOffset.x, collision.bottomOffset.y * -1);
                foreach (PlatformEffector2D oneWay in oneWayPlatforms)
                {
                    oneWay.rotationalOffset = 0;
                }
            }
        }
    }

    // Reverse Gravity recharge time
    private IEnumerator RechargeBeltCoroutine()
    {
        canInverse = false;
        int timer = 0;
        while(rechargeTime > timer)
        {
            Debug.Log("Gravitation belt recharge - " + timer);
            timer += 1;
            yield return new WaitForSeconds(1);
            if(timer >= rechargeTime)
            {
                canInverse = true;
            }
        }
        timer = 0;
    }
}
