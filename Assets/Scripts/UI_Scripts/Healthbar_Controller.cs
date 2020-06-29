using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar_Controller : MonoBehaviour
{

   public Slider player1Slider;
   public Slider player2Slider;
   

   void Update() 
   {
      //player1SliderActivity();
      //player2SliderActivity();
      player1Slider.value = GameManagement.player1Health;
      player2Slider.value = GameManagement.player2Health;
   }
   
   void player1SliderActivity()
   {
      Debug.Log("Accessed player1");
      player1Slider.value = GameManagement.player1Health;

   }

   void player2SliderActivity()
   {
      Debug.Log("Accessed player2");
      player2Slider.value = GameManagement.player2Health;

   }
   
}
