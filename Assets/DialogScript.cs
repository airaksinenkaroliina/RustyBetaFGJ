using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    public Text nameText;
    public Text questionText;
    public Button buttonYes;
    public Button buttonNo;
    private Canvas dialogCanvas;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "Hello hello";
        questionText.text = "What do you wanna do?";
        buttonNo.GetComponentInChildren<Text>().text = "No";
        buttonNo.GetComponentInChildren<Text>().text = "OK";
        this.dialogCanvas = GameObject.Find("HomeCanvas").GetComponent<Canvas>();
        Debug.Log(dialogCanvas.enabled);
        dialogCanvas.enabled = false;
        Debug.Log(dialogCanvas.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
