using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBombScript_Player2 : MonoBehaviour
{
    public float gooBombSpeed;
    private Rigidbody2D rb;
    public float xTrajectory, yTrajectory;
    public GameObject bombExplosionVFX;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player2 = GameObject.Find("Gooey_Player2");
        Player2Controls player2Script = player2.GetComponent<Player2Controls>();
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
