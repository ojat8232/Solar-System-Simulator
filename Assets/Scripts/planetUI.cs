using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planetUI : MonoBehaviour {
    public static GameObject Planet;  //holds the gameobject of the planet to be editted
    public static Rigidbody rbPlanet;  //holds the rigidbody of the gameobject Planet
    public float size { get; set; }  //holds the size the planet has to be changed to
    public float mass { get; set; }  //holds  the mass the planet ahs to be changed to
    public float time { get; set; }
    public float trailColour { get; set; }
    public GameObject planetCanvas;  //holds the canvas attached to the planet to bring up its edit screen
    public GameObject mainCanvas;  //holds the main canvas
    public GameObject thisPlanet;  //holds the gameobject attached to the planet so Planet can be set
    public Rigidbody rbThisPlanet;  //allows rbPlanet to be set
    public bool run;
    public GameObject setPlanetCamera;  //holds the planets PlanetCamera to alllow planetCamera to be set
    public static GameObject planetCamera;  //holds the planetCamera attached to the planet being editted
    public Text planetText;
    public Text massText;
    public static GameObject planetTrail;
    public GameObject setPlanetTrail;
    private bool trailBool = false;
    private TrailRenderer trail;
    public GameObject colourPlane;
    public bool trailButton;
    public Text trailText;
    public static Text staticTrailText;

    private void OnEnable()
    {
        if (trailButton == true)
        {
            staticTrailText = trailText;
        }
    }

    public void changeSize()
    {
        float z;  //holds the amount to change the z size of the camera by to correct its view to the new planet size

        //changes size of the planet
        Planet.transform.localScale = new Vector3(1, 1, 1) * size;  

        //keeps the camera the same size, instead of changing size with the planet
        planetCamera.transform.localScale = new Vector3(1, 1, 1);
        z = 7 - 2*(Planet.transform.localScale.z);
        planetCamera.transform.localPosition = new Vector3(0, 0, z);

        //translates the size of the planet into its 
        double radius =Mathf.Round( 6371 * (Mathf.Pow(2,size) - 1));  //converts the size of the planet in untiy to the actual size of the planet
        planetText.text = radius.ToString() + " km";  //displays the size of the planet in kilometres
    }

    public void Exit()
    {
        planetCamera.gameObject.SetActive(false);  //sets the planet camera to inactive
    }


    //changes the planets mass
    public void changeMass()
    {
        rbPlanet.mass = mass;  //sets the planets mass to the magnitude of the variable mass

    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))//if the planet is right-clicked
        {
            if (run == true)
            {
                Planet = thisPlanet;  //allows the menu to edit the planet that this setter was called from
                rbPlanet = rbThisPlanet;
                planetTrail = setPlanetTrail;
                planetCamera = setPlanetCamera;  //sets planet camera to be the planet camera attached to the planet being editted
                planetCamera.gameObject.SetActive(true);  //activates the planet camera
                trailBool = planetTrail.activeSelf;
                if (trailBool == true)
                {
                    staticTrailText.text = "Trail: enabled";
                }
                else
                {
                    staticTrailText.text = "Trail: disabled";
                }
            }
        }
    }

    private void Update()
    {
        double radius = Mathf.Round(6371 * (Mathf.Pow(2, Planet.transform.localScale.y) - 1));  //converts the planets mass in unity into the mass of the planet that its simulating
        planetText.text = radius.ToString() + " km";  //displays the mass of the planet next to the slider
    }
    
    //switches between showing the trail and not showing it
    public void showTrail()
    {
       if (trailBool == false)
        {
            planetTrail.gameObject.SetActive(true);
            trailBool = true;
            trailText.text = "Trail: enabled";
        }
      else
        {
            planetTrail.gameObject.SetActive(false);
            trailBool = false;
            trailText.text = "Trail: disabled";
        }
    }

    //changes the planets colour to green
    public void green()
    {
        Renderer rend = Planet.GetComponent<Renderer>();  //gets the renderer componenet of the planet
        rend.material.SetColor("_EmissionColor", Color.green);  //changes the emission colour to green
    }

    //changes the planets colour to blue
    public void blue()
    {
        Renderer rend = Planet.GetComponent<Renderer>();  //gets the renderer componenet of the planet
        rend.material.SetColor("_EmissionColor", Color.blue);  //changes the emission colour to blue
    }

    //changes the planets colour to red
    public void red()
    {
        Renderer rend = Planet.GetComponent<Renderer>();  //gets the renderer componenet of the planet
        rend.material.SetColor("_EmissionColor", Color.red);  //changes the emission colour to red
    }

    //changes the planets colour to magenta
    public void magenta()
    {
        Renderer rend = Planet.GetComponent<Renderer>();  //gets the renderer componenet of the planet
        rend.material.SetColor("_EmissionColor", Color.magenta);  //changes the emission colour to magenta
    }

    //changes the planets colour to cyan
    public void cyan()
    {
        Renderer rend = Planet.GetComponent<Renderer>();  //gets the renderer componenet of the planet
        rend.material.SetColor("_EmissionColor", Color.cyan);  //changes the emission colour to cyan
    }

    //changes  the time that the trail is active for
    public void changeTime()
    { 
        trail = planetTrail.GetComponent<TrailRenderer>();
        trail.time = time;
    }

    //this changes the colour of planet's tails delending on the position of the slider
    public void changeTrailColour()
    {
        Renderer rend = colourPlane.GetComponent<Renderer>();  //gets the renderer component of the plane to show the colour to the user
        trail = planetTrail.GetComponent<TrailRenderer>(); //get the trail renderer component of the planets trail 
        int intTrailColour = (int)trailColour;  //converts trailcolour to an integer so it can be used in the case statement
        switch(intTrailColour)
        {
            case 1:
                trail.material.SetColor("_EmissionColor", Color.blue); 
                rend.material.SetColor("_EmissionColor", Color.blue);  
                break;
            case 2:
                trail.material.SetColor("_EmissionColor", Color.red);
                rend.material.SetColor("_EmissionColor", Color.red);
                break;
            case 3:
                trail.material.SetColor("_EmissionColor", Color.magenta);
                rend.material.SetColor("_EmissionColor", Color.magenta);
                break;
            case 4:
                trail.material.SetColor("_EmissionColor", Color.cyan);
                rend.material.SetColor("_EmissionColor", Color.cyan);
                break;
            case 5:
                trail.material.SetColor("_EmissionColor", Color.yellow);
                rend.material.SetColor("_EmissionColor", Color.yellow);
                break;
            case 6:
                trail.material.SetColor("_EmissionColor", Color.white);
                rend.material.SetColor("_EmissionColor", Color.white);
                break;
            case 7:
                trail.material.SetColor("_EmissionColor", Color.green);
                rend.material.SetColor("_EmissionColor", Color.green);
                break;
        }
    }

}

