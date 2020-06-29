using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamageController : MonoBehaviour
{
    public float bombDamage;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Stewie_Player1")
        {
            GameManagement.player1Health = GameManagement.player1Health - bombDamage;
        }
        if (other.gameObject.name == "Gooey_Player2")
        {
            GameManagement.player2Health = GameManagement.player2Health - bombDamage;
        }
    }
}
