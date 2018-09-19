using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public static int scene = 1;                                  //Current level number, expressed in game as "Day 1".
    public

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    static void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        /*
         switch (level)
         {
             case 1:
                 SceneManager.LoadScene("ToolLevel1");
                 break;
             case 2:
                 SceneManager.LoadScene("ToolLevel2");
                 break;
             default:
                 SceneManager.LoadScene("Main");
                 break;
         }
         */
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// elimina la escena actual y carga la siguiente escena en el orden.
    /// </summary>
    public static void nextScene()
    {
        //SceneManager.UnloadSceneAsync("ToolLevel1");
        scene += 1;
        InitGame();
    }

    public static void goToScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    
}
