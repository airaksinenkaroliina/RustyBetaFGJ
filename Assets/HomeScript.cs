using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public string Name;
    public bool dogBoolean;
    GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start home script");
        dogBoolean = false;
        inventory = GameObject.FindWithTag("Inventory");
        GameObject.Find("DudeHungry").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().HungryDude();
        GameObject.Find("Dude").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("neeew");
        Debug.Log(this.transform.gameObject.name);
        Name = this.transform.gameObject.name;
        Canvas dialogCanvas = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        DialogScript dialogScript = GameObject.Find("Dialog").GetComponent<DialogScript>();
        Debug.Log(dialogScript.nameText.text);
        Debug.Log(dialogScript.questionText.text);

        if (name == "DudeHungry")
        {
            dialogScript.UpdateDialog("DudeHungry");
            GameObject.Find("DudeHungry").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().HungryDude();
            GameObject.Find("Dude").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();
        }
        else if (name == "Dude")
        {
            dialogScript.UpdateDialog("Dude");
            GameObject.Find("DudeHungry").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().HungryDude();
            GameObject.Find("Dude").GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();
        }
        else if (name == "Fridge")
        {
            Debug.Log("Im a fridge");
            dialogScript.UpdateDialog("FridgeEmpty");
        }
        else if (name == "Backbag")
        {
            Debug.Log("Im a backbag");
        }
        else if (name == "Neighbor")
        {
            Debug.Log("Im a neighbor, sooo ooold");
            dialogScript.UpdateDialog("Neighbor");
        }
        else if (name == "Remppa")
        {
            Debug.Log("Wufff wuffff");
            dialogScript.UpdateDialog("Remppa");
            inventory.GetComponent<InventoryScript>().Dog();
        }
        else if (name == "Back")
        {
            Debug.Log("Go out for adventure");
            SceneManager.LoadScene("World");
        }
        else if (name == "Drinks")
        {
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().drinks = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }
        }
        else if (name == "Pizza")
        {
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().pizza = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }
        }
        else if (name == "Vegetables")
        {
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().vegetables = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }
        }
        else if (name == "Snacks")
        {
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().snacks = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }
        }
    }
}
