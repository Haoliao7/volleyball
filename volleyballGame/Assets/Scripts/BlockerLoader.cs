using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BlockerLoader : MonoBehaviour
{
    public string fileName;

    string[] level;

    public int blockerOrder;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); // read the txt file
        string contentOfFile = reader.ReadToEnd(); // store the content into a string
        reader.Close(); // close the reader

        char[] newLineChar = { '\n' }; 
        level = contentOfFile.Split(newLineChar); // separete every line into different strings
        blockerOrder = 0; // set the oreder to 0
        MakeNewBlockers(); 
    }

    // Update is called once per frame
    void Update()
    {
       
             

        
    }

    public void MakeNewBlockers() 
    {
        

        char[] blockerArray = level[blockerOrder].ToCharArray(); //store every character in a string into a character array
        for (int i = 0; i < blockerArray.Length; i++)
        {
            if (blockerArray[i] == 'X') //if the character is X
            {
                //Make a blocker
                GameObject blocker = Instantiate(Resources.Load("Blocker")) as GameObject;
                blocker.transform.position = new Vector3(
                    4 - transform.localScale.x /2* i, // set their x position according to their width
                    2.06f,
                    -0.21f);
            }

        }

        if(blockerOrder == level.Length - 1) // if the array reach the end
        {
            blockerOrder=0; // reset the index
        }
        else
        {
            blockerOrder++; // change the level
        }

    }


}
