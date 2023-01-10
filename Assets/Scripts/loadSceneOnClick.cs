using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneOnClick : MonoBehaviour {

    //function to load a new scene
    public void LoadByIndex(int sceneIndex) //takes in an argument for the number of the new scene
    {
        SceneManager.LoadScene(sceneIndex); //loads the specified scene
    }


}
