using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooScript_Player1 : MonoBehaviour
{
    
    public float gooSpeed;
    private Rigidbody2D rb;
    public GameObject basicExplosion;

    public int gooDamage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(8, 8);
        rb.velocity = transform.right * gooSpeed;
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

        if ((other.tag != "GooWaveProtector"))
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
