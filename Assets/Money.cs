using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    GameObject inventory;
    int coinAmount;
    public Text coinAmountText;

    private static Money moneyScript;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory");

    }

    // Update is called once per frame
    void Update()
    {
        coinAmount = inventory.GetComponent<InventoryScript>().money;
        coinAmountText.text = coinAmount.ToString();
    }
}
