using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCoal : MonoBehaviour
{
    public int FurnaceCount;
    public int FurnaceMax;
    public float furnaceTimer;
    private Light furnaceLight;
    private SphereCollider safeZone;
    bool activated;

    public AK.Wwise.Event furnaceIgnite;
    public AK.Wwise.Event coalDump;
    public AK.Wwise.Event furnaceEnd;

    // Start is called before the first frame update
    void Start()
    {
        furnaceLight = GetComponent<Light>();
        furnaceLight.enabled = false;
        safeZone = GetComponentInParent<SphereCollider>();
        safeZone.enabled = false;
        FurnaceCount= 0;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coal has hit a furnace");
        Coal coal = other.gameObject.GetComponent<Coal>();

        if (coal != null && furnaceLight.enabled != true)
        {
            Destroy(other.gameObject);
            FurnaceCount++;
            coalDump.Post(gameObject);
            if (FurnaceCount >= FurnaceMax)
            {
                StartCoroutine(ActivationCycle());
            }
        }

    }

    IEnumerator ActivationCycle()
    {
        if (activated != true)
        {
            Debug.Log("Furnace cycling");
            furnaceLight.enabled = true;
            safeZone.enabled = true;
            furnaceIgnite.Post(gameObject);
            yield return new WaitForSeconds(furnaceTimer);
            furnaceLight.enabled = false;
            safeZone.enabled = false;
            FurnaceCount = 0;
            activated = false;
            furnaceEnd.Post(gameObject);
            furnaceIgnite.Stop(gameObject);
        }
    }
}
