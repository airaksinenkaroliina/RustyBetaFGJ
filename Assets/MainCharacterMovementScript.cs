using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool musicPlay;

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
        musicPlay = true;
        audioSrc.Play();
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
        Debug.Log("entered ");
        if (other.name == "NeighbourDoor")
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
