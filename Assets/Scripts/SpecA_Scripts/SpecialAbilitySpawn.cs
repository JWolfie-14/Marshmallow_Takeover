using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilitySpawn : MonoBehaviour
{
 public float abilityCooldownTimerMax;
 private float abilityCooldownTimerInternal;
 private bool reachedMaxTime = false;
 public Transform location1, location2, location3, location4, location5, location6, location7;
 public GameObject specialAbility1, specialAbility2, specialAbility3;
 List<GameObject> abilityList;
 List<Transform> locationList;
 public static bool abilityPickedUp = false;
 public static bool abilityDestroyed = false;
 public GameObject rapidFireCounterUIP1;
 public GameObject waveGooCounterUIP1;
 public GameObject gooBombCounterUIP1;
 public GameObject rapidFireCounterUIP2;
 public GameObject waveGooCounterUIP2;
 public GameObject gooBombCounterUIP2;


 private Transform spawnPoint1;
 //private Transform spawnPoint2;
//  public static bool isAbilityUsedPlayer1 = false;
//  public static bool isAbilityUsedPlayer2 = false;
public static bool abilityUsed = false;
public GameObject specialAbilityActive;

void Start()
 {
   locationList = new List<Transform>();
   abilityList = new List<GameObject>();

   locationList.Add(location1);
   locationList.Add(location2);
   locationList.Add(location3);
   locationList.Add(location4);
   locationList.Add(location5);
   locationList.Add(location6);
   locationList.Add(location7);

   abilityList.Add(specialAbility1);
   abilityList.Add(specialAbility2);
   abilityList.Add(specialAbility3);

    
 }

 void Update() 
    {
        if (Player1Controls.movementActive == true && Player2Controls.movementActive == true)
        {
        //Debug.Log("Ability Time: " + abilityCooldownTimerInternal);
        //Debug.Log("abilityPickedup:" + abilityPickedUp);
        if (reachedMaxTime == false)
            {
                abilityCooldownTimerInternal += 1 * Time.deltaTime;
            }
        if (reachedMaxTime == true)
            {
                abilityCooldownTimerInternal = 0;
            }

        if (abilityCooldownTimerInternal >= abilityCooldownTimerMax && abilityPickedUp == false)
            {
                
                /* 
                goo bomb: ability1
                rapidfire: ability2
                waveGoo: ability3 
                */
                reachedMaxTime = true;
                abilityPickedUp = true;
                Debug.Log("Input");
                GameObject abilityIcon  = abilityList[Random.Range(0, abilityList.Count)];
                spawnPoint1 = locationList[Random.Range(0, locationList.Count)];
                //spawnPoint2 = locationList[Random.Range(0, locationList.Count)];
                // if (spawnPoint2 == spawnPoint1)
                //     {
                //         spawnPoint2 = locationList[Random.Range(0, locationList.Count)];
                //     }
                //Instantiate(abilityIcon, spawnPoint1.position, spawnPoint1.rotation);
                //Instantiate(abilityIcon, spawnPoint2.position, spawnPoint2.rotation);
                specialAbilityActive = Instantiate(abilityIcon, spawnPoint1.position, spawnPoint1.rotation);
                specialAbilityActive.gameObject.name = "SpecialAbilityActive";
                
                //Instantiate(specialAbility3, spawnPoint2.position, spawnPoint2.rotation);
                
            }
        if ((abilityUsed == true) || (abilityDestroyed== true))
            {
                Player1Controls.abilityNumber = 0;
                Player2Controls.abilityNumber = 0;
                abilityPickedUp = false;
                reachedMaxTime = false;
                Player1Controls.pickupCountPlayer1 = 0;
                Player2Controls.pickupCountPlayer2 = 0;
                // isAbilityUsedPlayer1 = false;
                // isAbilityUsedPlayer2 = false;
                abilityUsed = false;
                abilityDestroyed = false;

            }       
        
        }
        if(GameManagement.roundComplete == true)
            {
                Debug.Log("reaches if in specialy ability spawn script");
                Destroy(specialAbilityActive);
                DeactivateAmmoCounterUI();

            }
        
    }

    void DeactivateAmmoCounterUI()
    {
        gooBombCounterUIP1.SetActive(false);
        waveGooCounterUIP1.SetActive(false);
        rapidFireCounterUIP1.SetActive(false);
        gooBombCounterUIP2.SetActive(false);
        waveGooCounterUIP2.SetActive(false);
        rapidFireCounterUIP2.SetActive(false);
    }

 
}

