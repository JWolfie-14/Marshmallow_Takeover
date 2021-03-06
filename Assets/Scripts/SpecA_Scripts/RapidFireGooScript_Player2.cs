﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireGooScript_Player2 : MonoBehaviour
{
    public float rapidFireGooSpeed;
    private Rigidbody2D rb;
    public GameObject basicExplosion;

    public float rapidFireGooDamage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        rb.velocity = transform.right * rapidFireGooSpeed;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Stewie_Player1")
        {
            GameManagement.player1Health = GameManagement.player1Health - rapidFireGooDamage;
            
        }
        if (other.gameObject.name == "Gooey_Player2")
        {
            Debug.Log("Hit own player");
        }

        if (other.tag != "GooWaveProtector")
        {
            Debug.Log("Hit another object");
            Instantiate(basicExplosion, transform.position, transform.rotation);
            Destroy(gameObject);  
        }

        

        
        
    }
}
