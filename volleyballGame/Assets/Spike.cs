using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Vector3 from;
    public Vector3 to;

    float spiketime;
    public float spikeSpeed;

    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spiketime += spikeSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //gameObject.GetComponent<Animator>().enabled = true;

            myAnimator.SetTrigger("hit");

            //transform.eulerAngles = Vector3.Lerp(from, to, spiketime);
        }
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
           
           //transform.rotation = new Quaternion(0, 38.624f, 0 ,0);
           // transform.eulerAngles = Vector3.Lerp(from, to, spiketime);
        }*/

    }

    


}
