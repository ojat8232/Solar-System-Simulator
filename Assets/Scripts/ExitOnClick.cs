using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sub routine to exit the program
public class ExitOnClick : MonoBehaviour {

    public void OnApplicationQuit()
    {

        //stops the application from being closed if it is being run in the unity editor
#if UNITY_EDITOR //checks if the simulation is being run in the unity editor
        UnityEditor.EditorApplication.isPlaying = false;  //stops the simulation from playing
#else
        //closes the application
        Application.Quit (); 
#endif
    }
}
