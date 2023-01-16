using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureMeter : MonoBehaviour
{
    public float HealthBar = 130;
    public float HealRate = 5;
    public float DrainRate = 1;
    public float IncreaseDifficulty = 0;
    public float MaxHealth;
    public float FurnaceHealMax;
    public float MonsterDrain;
    public bool InSafeZone;
    public bool Healed;
    public bool fullHeal;
    //private SphereCollider safeZone;
    // Start is called before the first frame update
    void Start()
    {
        InSafeZone = false;
        MaxHealth = HealthBar;
        MonsterDrain= 0;
        //safeZone = GameObject.Find("Furnace").GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Healed)
        {
            if (HealthBar < MaxHealth)
            {
                Healing();
            }
            else
            {
                //Healed = false;
                //Debug.Log("you have healed");
               // MaxHealth = MaxHealth - IncreaseDifficulty;
            }
        }
        else if (InSafeZone)
        {
            Debug.Log("you are safe");
        }
        else if (HealthBar > -130)
        {
            HealthBar -= (DrainRate + MonsterDrain) * Time.deltaTime;
        }
        else
        {
            //Debug.Log("you are dead");
            ObjectivesManager om = GameObject.Find("ObjectiveManager").GetComponent<ObjectivesManager>();
            om.Lose();
        }
    }
    
    void Healing()
    {
        HealthBar += HealRate * Time.deltaTime;
    }

    void PartialHealing()
    {
        float temphealth = HealthBar += HealRate * Time.deltaTime;
        Mathf.Clamp(temphealth, 0, FurnaceHealMax);
        HealthBar = temphealth;
    }

    public void FullHealing(bool healingType)
    {
        fullHeal = healingType;
    }
}
