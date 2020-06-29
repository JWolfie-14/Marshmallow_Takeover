using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooWaveScript_Player1 : MonoBehaviour
{
    public float gooWaveSpeed;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        rb.velocity = transform.right * gooWaveSpeed;
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if  (other.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
            Debug.Log("hit Protector");
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("GooWaveProtector"))
        {
            Destroy(gameObject);
        }
    }

    
}
