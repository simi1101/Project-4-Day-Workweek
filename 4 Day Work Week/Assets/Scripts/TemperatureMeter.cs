using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureMeter : MonoBehaviour
{
    public float HealthBar = 100;
    public float HealRate = 5;
    public float DrainRate = 1;
    public float IncreaseDifficulty = 0;
    public float MaxHealth;
    public bool InSafeZone;
    public bool Healed;
    // Start is called before the first frame update
    void Start()
    {
        InSafeZone = false;
        MaxHealth = HealthBar;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InSafeZone)
        {
            Debug.Log("you are safe");
        }
        else if (Healed)
        {
            Debug.Log("you are being healed");
            Healed= false;
            MaxHealth = MaxHealth - IncreaseDifficulty;
            while (HealthBar < MaxHealth)
            {
                HealthBar += HealRate * Time.deltaTime;
            }
            Debug.Log("you have healed");
        }
        else if (HealthBar > 0)
        {
            HealthBar -= DrainRate * Time.deltaTime;
        }
        else
        {
            Debug.Log("you are dead");
        }
    }
}
