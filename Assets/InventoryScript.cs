using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryScript : MonoBehaviour
{
    public int money;
    public bool dogInInvertory;
    public bool snacks;
    public bool pizza;
    public bool vegetables;
    public bool drinks;

    private static InventoryScript inventoryScript;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (inventoryScript == null)
        {
            inventoryScript = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dogInInvertory = false;
        drinks = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoneyChange(int moneyAmount)
    {
        money += moneyAmount;
    }
    public void Dog()
    {
        if(dogInInvertory  == false)
        {
            dogInInvertory = true;
        }
        else 
        {
            dogInInvertory = false; 
        }
    }
}
