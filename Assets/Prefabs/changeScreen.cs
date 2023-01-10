using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScreen : MonoBehaviour
{

    public Transform setPlayer;
    public static Transform Player;
    public static Camera camera1, camera2;    //the main camera and the camera for the edit screen
    public Camera firstCameera, secondCamera;  //setters for the camera1 and camera2
    public bool initialise; //allows me to chose which gameobject sets the gameobjects for the class
    public GameObject setPlanetCamera;  //holds the planets PlanetCamera to alllow planetCamera to be set
    public static GameObject planetCamera;  //holds the planetCamera attached to the planet being editted
    public static GameObject UIcanvas;  //holds the gameobject of the canvas for adding planets
    public GameObject setUIcanvas;  //allows UIcanvas to be set

    //acts as a setter for all the gameobjects interacted with in this class
    void Start()
    {
        if (initialise == true)
        {
            camera1 = firstCameera;  
            camera2 = secondCamera;
            Player = setPlayer;
            UIcanvas = setUIcanvas;
        }
    }

    //works when planets are right-clicked to bring up the edit screen
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))  //only activates if the right mouse button is pressed 
        {
            camera1.gameObject.SetActive(true);  //sets camera1 to be active
            camera2.gameObject.SetActive(false);  //sets camera2 to be inactive
            //UIcanvas.gameObject.SetActive(false);
            UIcanvas.GetComponent<Canvas>().enabled = false;  //disables the canvas holding the add screen controls
            planetCamera = setPlanetCamera;  //sets the planet camera to be the one attached to the planet being editted
            

        }
    }

    //works when the exit button on the edit screen is pressed
    public void onCLick()
    {
        camera2.gameObject.SetActive(true);  //reactivates the main camera
        planetCamera.gameObject.SetActive(false);  //sets the planet camera to inactive
        //UIcanvas.gameObject.SetActive(true);
        UIcanvas.GetComponent<Canvas>().enabled = true;  //reactivates the the canvas holding the add screen contols
    }
}
