using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperScript : MonoBehaviour
{

    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("diips");
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
        if (name == "Sofa") {
            Debug.Log("Im a sofa");
        } else if ( name == "Fridge") {
            Debug.Log("Im a fridge");
        }
    }
}
