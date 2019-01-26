using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovementScript : MonoBehaviour
{
    public float MovementSpeed;
    private Rigidbody2D rb2dMainCharacter;
    private bool dogWalking;
    GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        rb2dMainCharacter = this.GetComponent<Rigidbody2D>();
        dogWalking = false;
        dog = GameObject.FindGameObjectWithTag("Dog");
        dog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = CalculateDirection();
        transform.Translate(direction * MovementSpeed * Time.deltaTime);

        if(dogWalking == true)
        {
            float distance = MovementSpeed * Time.deltaTime;
            dog.GetComponent<DogScript>().Walking(distance);
        }

    }
    public Vector2 CalculateDirection()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction.y += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered ");
        if (other.name == "Neighbour")
        {
            dogWalking = true;
            dog.SetActive(true);
        }
        if (other.name == "Shop")
        {
            if(dogWalking == false)
            { 
                Debug.Log("Shop Shop!"); 
            }
            else if(dogWalking == true)
            {
                Debug.Log("No doggos allowed inside shop!"); 
            }

        }
    }
}
