using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBombScript_Player1 : MonoBehaviour
{
    public float gooBombSpeed;
    private Rigidbody2D rb;
    public float xTrajectory, yTrajectory;

    private Collider2D[] explosionArea;
    public int gooDamage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player1 = GameObject.Find("Stewie_Player1");
        Player1Controls player1Script = player1.GetComponent<Player1Controls>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        if(player1Script.facingRight == true)
        {
            rb.velocity = new Vector2(xTrajectory, yTrajectory) * gooBombSpeed;
        }
        if(player1Script.facingRight == false)
        {
            rb.velocity = new Vector2(-xTrajectory, yTrajectory) * gooBombSpeed;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        // if (other.gameObject.name == "Stewie_Player1")
        // {
        //     Debug.Log("Hit own player");
        // }
        // if (other.gameObject.name == "Gooey_Player2")
        // {
        //     GameManagement.player2Health = GameManagement.player2Health - gooDamage;

        // }
        if (other.gameObject.CompareTag("GooWaveProtector"))
        {
            Debug.Log("hit Protector");
        }

        if (other.tag != ("GooWaveProtector"))
        {
            Destroy(gameObject);
        }   
    }

    // void Explosion(Vector2 centre, float radius)
    // {
    //     Collider2D[] explosionArea = Physics2D.OverlapCircle(centre, radius);
    //     int i = 0;
    //     while (i < explosionArea.Length)
    //     {
    //         explosionArea[i].SendMessage("AddDamage");
    //         i++;
    //     }
    // }
}
