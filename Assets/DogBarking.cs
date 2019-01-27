using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBarking : MonoBehaviour
{
    AudioSource dogBarkingAsrc;
    // Start is called before the first frame update
    void Start()
    {
        dogBarkingAsrc = this.GetComponent<AudioSource>();
        dogBarkingAsrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Inventory").GetComponent<InventoryScript>().dogBarking == false)
        {
            dogBarkingAsrc.Stop();
        }
    }
}