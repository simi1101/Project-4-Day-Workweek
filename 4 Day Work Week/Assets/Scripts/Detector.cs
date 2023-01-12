using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Vector3 target;
    Enemy enemy;
    public LayerMask layermask;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Cancel pursuit
        enemy.Lost();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Trigger alert, start Coroutine for pursuit
        enemy.StartPursuit();
    }
}
