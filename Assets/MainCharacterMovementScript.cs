using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterMovementScript : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb2dMainCharacter;
    private bool dogWalking;
    GameObject dog;
    Animator anm;
    Animator anmDog;
    SpriteRenderer sprRend;
    AudioSource audioSrc;
    GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        rb2dMainCharacter = this.GetComponent<Rigidbody2D>();
        rb2dMainCharacter.freezeRotation = true;
        dog = GameObject.FindGameObjectWithTag("Dog");
        anm = GetComponent<Animator>();
        anmDog = dog.GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();

        dogWalking = false;
        dog.SetActive(false);

        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = CalculateDirection();
        transform.Translate(direction * movementSpeed * Time.deltaTime);

        if (dogWalking == true)
        {
            audioSrc.Stop();
            float distance = movementSpeed * Time.deltaTime;
            dog.GetComponent<DogScript>().Walking(distance);
        }
        if (inventory.GetComponent<InventoryScript>().dogInInvertory == true)
        {
            dogWalking = true;
            dog.SetActive(true);
        }

    }

    public Vector2 CalculateDirection()
    {
        Vector2 direction = Vector2.zero;
        anm.SetInteger("AnimationState", 0);
        if (dogWalking == true)
        {
            anmDog.SetInteger("AnimationDogState", 0);

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                direction.y += 1.0f;
                anm.SetInteger("AnimationState", 2);
                if (dogWalking == true)
                {
                    anmDog.SetInteger("AnimationDogState", 2);
                }
            }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f; 
            anm.SetInteger("AnimationState", 4);
            if (dogWalking == true)
            {
                anmDog.SetInteger("AnimationDogState", 4);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y -= 1.0f;
            anm.SetInteger("AnimationState", 1);
            if (dogWalking == true)
            {
                anmDog.SetInteger("AnimationDogState", 1);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
            anm.SetInteger("AnimationState", 3);
            if (dogWalking == true)
            {
                anmDog.SetInteger("AnimationDogState", 3);
            }
        }
        return direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "NeighbourDoor")
        {
            if (inventory.GetComponent<InventoryScript>().dogInInvertory == true 
            && dog.GetComponent<DogScript>().distanceReached == false)
            {
                inventory.GetComponent<InventoryScript>().Dog();
                dogWalking = true;
                dog.SetActive(true);
            }
            else if(inventory.GetComponent<InventoryScript>().dogInInvertory == true
            && dog.GetComponent<DogScript>().distanceReached == true)
            {
                inventory.GetComponent<InventoryScript>().Dog();
                inventory.GetComponent<InventoryScript>().MoneyChange(50);
                dogWalking = false;
                dog.SetActive(false);
                inventory.GetComponent<InventoryScript>().dogBarking = false;
            }
            else
            {
                dogWalking = false;
                dog.SetActive(false);
            }
            SceneManager.LoadScene("NeighborScene");
        }
        if (other.name == "ShopDoor")
        {
            if (dogWalking == false)
            {
                Debug.Log("Shop Shop!");
                SceneManager.LoadScene("StoreScene");
            }
            else if (dogWalking == true)
            {
                Debug.Log("No doggos allowed inside shop!");
            }
        }
        if(other.name == "HomeDoor")
        {
            if (dogWalking == false)
            {
                SceneManager.LoadScene("HomeScene");
            }
            else if (dogWalking == true)
            {
                Debug.Log("I don't want doghair inside..");
            }
        }
    }
}
