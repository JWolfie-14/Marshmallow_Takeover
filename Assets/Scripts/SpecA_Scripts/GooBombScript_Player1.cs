using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBombScript_Player1 : MonoBehaviour
{
    public float gooBombSpeed;
    private Rigidbody2D rb;
    public float xTrajectory, yTrajectory;

    public GameObject bombExplosionVFX;
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
        if (other.gameObject.CompareTag("GooWaveProtector"))
        {
            Debug.Log("hit Protector");
        }

        if (other.tag != ("GooWaveProtector"))
        {
            Destroy(gameObject);
            Instantiate(bombExplosionVFX, transform.position, transform.rotation);
        }   
    }
}
