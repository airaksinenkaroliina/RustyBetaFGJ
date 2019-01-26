using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    private float distanceWalked;
    public float distanceGoal;
    private bool distanceReached;
    GameObject dog;
    GameObject meter;

    AudioSource audioSrcDog;
    // Start is called before the first frame update
    void Start()
    {
        distanceWalked = 0;
        dog = GameObject.FindWithTag("Dog");
        distanceReached = false;
        meter = GameObject.FindWithTag("WalkingMeter");
        meter.SetActive(false);
        audioSrcDog = GetComponent<AudioSource>();
        audioSrcDog.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walking(float distance)
    {
        //Debug.Log(distance);
        if(distanceWalked < distanceGoal)
        {
            distanceWalked += distance;
        }
        //Debug.Log(distanceWalked);
        else if(distanceWalked > distanceGoal && distanceReached == false)
        {
            meter.SetActive(true);
            int money = 50;
            distanceReached = true;
            GameObject.FindWithTag("Inventory").GetComponent<InventoryScript>().MoneyChange(money);
        }
    }
}
