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
    public float enemyDrainRate;
    public float wardEffect;

    bool playerKnown;
    bool inPursuit;
    bool isWarded;

    float lostPlayerTimer;
    public float timeToIdle;

    public ParticleSystem outerStorm;
    public ParticleSystem innerStorm;

    public float[] walkTime = new float[2];
    public float[] runTime = new float[2];

    public AK.Wwise.Event enemyChase;
    public AK.Wwise.Event enemyNear;
    public AK.Wwise.Event enemyDistant;
    public AK.Wwise.Event enemyAmbience;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aipath = GetComponent<AIPath>();
        outerStorm.Stop();
        innerStorm.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
      
    }

    void Idle()
    {
        moveTarget.position = transform.position;
        
    }

    public void MoveTarget(Vector3 targ )
    {
        if (isWarded != true)
        {
            moveTarget.position = targ;
            playerKnown = true;
        }
    }

    public void Lost()
    {
        Debug.Log("Lost Player");
        playerKnown = false;
        inPursuit = false;
        StopAllCoroutines();
        StartCoroutine(Search());
        outerStorm.Stop();
        innerStorm.Stop();
    }

   public void StartPursuit()
    {
        if (inPursuit != true)
        {
            isWarded = false;
            playerKnown = true;
            StopAllCoroutines();
            StartCoroutine(Pursuit());
            outerStorm.Play();
            innerStorm.Play();
            Debug.Log("Start pursuit");
        }
    }

    IEnumerator Pursuit()
    {
        inPursuit = true;
        aipath.maxSpeed = runSpeed;
        float randomRun = Random.Range(runTime[0], runTime[1]);
        Debug.Log("Running for " + randomRun);
        yield return new WaitForSeconds(randomRun);
        aipath.maxSpeed = walkSpeed;
        float randomWalk = Random.Range(walkTime[0], walkTime[1]);
        Debug.Log("Walking for " + randomWalk);
        yield return new WaitForSeconds(randomWalk);

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

    public void Warded(Vector3 playerPos)
    {
        Debug.Log("Ward is starting");
        StopAllCoroutines();
        isWarded = true;
        float distance = Vector3.Distance(transform.position, playerPos);
        Vector3 targetDir = playerPos - transform.position;
        moveTarget.position = transform.position - (targetDir * wardEffect/distance);
        StartCoroutine(WardedAway());
    }

    IEnumerator WardedAway()
    {
        aipath.maxSpeed = runSpeed;
        yield return new WaitForSeconds(3);
        isWarded = false;
        Debug.Log("Warding is ending");
    }
}
