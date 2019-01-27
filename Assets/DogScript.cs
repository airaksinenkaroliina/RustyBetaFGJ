using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    private float distanceWalked;
    public float distanceGoal;
    public bool distanceReached;
    GameObject dog;
    GameObject meterReached;
    AudioSource audioSrcDog;

    // Start is called before the first frame update
    void Start()
    {
        distanceWalked = 0;
        dog = GameObject.FindWithTag("Dog");
        distanceReached = false;
        meterReached = GameObject.FindWithTag("WalkingMeterReached");
        meterReached.SetActive(false);
        audioSrcDog = GetComponent<AudioSource>();
        audioSrcDog.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Walking(float distance)
    {
        if(distanceWalked < distanceGoal)
        {
            distanceWalked += distance;
        }
        else if(distanceWalked > distanceGoal && distanceReached == false)
        {
            meterReached.SetActive(true);
            distanceReached = true;
        }
    }
}
