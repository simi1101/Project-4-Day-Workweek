using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    int coalCount;
    int maxCoalCount;
    bool sucking;

    public Collider interactCollider;
    public Collider collectionCollider;
    public GameObject coalPrefab;
    public Transform firepoint;
    public float launchForce;
    public float fireRate;
    float lastShotTime;
    public LayerMask layermask;

    // Start is called before the first frame update
    void Start()
    {
        sucking = true;
        interactCollider.enabled = false;
        lastShotTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Input Types
        if (Input.GetButtonDown("Fire2"))
        {
            WardOff();
            Debug.Log("Input registered");
        }

        if (Input.GetButton("Fire1"))
        {
            if (sucking != false)

            {
                Suck(true);
            }
            if (sucking != true)
            {
                Shoot();
            }
           
        }
        else
            Suck(false);

        //Switch Suction
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sucking = !sucking;
            Debug.Log(sucking);

        }

        //Shot timer
        lastShotTime += Time.deltaTime;
    }

    public void ModifyCoal(int amount)
    {
        coalCount += amount;
        Debug.Log(coalCount);
    }


    void Suck(bool state)
    {
            interactCollider.enabled = state;
        collectionCollider.enabled = state;
    }

    void Shoot()
    {
        if(coalCount > 0 && lastShotTime >= fireRate)
        {
            coalCount -= 1;
            GameObject coal = Instantiate(coalPrefab, firepoint.position, firepoint.rotation);
            Rigidbody rb = coal.GetComponent<Rigidbody>();
            rb.velocity = firepoint.forward * launchForce;
            lastShotTime = 0;
            Debug.Log("Shooting" + coalCount);
        }
    }

    void WardOff()
    {
        RaycastHit[] hits = Physics.SphereCastAll(firepoint.position, 25, firepoint.forward, layermask);
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<Enemy>() != null )
                {
                    Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                    enemy.Warded(transform.position);
                    Debug.Log("Ward attempted");
                }
            }
        }
    }

    IEnumerator WardLantern()
    {
        //Ignite Lantern
        yield return new WaitForSeconds(3);
        //Exhaust Lantern
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(firepoint.position, firepoint.forward);
        Gizmos.DrawWireSphere(firepoint.position + firepoint.forward * 100, 25);
    }
}
