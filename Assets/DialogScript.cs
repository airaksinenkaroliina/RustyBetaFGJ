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
        buttonNo.GetComponentInChildren<Text>().text = "Nooooo";
        buttonYes.GetComponentInChildren<Text>().text = "OK ok oko ko";


        this.dialogCanvas = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        Debug.Log(this.dialogCanvas.enabled);
        dialogCanvas.enabled = false;
        Debug.Log(this.dialogCanvas.enabled);
        this.allDialog = new Dictionary<string, DialogText>();
        this.allDialog.Add("DudeHungry", new DialogText("Joku makaa sohvalla", "Eilisillan bileet on menny myöhään ja kaverilla on kaamea darra. Se vaan örisee, että nälkä ois", "DUDE", false));
        this.allDialog.Add("Dude", new DialogText("Darramättö pelastaa", "Kiitos ruuasta, voisin lähteä kotiin mutta mun puhelin on hukassa...", "DUDE", false));
        this.allDialog.Add("FridgeEmpty", new DialogText("Jääkaappi on tyhjä", "Meeeh, ei herkkuja, mitä tehdä?", "FRIDGE", false));
        this.allDialog.Add("Fridge", new DialogText("Jääkaappi täytetty", "Jes, jääkaappi täytetty herkuilla, rauhallinen ilta pelastettu", "FRIDGE", false));
        this.allDialog.Add("Backbag", new DialogText("Reppu", "Kas, repusta löyty puhelin, tää ei näytä omalta. Ota puhelin repusta?", "BAGBACK", true));
        this.allDialog.Add("Neighbor", new DialogText("Naapuri ovella", "Hei, olen kipeänä ja Remppa-koira pitäisi viedä ulos, voisitko käydä kävelyttämässä Remppaa?", "NEIGHBOR", true));
        this.allDialog.Add("Remppa", new DialogText("Wuff wuffff", "Wuff wufffff wuffffff", "DOG", false));
        this.allDialog.Add("Vegetables", new DialogText("Vegetables", "Haluatko ostaa tuoreita ja terveellisiä vihanneksia?", "VEGETABLES", true));
        this.allDialog.Add("Pizza", new DialogText("Pizza", "Haluatko ostaa mehevän pizzan?", "PIZZA", true));
        this.allDialog.Add("Drinks", new DialogText("Drinks", "Haluatko ostaa virkistävää Jaffaa?", "DRINKS", true));
        this.allDialog.Add("Snacks", new DialogText("Snacks", "Nom Nom, haluatko ostaa sipsejä leffailtaa varten?", "SNACKS", true));

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
        buttonNo.onClick.AddListener(() => TaskClick(false));
        buttonYes.onClick.AddListener(() => TaskClick(true));

    }

     void TaskClick(bool doIt)
    {
        Debug.Log("You have clicked a button, name is below");
        if (doIt)
        {
            Debug.Log("Just do it!");
        }
        else
        {
            Debug.Log("Dont do it");
        }
        this.dialogCanvas.enabled = false;
    }

}
