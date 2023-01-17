using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureMeter : MonoBehaviour
{
    public float HealthBar = 130;
    public float HealRate = 5;
    public float DrainRate = 2;
    public float IncreaseDifficulty = 0;
    public float MaxHealth;
    public float FurnaceHealMax;
    public float MonsterDrain;
    public bool InSafeZone;
    public bool Healed;
    public bool fullHeal;
    private SphereCollider safeZone;

    public AK.Wwise.Event heatLoss;
    public AK.Wwise.Event heatLossMonster;
    public AK.Wwise.Event breathingNormal;
    public AK.Wwise.Event breathingHeavy;

    // Start is called before the first frame update
    void Start()
    {
        InSafeZone = false;
        MaxHealth = HealthBar;
        MonsterDrain= 0;
        safeZone = GameObject.Find("Furnace").GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Healed)
        {
            if (HealthBar < MaxHealth)
            {
                //Healing();
            }
            else
            {
                //Healed = false;
                //Debug.Log("you have healed");
               // MaxHealth = MaxHealth - IncreaseDifficulty;
            }
        }
        //else if (InSafeZone)
       // {
           // Debug.Log("you are safe");
        //}
        else if (HealthBar > -130)
        {
            HealthBar -= (DrainRate + MonsterDrain) * Time.deltaTime;
        }
        
        if(HealthBar < -130)
        {
            //Debug.Log("you are dead");
            ObjectivesManager om = GameObject.Find("ObjectiveManager").GetComponent<ObjectivesManager>();
            om.Lose();
        }
    }
    
    public void Healing()
    {
        if (HealthBar < MaxHealth)
        {
            HealthBar += HealRate * Time.deltaTime;
        }
        
    }

    public void PartialHealing()
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
