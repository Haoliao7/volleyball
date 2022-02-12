using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{

    public Rigidbody rb;

    public Vector3 setting;
    Vector3 startingPoint;

    bool inside = false;


    public GameObject InText;
    public GameObject OutText;
    public GameObject MissText;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        SetTheBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.5f )
        {
            ResetBall();
        }
        
    }

    void SetTheBall()
    {
        rb.AddForce(setting);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Court")
        {
            InText.SetActive(true);
            GameManager.score++;
            if (GameManager.highScore < GameManager.score)
            {
                GameManager.highScore = GameManager.score;
            }
            inside = true;
        }
    }

    private void ResetBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = startingPoint;
        SetTheBall();

        

        if(inside == false)
        {
            GameManager.score = 0;
        }
        if(Hitted.hitted == false)
        {
            MissText.SetActive(true);
        }
        else
        {
            if (inside == false)
            {
                OutText.SetActive(true);
            }
        }

        inside = false;
        Hitted.hitted = false;
        Invoke("CancelText", 0.25f);

    }

    void CancelText()
    {
        InText.SetActive(false);
        OutText.SetActive(false);
        MissText.SetActive(false);
    }

}
