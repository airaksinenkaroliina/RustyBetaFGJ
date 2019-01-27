using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{

    public struct DialogText
    {
        public string title;
        public string question;
        public string type;
        public bool requiresAnswer;

        public DialogText(string t, string q, string ty, bool ans) {
            title = t;
            question = q;
            type = ty;
            requiresAnswer = ans;
        }

    }


    public Text nameText;
    public Text questionText;
    public Button buttonYes, buttonNo;
    private Canvas dialogCanvas;
    private Dictionary<string, DialogText> allDialog;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "Hello hello";
        questionText.text = "What do you wanna do?";
        buttonNo.GetComponentInChildren<Text>().text = "No";
        buttonYes.GetComponentInChildren<Text>().text = "Ok";


        this.dialogCanvas = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        Debug.Log(this.dialogCanvas.enabled);
        dialogCanvas.enabled = false;
        Debug.Log(this.dialogCanvas.enabled);
        this.allDialog = new Dictionary<string, DialogText>();
        this.allDialog.Add("DudeHungry", new DialogText("Someone is lying on sofa...", "Outs, last night party was a little bit too rough for friend and friend is not feeling well.  It is hungry...", "DUDE", false));
        this.allDialog.Add("Dude", new DialogText("Outs… I’m hungry...", "Thank you for the food.. I should get going… But where is my phone?", "DUDE", false));
        this.allDialog.Add("FridgeEmpty", new DialogText("Fridge is empty…!", "I need comfort food… What should I do?", "FRIDGE", false));
        this.allDialog.Add("Fridge", new DialogText("Yam!Food in fridge!", "Now I will be able to relax my tummy fully", "FRIDGE", false));
        this.allDialog.Add("Backbag", new DialogText("Backbag”, “Ou, there is a phone in the backlog..But it isn’t mine…", "Take phone from the backbag? ", "BAGBACK", true));
        this.allDialog.Add("Neighbor", new DialogText("Neighbor at the door", "Ou, I’m so sorry Remppa is barking. I’m sick and Remppa has so much energy. Can you go to a with walk Remppa?", "NEIGHBOR", true));
        this.allDialog.Add("Remppa", new DialogText("Wuff wuffff", "Wuff wufffff wufff", "DOG", false));
        this.allDialog.Add("Vegetables", new DialogText("Vegetables", "Would you like to buy fresh and healthy vegetables ? ", "VEGETABLES", true));
        this.allDialog.Add("Pizza", new DialogText("Pizza", "Would you like to buy a cheesy pizza ? ", "PIZZA", true));
        this.allDialog.Add("Drinks", new DialogText("Drinks", "Would you like to buy soft drinks ? ", "DRINKS", true));
        this.allDialog.Add("Snacks", new DialogText("Snacks", "Nam, would you like to buy chips for the evening?", "SNACKS", true)); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateDialog(string name)
    {
        DialogText current = this.allDialog[name];
        nameText.text = current.title;
        questionText.text = current.question;
        this.dialogCanvas.enabled = true;
        buttonYes.onClick.AddListener(() => TaskClick(true, current.type));
        if (!current.requiresAnswer)
        {
            GameObject.Find("No").SetActive(false);
        }
        else
        {
            GameObject.Find("No").SetActive(true);
            GameObject.Find("No").GetComponent<Button>().onClick.AddListener(() => TaskClick(false, current.type));
        }

    }

     void TaskClick(bool doIt, string type)
    {
        if (doIt)
        {
            Debug.Log("Just do it!");
            GameObject inventory = GameObject.FindWithTag("Inventory");
            if (type == "PIZZA")
            {
                if (inventory.GetComponent<InventoryScript>().money >= 10)
                {
                    inventory.GetComponent<InventoryScript>().pizza = true;
                    inventory.GetComponent<InventoryScript>().MoneyChange(-10);
                }
            }
            else if (type == "SNACKS")
            {
                if (inventory.GetComponent<InventoryScript>().money >= 10)
                {
                    inventory.GetComponent<InventoryScript>().snacks = true;
                    inventory.GetComponent<InventoryScript>().MoneyChange(-10);
                }
            }
            else if (type == "DRINKS")
            {
                if (inventory.GetComponent<InventoryScript>().money >= 10)
                {
                    inventory.GetComponent<InventoryScript>().drinks = true;
                    inventory.GetComponent<InventoryScript>().MoneyChange(-10);
                }
            }
            else if (type == "VEGETABLES")
            {
                if (inventory.GetComponent<InventoryScript>().money >= 10)
                {
                    inventory.GetComponent<InventoryScript>().vegetables = true;
                    inventory.GetComponent<InventoryScript>().MoneyChange(-10);
                }
            }

        }
        else
        {
            Debug.Log("Dont do it");
        }
        this.dialogCanvas.enabled = false;
    }

}
