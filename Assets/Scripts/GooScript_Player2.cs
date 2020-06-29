using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooScript_Player2 : MonoBehaviour
{
    
    public float gooSpeed;
    private Rigidbody2D rb;

    public int gooDamage;
    public GameObject basicExplosion;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        rb.velocity = transform.right * gooSpeed;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Gooey_Player2")
        {
            Debug.Log("Hit own player");
        }
        if (other.gameObject.name == "Stewie_Player1")
        {
            GameManagement.player1Health = GameManagement.player1Health - gooDamage;

        }
        if (other.gameObject.CompareTag("GooWaveProtector"))
        {
            Debug.Log("hit Protector");
        }

        if (other.tag != "GooWaveProtector")
        {
            Debug.Log("Hit another object");
            Instantiate(basicExplosion, transform.position, transform.rotation);
            Destroy(gameObject);  
        }

        if (other.tag == "SpecA_1" || other.tag == "SpecA_2" || other.tag == "SpecA_3")
        {
            Destroy(other.gameObject);
            SpecialAbilitySpawn.abilityDestroyed = true;
        }
        
    }
}
