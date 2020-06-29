using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBombScript_Player2 : MonoBehaviour
{
    public float gooBombSpeed;
    private Rigidbody2D rb;
    public float xTrajectory, yTrajectory;

    public int gooDamage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player2 = GameObject.Find("Gooey_Player2");
        Player2Controls player2Script = player2.GetComponent<Player2Controls>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        if(player2Script.facingRight == true)
        {
            rb.velocity = new Vector2(xTrajectory, yTrajectory) * gooBombSpeed;
        }
        if(player2Script.facingRight == false)
        {
            rb.velocity = new Vector2(-xTrajectory, yTrajectory) * gooBombSpeed;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Stewie_Player1")
        {
            Debug.Log("Hit own player");
        }
        if (other.gameObject.name == "Gooey_Player2")
        {
            GameManagement.player2Health = GameManagement.player2Health - gooDamage;

        }
        if (other.gameObject.CompareTag("GooWaveProtector"))
        {
            Debug.Log("hit Protector");
        }
        
        if (other.tag != ("GooWaveProtector"))
        {
            Destroy(gameObject);
        }
        
        
    }
}
