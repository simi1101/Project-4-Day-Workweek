using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCoal : MonoBehaviour
{
    public int FurnaceCount;
    public int FurnaceMax;
    private Light furnaceLight;
    private SphereCollider safeZone;

    // Start is called before the first frame update
    void Start()
    {
        furnaceLight = GetComponent<Light>();
        furnaceLight.enabled = false;
        safeZone = GameObject.Find("Furnace").GetComponent<SphereCollider>();
        safeZone.enabled = false;
        FurnaceCount= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(FurnaceCount >= FurnaceMax)
        {
            furnaceLight.enabled = true;
            safeZone.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coal has hit a furnace");
        Coal coal = other.gameObject.GetComponent<Coal>();
        Destroy(other.gameObject);
        FurnaceCount++;

    }
}
