using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    public float sightRange;
    public float chaseRange;
    public LayerMask layermask;
    public Transform moveTarget;
    Vector3 lookAt;
    AIPath aipath;

    public float walkSpeed;
    public float runSpeed;

    bool playerKnown;
    bool inPursuit;
    bool isWarded;

    float lostPlayerTimer;
    public float timeToIdle;

    public float[] walkTime = new float[2];
    public float[] runTime = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aipath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RaycastHit hit;
        //        if(Physics.SphereCast(transform.position, sightRange, transform.forward, out hit, 3, layermask, QueryTriggerInteraction.UseGlobal))
        //{
        //    moveTarget.position = hit.transform.position;
        //    Debug.Log("Position found");
        //    Debug.DrawLine(transform.position, hit.transform.position);
        //}
        //    else
        //{
        //    //Idle();
        //    Debug.Log("No hit");
        //}
        //Debug.Log(hit.transform.gameObject.name);
      
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, moveTarget.position);
        Gizmos.DrawWireSphere(transform.position + transform.forward * 3, sightRange);
    }

    void Idle()
    {
        moveTarget.position = transform.position;
        
    }

    public void MoveTarget(Vector3 targ )
    {
        moveTarget.position = targ;
        playerKnown = true;
    }

    public void Lost()
    {
        Debug.Log("Lost Player");
        playerKnown = false;
        inPursuit = false;
        StopAllCoroutines();
        StartCoroutine(Search());
        
    }

   public void StartPursuit()
    {
        if (inPursuit != true)
        {
            playerKnown = true;
            StopAllCoroutines();
            StartCoroutine(Pursuit());
            Debug.Log("Start pursuit");
        }
    }

    IEnumerator Pursuit()
    {
        inPursuit = true;
        aipath.maxSpeed = walkSpeed;
        float randomWalk = Random.Range(walkTime[0], walkTime[1]);
        Debug.Log("Walking for " + randomWalk);
        yield return new WaitForSeconds(randomWalk);
        aipath.maxSpeed = runSpeed;
        float randomRun = Random.Range(runTime[0], runTime[1]);
        Debug.Log("Running for " + randomRun);
        yield return new WaitForSeconds(randomRun);
        if(playerKnown != false)
        {
            Debug.Log("Player still in reach");
            inPursuit = false;
            StopCoroutine(Pursuit());
            StartPursuit();
        }
        else
        {
            Debug.Log("Player is out of reach");
            inPursuit = false;
            StopAllCoroutines();
        }
        Debug.Log("Coroutine ended");
    }

    IEnumerator Search()
    {
        aipath.maxSpeed = walkSpeed;
        yield return new WaitForSeconds(timeToIdle);
        Idle();
        Debug.Log("Search over");
    }

    void Warded()
    {
        //get direction from player towards enemy, then set point banish distance away from transform.position
    }
}
