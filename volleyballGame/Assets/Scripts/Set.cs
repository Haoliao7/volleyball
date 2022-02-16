using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    public static bool reset = false;

    public Rigidbody rb;

    public Vector3 setting;
    Vector3 startingPoint;

    bool inside = false;


    public GameObject InText;
    public GameObject OutText;
    public GameObject MissText;
    public GameObject BlockText;

    public BlockerLoader myLoader;



    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position; // record the starting point of the ball
       
        SetTheBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.5f )
        {
            ResetBall(); // if the ball fall below the court, reset it.
        }
        
    }

    void SetTheBall()
    {
        
        rb.AddForce(setting); //set the ball to make it fly toward the player
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Court") // if the ball touch the ground
        {
            InText.SetActive(true); // display "IN!"
            GameManager.score++; //socre+1
            if (GameManager.highScore< GameManager.score) // if your score is greater than the high score
            {
                GameManager.highScore = GameManager.score; // then you are the high score now
            }
            inside = true; 
        }else if(collision.gameObject.name == "Court(Yourside)") // if you get blocked
        {
            BlockText.SetActive(true); // display "Blocked!"
            Invoke("ResetBall", 1f);
        }

    }

    private void ResetBall()
    {
        //destory the old blockers
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Blocker");
        foreach (GameObject blocker in taggedObjects) {
            Destroy(blocker);
        }


        rb.velocity = Vector3.zero; // set the velocity to 0
        transform.position = startingPoint; // reset the position of the ball
        myLoader.MakeNewBlockers(); // make new blocker
        SetTheBall();


        if (inside == false) // if the ball didn't hit the court
        {
            GameManager.score = 0; // reset your score
        }
        if(Hitted.hitted == false) // if the player did't hit the ball
        {
            MissText.SetActive(true); // display "MISS!"
        }
        else
        {
            if (inside == false) // if the player did hit the ball but the ball didn't hit the ground
            {
                if (!BlockText.activeSelf)
                {
                    OutText.SetActive(true); // display "OUT!"
                }
            }
        }

        inside = false;
        Hitted.hitted = false;
        Invoke("CancelText", 0.25f); // hide the text

    }

    void CancelText()// hide the text
    {
        
        InText.SetActive(false);
        OutText.SetActive(false);
        MissText.SetActive(false);
        BlockText.SetActive(false);
    }

}
