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
    GameObject hungryDude;
    GameObject dude;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start home script");
        dogBoolean = false;
        inventory = GameObject.FindWithTag("Inventory");
        hungryDude = GameObject.Find("DudeHungry");
        if (hungryDude != null) {
            hungryDude.GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().HungryDude();
            hungryDude.SetActive(inventory.GetComponent<InventoryScript>().HungryDude());
        }
        dude = GameObject.Find("Dude");
        if (dude != null) {
            dude.GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();
            dude.SetActive(inventory.GetComponent<InventoryScript>().PhoneLostDude());
        }

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
            Debug.Log("Hungry duuuudee");
            dialogScript.UpdateDialog("DudeHungry");
            hungryDude.GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().HungryDude();
            dude.GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();
        }
        else if (name == "Dude")
        {
            Debug.Log("Nowww duuuudee");
            if (inventory.GetComponent<InventoryScript>().phone) 
            {
                dialogScript.UpdateDialog("DudeWithPhone");
                inventory.GetComponent<InventoryScript>().dudeLeft = true;
            }
            else
            {
                dialogScript.UpdateDialog("Dude");
            }
            dude.GetComponent<Renderer>().enabled = inventory.GetComponent<InventoryScript>().PhoneLostDude();
        }
        else if (name == "Fridge")
        {
            Debug.Log("Im a fridge");
            if (inventory.GetComponent<InventoryScript>().snacks)
            {
                dialogScript.UpdateDialog("Fridge");
            }
            else
            {
                dialogScript.UpdateDialog("FridgeEmpty");
            }
        }
        else if (name == "Bag")
        {
            Debug.Log("Im a bag");
            if (inventory.GetComponent<InventoryScript>().PhoneLostDude())
            {
                dialogScript.UpdateDialog("Bag");
            }
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
            dialogScript.UpdateDialog("Drinks");
            /*
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().drinks = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }*/
        }
        else if (name == "Pizza")
        {
            dialogScript.UpdateDialog("Pizza");
            /*
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().pizza = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }*/
        }
        else if (name == "Vegetables")
        {
            dialogScript.UpdateDialog("Vegetables");
            /*
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().vegetables = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            }*/
        }
        else if (name == "Snacks")
        {
            dialogScript.UpdateDialog("Snacks");
            /*
            if (inventory.GetComponent<InventoryScript>().money >= 10)
            {
                inventory.GetComponent<InventoryScript>().snacks = true;
                inventory.GetComponent<InventoryScript>().MoneyChange(-10);
            } */
        }
        else if (name == "TV")
        {
            if (inventory.GetComponent<InventoryScript>().EndGame() )
            {
                SceneManager.LoadScene("EndScene"); 
            }
        }
    }
}
