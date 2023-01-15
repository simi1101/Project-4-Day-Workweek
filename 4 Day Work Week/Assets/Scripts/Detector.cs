using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Vector3 target;
    Enemy enemy;
    public LayerMask layermask;
    TemperatureMeter temp;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();

            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            //Debug.Log("Player Detected");
            target = other.transform.position;
            enemy.MoveTarget(target);
            float distance = Vector3.Distance(target, transform.position);
            float currentDrain = enemy.enemyDrainRate/distance;
            temp.MonsterDrain = Mathf.Clamp(currentDrain, 0, 20);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Cancel pursuit
        enemy.Lost();
        temp.MonsterDrain = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Trigger alert, start Coroutine for pursuit
        enemy.StartPursuit();
        if (other.GetComponent<TemperatureMeter>() != null)
        {
            temp = other.GetComponent<TemperatureMeter>();
        }
    }
}
