using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Vector3 from;
    public Vector3 to;

    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            

            myAnimator.SetTrigger("hit"); // if press space then trigger the animation to swing the player's arm

            //gameObject.GetComponent<Animator>().enabled = true;
            //transform.eulerAngles = Vector3.Lerp(from, to, spiketime);
        }
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
           
           //transform.rotation = new Quaternion(0, 38.624f, 0 ,0);
           // transform.eulerAngles = Vector3.Lerp(from, to, spiketime);
        }*/

    }

    


}
