using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitted : MonoBehaviour
{

    public Rigidbody rb;

    public float power;

    public Vector3 hittingPoint;

    public float leftEdge;
    public float upEdge;
    public float rightEdge;
    public float downEdge;

    public static bool hitted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && (transform.position.y < upEdge && transform.position.y > downEdge) && (transform.position.x < leftEdge && transform.position.x >  rightEdge))
        {//if press space and the ball is in the right range of position
            rb.velocity = Vector3.zero; // set the velocity of the ball to 0
            rb.AddForce((transform.position - hittingPoint) * power); //addforce from the hitting point to the ball
            hitted = true;

        }
        
    }

    /* void OnCollisionEnter(Collision other)
     {
         if(other.gameObject.tag == "hand")
         {
             print("Points colliding: " + other.contacts.Length);
             print("First point that collided: " + other.contacts[0].point);
             print("Where is the ball " + transform.position);
             rb.velocity = Vector3.zero; // set the velocity of the ball to 0
             rb.AddForce((transform.position - (other.contacts[0].point)) * power);
             hitted = true;
         }

     }*/

    

   


}
