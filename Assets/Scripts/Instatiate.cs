using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instatiate : MonoBehaviour {

    bool tool = false;  //enables the tool to add planets
    bool cometTool = false;  //enables the tool to add comets
    bool starTool = false;  //enables the tool to add stars
    public Camera main;  //the camera from which the coordinates to instantiate the planets is taken
    public Rigidbody planetObj;  //the planet prefab
    public Rigidbody starObj;  //the star prefab
    public Rigidbody cometObj;  //the comet prefab
    public int planetCount = 0;

    void Update()
    {

        if (tool == true && Input.GetKeyDown(KeyCode.Mouse0))  //checks wether to instantiate a planet
        {
            planetCount += 1;
            Rigidbody rbObj;
            float y = Input.mousePosition.y;  //gets the y position of the mouse
            float x = Input.mousePosition.x;  //gets the x position of the mouse
            rbObj = Instantiate(planetObj, main.ScreenToWorldPoint(new Vector3(x, y, 100)), transform.rotation) as Rigidbody;  //creates a new planet object at the position of the mouse
            rbObj.name = "Planet" + planetCount.ToString();
        }

        if (starTool == true && Input.GetKeyDown(KeyCode.Mouse0))  //checks wether to instantiate a star
        {
            Rigidbody rbObj; 
            float y = Input.mousePosition.y;  //gets the y position of the mouse
            float x = Input.mousePosition.x;  //gets the x position of the mouse
            rbObj = Instantiate(starObj, main.ScreenToWorldPoint(new Vector3(x, y, 100)), transform.rotation) as Rigidbody;  // creates a new star object at the position of the mouse
        }

        if (cometTool == true && Input.GetKeyDown(KeyCode.Mouse0))  //checks wether to instantiate a comet
        {
            Rigidbody rbObj;
            float y = Input.mousePosition.y;  //gets the y position of the mouse
            float x = Input.mousePosition.x;  //gets the x position of the mouse
            rbObj = Instantiate(cometObj, main.ScreenToWorldPoint(new Vector3(x, y, 100)), transform.rotation) as Rigidbody;  //creates a new comet object at the position of the mouse
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))  //resets the tools if the right mouse button is pressed
        {
            tool = false;
            starTool = false;
            cometTool = false;
        }

    }
        
    public void ToInstaiatePlanet()
    {
        if (tool == false && starTool == false && cometTool == false)  //allows planetTool to be set to true if all other tools are set to false
            {
            tool = true;
        }
        else
        {
            tool = false;
        }
    }

    public void ToInstantiateStar()
    {
        if (tool == false && starTool == false && cometTool == false)  //allows starTool to be set to true if all other tools are set to false
        {
            starTool = true;
        }
        else
        {
            starTool = false;
        }
    }
    
    public void ToInstantiateComet()
    {
        if (tool == false && starTool == false && cometTool == false)  //allows cometTool to be set to true if all other tools are set to false
        {
            cometTool = true;
        }
        else
        {
            cometTool = false;
        }
    }
}
