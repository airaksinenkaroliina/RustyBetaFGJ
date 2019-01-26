using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryScript : MonoBehaviour
{
    private int money;
    public Text moneyText;
    private List<string> bag;
    public Text bagText;
    public bool dogInInvertory;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "No money";
        bagText.text = "No items in bag";
        dogInInvertory = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoneyChange(int moneyAmount)
    {
        money += moneyAmount;
        moneyText.text = money.ToString();
    }
    public void Dog()
    {
        if(dogInInvertory  == false)
        {
            dogInInvertory = true;
        }
        else if(dogInInvertory == true)
        {
            dogInInvertory = false;
        }
    }
}
