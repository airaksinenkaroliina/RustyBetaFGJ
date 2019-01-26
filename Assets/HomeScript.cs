using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start home script");
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
        Canvas dialogCanvas = GameObject.Find("HomeCanvas").GetComponent<Canvas>();
        DialogScript dialogScript = GameObject.Find("HomeDialog").GetComponent<DialogScript>();
        Debug.Log(dialogScript.nameText.text);
        Debug.Log(dialogScript.questionText.text);
        if (name == "Sofa")
        {
            Debug.Log("Im a sofa");
            dialogCanvas.GetComponent("DialogName");
            dialogScript.UpdateDialog("DudeHungry");
            SceneManager.LoadScene("NeighborScene");
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
    }
}
