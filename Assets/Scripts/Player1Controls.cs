using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    public GameObject player2;
    public static bool movementActive = false;
    public float speed;
    public float jumpForce;
    //public float megaJumpForce;
    public int jumpCount;
    private int jumpValue;
    public float moveInput;
    public int ammoCount;
    public float reloadTime;
    public Transform ammoSpawn;
   
    public GameObject gooPrefab;

    public bool ignoreCollisons = false;
    

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int direction;
    private float dashTime;
    public float startDashTime;
    public float dashSpeed;
    public float powerDrive;
    public int squash;

    public bool facingRight = true;
    public static int abilityNumber = 0;
    //*******************ability1************************
    public GameObject gooBombPrefab;
    public  float gooBombReloadTime;
    public int gooBombAmmoCount;
    public int gooBombAmmoCountInternal;
    private int gooBombAmmoDelay = 1;
    public GameObject [] gooBombAmmoCounter;
    public GameObject gooBombCounterUI;
    //***************************************************
    
    //*******************ability2************************
    public GameObject rapidFireGooPrefab;
    public  float rapidFireReloadTime;
    public int rapidFireAmmoCount;
    public int rapidFireAmmoCountInternal;
    private int rapidFireAmmoDelay = 1;
    public GameObject [] rapidFireAmmoCounter;
    public GameObject rapidFireCounterUI;
    //***************************************************

    //******************ability3*************************
    public GameObject waveGooPrefab;
    public  float waveGooReloadTime;
    public int waveGooAmmoCount;
    public int waveGooAmmoCountInternal;
    private int waveGooAmmoDelay = 1;
    public GameObject [] waveGooAmmoCounter;
    public GameObject waveGooCounterUI;
    //*****************************************************

    private Animator anim;
    private Animator p2Anim;

    public float gravityValue;
    public int dashCount;
    public float dashCooldownTime;
    public int powerDriveCount;
    public float powerDriveCooldownTime;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        p2Anim = player2.GetComponent<Animator>();
        //IgnoreCollision();
        jumpValue = jumpCount;
        dashTime = startDashTime;
        rapidFireAmmoCountInternal = rapidFireAmmoCount;
        waveGooAmmoCountInternal = waveGooAmmoCount;
        gooBombAmmoCountInternal = gooBombAmmoCount;
    }
    
    void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        moveInput = Input.GetAxisRaw("Horizontal_Player1");
    }
    

    void Update() 
        {
        Physics2D.IgnoreLayerCollision(8, 9);    
        //Debug.Log("Ability count p1: " + pickupCountPlayer1);
        //    Debug.Log("facing right: " + facingRight);
           rb.gravityScale = gravityValue;
           anim.SetBool("grounded", isGrounded);
        //    Debug.Log("movementActive: " + movementActive);
        //Debug.Log("WAVE AMMO: " + waveGooAmmoCountInternal);
           
           if (facingRight == false && moveInput > 0)
                {
                    flip();
                }
           else if (facingRight == true && moveInput < 0)
                {
                    flip();
                }
           
           if (isGrounded == true)
                {
                    jumpValue = jumpCount;
                }
                
           
        if (movementActive == true)
        {
           rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
           if  (Input.GetButton("Jump_Player1") && jumpValue > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpValue = jumpValue - 1; 
                } 
           else if (Input.GetButton("Jump_Player1") && jumpValue == 0 && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }

           if (direction == 0)
                {
                   if (moveInput < 0 && Input.GetButton("Dash_Player1") && dashCount == 1)
                        {
                            Debug.Log("Dash left");
                            direction = 1;
                            dashCount = dashCount - 1;
                            Invoke("DashCooldown", dashCooldownTime);
                        }
                    else if (moveInput > 0 && Input.GetButton("Dash_Player1") && dashCount == 1)
                        {
                            Debug.Log("Dash right");
                            direction = 2;
                            dashCount = dashCount - 1;
                            Invoke("DashCooldown", dashCooldownTime);
                        }
                    else if (Input.GetButton("Powerdrive_Player1") && isGrounded == false && powerDriveCount == 1)
                        {
                            Debug.Log("PowerDrive DOWN");
                            direction = 3;
                            squash = 1;
                            powerDriveCount = powerDriveCount - 1;
                            Debug.Log("squash ability: " + squash);
                            Invoke("PowerDriveCooldown", powerDriveCooldownTime);
                        }
                }
            else 
                {
                    if (dashTime <= 0)
                        {
                            direction = 0;
                            squash = 0;
                            Debug.Log("squash ability: " + squash);
                            dashTime = startDashTime;
                            rb.velocity = Vector2.zero;
                        }   
                    else  
                        {
                            dashTime -= Time.deltaTime;
                            //Debug.Log("dash cooldown: " + dashTime);
                        }
                }

            if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    rb.gravityScale = 0f;
                    anim.SetTrigger("dash");
                }

            if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    rb.gravityScale = 0f;
                    anim.SetTrigger("dash");
                }

            if (direction == 3)
                {
                    rb.velocity = Vector2.down * powerDrive;
                }

            if ((Input.GetAxis("PrimaryFire_Player1") != 0) && (ammoCount == 1))
            {
                Shoot();
            }
            //****************************************ability1*******************************************************************
            if ((Input.GetAxis("SecondaryFire_Player1") != 0) && (abilityNumber == 1) && (gooBombAmmoDelay == 1) && (pickupCountPlayer1 == 1) && (gooBombAmmoCountInternal > 0) && (SpecialAbilitySpawn.abilityUsed == false))
            {
                ShootGooBomb();
            }

            if (gooBombAmmoCountInternal == 0)
            {
                SpecialAbilitySpawn.abilityUsed = true;
                //pickupCountPlayer1 = 0;
                gooBombCounterUI.SetActive(false);
                gooBombAmmoCountInternal = gooBombAmmoCount; 
            }

            for (int i = 0; i < gooBombAmmoCounter.Length; i++)
            {
                if (gooBombAmmoCountInternal > i )
                {
                    gooBombAmmoCounter[i].SetActive(true);
                }
                else
                {
                   gooBombAmmoCounter[i].SetActive(false);
                }
            }
            //****************************************ability2*******************************************************************
            if ((Input.GetAxis("SecondaryFire_Player1") != 0) && (abilityNumber == 2) && (rapidFireAmmoDelay == 1) && (pickupCountPlayer1 == 1) && (rapidFireAmmoCountInternal > 0) && (SpecialAbilitySpawn.abilityUsed == false))
            {
                ShootRapidFireGoo();
            }

            if (rapidFireAmmoCountInternal == 0)
            {
                SpecialAbilitySpawn.abilityUsed = true;
                //pickupCountPlayer1 = 0;
                rapidFireCounterUI.SetActive(false);
                rapidFireAmmoCountInternal = rapidFireAmmoCount; 
            }

            for (int i = 0; i < rapidFireAmmoCounter.Length; i++)
            {
                if (rapidFireAmmoCountInternal > i )
                {
                    rapidFireAmmoCounter[i].SetActive(true);
                }
                else{
                    rapidFireAmmoCounter[i].SetActive(false);
                }
            }
            //******************************************ability3********************************************************************
            if ((Input.GetAxis("SecondaryFire_Player1") != 0) && (abilityNumber == 3) && (waveGooAmmoDelay == 1) && (pickupCountPlayer1 == 1) && (waveGooAmmoCountInternal > 0) && (SpecialAbilitySpawn.abilityUsed == false))
            {
                ShootWaveGoo();
            }

            if (waveGooAmmoCountInternal == 0)
            {
                SpecialAbilitySpawn.abilityUsed = true;
                //pickupCountPlayer1 = 0;
                waveGooCounterUI.SetActive(false);
                waveGooAmmoCountInternal = waveGooAmmoCount;
            }
            for (int i = 0; i < waveGooAmmoCounter.Length; i++)
            {
                if (waveGooAmmoCountInternal > i )
                {
                    waveGooAmmoCounter[i].SetActive(true);
                }
                else{
                   waveGooAmmoCounter[i].SetActive(false);
                }
            }

        }
           
        }
    public int powerDriveDamage;
    public static int pickupCountPlayer1;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (squash == 1 && other.gameObject.name == "HeadCheck_Player2")
        {
            p2Anim.SetTrigger("squash");
            Debug.Log("Deducted 50hp from player 2");
            GameManagement.player2Health = GameManagement.player2Health - powerDriveDamage;
            squash = 0;
        }

        if ((SpecialAbilitySpawn.abilityPickedUp == true) && (other.gameObject.CompareTag("SpecA_1")) && (pickupCountPlayer1 == 0))
        {
            Destroy(other.gameObject);
            SpecialAbilityPickup();
            gooBombCounterUI.SetActive(true);
            abilityNumber = 1;
            
        }
        if ((SpecialAbilitySpawn.abilityPickedUp == true) && (other.gameObject.CompareTag("SpecA_2")) && (pickupCountPlayer1 == 0))
        {
            Destroy(other.gameObject);
            SpecialAbilityPickup();
            rapidFireCounterUI.SetActive(true);
            abilityNumber = 2;
        }
        if ((SpecialAbilitySpawn.abilityPickedUp == true) && (other.gameObject.CompareTag("SpecA_3")) && (pickupCountPlayer1 == 0))
        {
            Destroy(other.gameObject);
            SpecialAbilityPickup();
            waveGooCounterUI.SetActive(true);
            abilityNumber = 3;
        }
    }    

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate (0f, 180f, 0f);
    }

    void Reload()
    {
        ammoCount = ammoCount + 1;
        Debug.Log("Ammo: " + ammoCount);
    }
    void Shoot()
    {
        Instantiate(gooPrefab, ammoSpawn.position, ammoSpawn.rotation);
        anim.SetTrigger("shoot");
        Debug.Log("Trigger pressed");
        ammoCount = ammoCount - 1;
        Invoke("Reload", reloadTime);
    }
    //******************ability 1 shoot functions*****************************
    void GooBombReload()
    {
        gooBombAmmoDelay = gooBombAmmoDelay + 1;
    }
    void ShootGooBomb()
    {
        Instantiate(gooBombPrefab, ammoSpawn.position, ammoSpawn.rotation);
        anim.SetTrigger("shoot");
        Debug.Log("Trigger pressed");
        gooBombAmmoDelay = gooBombAmmoDelay - 1;
        gooBombAmmoCountInternal = gooBombAmmoCountInternal - 1;
        Invoke("GooBombReload", gooBombReloadTime);
    }
    //************************************************************************
    //******************ability 2 shoot functions*****************************
    void RapidFireReload()
    {
        rapidFireAmmoDelay = rapidFireAmmoDelay + 1;
    }
    
    
    void ShootRapidFireGoo()
    {
        Instantiate(rapidFireGooPrefab, ammoSpawn.position, ammoSpawn.rotation);
        anim.SetTrigger("shoot");
        Debug.Log("Trigger pressed");
        rapidFireAmmoDelay = rapidFireAmmoDelay - 1;
        rapidFireAmmoCountInternal = rapidFireAmmoCountInternal - 1;
        Invoke("RapidFireReload", rapidFireReloadTime);
    }
    //************************************************************************
    //******************ability 2 shoot functions*****************************
    void WaveGooReload()
    {
        waveGooAmmoDelay = waveGooAmmoDelay + 1;
    }
    void ShootWaveGoo()
    {
        Instantiate(waveGooPrefab, ammoSpawn.position, ammoSpawn.rotation);
        anim.SetTrigger("shoot");
        Debug.Log("Trigger pressed");
        waveGooAmmoDelay = waveGooAmmoDelay - 1;
        waveGooAmmoCountInternal = waveGooAmmoCountInternal - 1;
        Invoke("WaveGooReload", waveGooReloadTime);
    }
    //***************************************************************************

    void DashCooldown()
    {
        dashCount = dashCount + 1;
    }
    
    void PowerDriveCooldown()
    {
        powerDriveCount = powerDriveCount + 1;
    }

    void SpecialAbilityPickup()
    {
        pickupCountPlayer1 = 1;
    }
}
