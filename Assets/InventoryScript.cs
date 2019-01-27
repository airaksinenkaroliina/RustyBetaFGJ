using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryScript : MonoBehaviour
{
    public int money;
    public bool dogInInvertory;
    public bool dogBarking;
    public bool snacks;
    public bool pizza;
    public bool vegetables;
    public bool drinks;
    public bool dudeHungry;
    public bool dudeLeft;
    public bool phone;

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
        Debug.Log("start inventory");
        dogInInvertory = false;
        dogBarking = true;
        drinks = false;
        dudeHungry = true;
        phone = false;
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

    public bool HungryDude()
    {
        if (pizza && phone)
        {
            return false;
        }
        else if (pizza)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool PhoneLostDude()
    {
        if (pizza && phone)
        {
            return false;
        }
        else if (pizza)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool EndGame()
    { 
        if(dogBarking == false && dudeLeft == true && snacks == true)
        {
            return true;
        }
        return false;
    }
}
