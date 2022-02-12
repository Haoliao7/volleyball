using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int highScore;
    public static int score;


    //singleton pattern, set a variable of the type GameManager and call it instance
    private static GameManager instance;

    //in case some variables of this game manager isn't static, we'll need a reference to it
    public static GameManager FindInstance()
    {
        return instance;
    }


    private void Awake()
    {
        //if we already have a main game manager and this main manager is not this instance of the class
        if (instance != null && instance != this)
        {
            Destroy(this); // then destroy this
        }
        else //if we do not have a main game manager
        {
            instance = this;//make this the main game manager
            DontDestroyOnLoad(gameObject);//and do not destroy this game object when we load new scenes
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
