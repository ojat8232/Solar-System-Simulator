using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class Gravity : MonoBehaviour
{
    public static bool pausePlay = false;
    public static float G;  // sets the value of the gravitational constant
    public float g { get; set; }
    public static List<Gravity> Planets;  //the list that holds all the objects that exert gravity
    public Rigidbody rb;
    public static GameObject planetCanvas;
    public static GameObject mainCanvas;
    public bool run;
    public GameObject setPlanetCanvas;
    public GameObject setMainCanvas;
    public LineRenderer initialVelocityLine;
    public static Camera main;
    public Camera setCamera;
    public static bool addVelocity = false;
    private int localAddVelocity = 0;
    Vector3 planetVelocity = new Vector3(0, 0, 0);
    private bool saveVelocity = false;
    public static bool delete = false;
    public bool stellarObject;  //true if the object is a stellar object
    private int deleteCount = 0;
    public Text Gtext;
    public Text playText;

    //deletes the object if delete is true and it is a stellar object, also resets delete to false when all object have been deleted
    private void Update()
    {
        if (delete == true & stellarObject == true)  //destroys the game object if delete is true and the object s a stellar object
        {
            Destroy(gameObject);
        }

        if (deleteCount == 100)  //makes sure all objects have been destroyed before resetting delete
        {
            delete = false;  //resets delete
            deleteCount = -1;  //resets delete count
        }
        deleteCount += 1;  //increments delete count
    }
                           
    void FixedUpdate()  //goes through the attractors list to calculate the force this object is exerting on each object
    {      
        if (run == true)
        {
         
            foreach (Gravity Planet in Planets)
                if (Planet != this) //prevents the object from trying to attract itself                                    
                {
                    if (pausePlay == true)  //stops the gravity function from running when the simulation is paused
                    {
                        if (localAddVelocity == 0)
                        {                            
                            giveVelocity();
                            saveVelocity = true;
                        }
                        GiveForce(Planet); //runs the attract function 
                    }
                    else
                    {
                        localAddVelocity = 0;                        
                        if (saveVelocity == true)
                        {  
                            Destroy(initialVelocityLine);
                            savePlanetVelocity();
                        }
                    }

                }
        }
    }

    //adds the object to the attrractors list
    void OnEnable()
    {
        if (run == true)
        {
            //creates the attractors list if it does not exist
            if (Planets == null)
            {
                Planets = new List<Gravity>();  //creates the attractors list
            }
            Planets.Add(this);  //adds the object to the planets list
            initialVelocityLine.SetPosition(0, rb.position);  //sets the postion of the start of the initial velocity line to the same postion as the planet
            initialVelocityLine.SetPosition(1, rb.position);  //sets the postion of the end of the initial velocity line to the same postion as the planet
        }
        else
        {
            mainCanvas = setMainCanvas;
            planetCanvas = setPlanetCanvas;
            main = setCamera;
        }
    }

    //removes the object from the attractors list if it is deleted
    private void OnDisable()
    {
        Planets.Remove(this);  //removes the object from the attractors list
    }

    //physics function
    void GiveForce(Gravity objToAttract)
    {
        Vector3 accel;  //Holds the acceleration of the object
        Rigidbody rbToAttract = objToAttract.rb;
        Vector3 force;
        float distance;  //Holds the distance between the objects
        Vector3 direction;  //Holds the direction and magnitude of the displacement between the objects
        float absForce;  //Holds the absolute value of the force

        direction = rb.position - rbToAttract.position;//Calculates the direction vector from the difference between position vectors of the two objects
        distance = direction.magnitude; // Calculates the distance between the objects using the absolute value of the displacement vector.

        absForce = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);   //calcultes the absolute value of the force using the gravity equation
        force = direction.normalized * absForce; //calculates the vector of the force using its absolute value and the direction vector normalised 
        accel = force / rbToAttract.mass;  //calculates the acceleration of the object using Newton's second Law
        rbToAttract.velocity = rbToAttract.velocity + accel;  //adds the acceleration to the velocity of the object
    }

    //destroys an object if it hits a star
    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;  //gets the name of the obejct that is being collided with
        string thisObjectName = gameObject.name;
        Rigidbody rbCollision = collision.gameObject.GetComponent<Rigidbody>();
        if(name.IndexOf("Star") > -1)  //checks if the name of the object contains Star
        {
            Destroy(gameObject);  //destroys this gameObject
        }
        if (name.IndexOf("Planet") > -1 &  thisObjectName.IndexOf("Planet") > -1)  //checks if both objects colliding are planets
        {
            if (string.Compare(name, thisObjectName) > 0)  //checks to see which planet name is larger
            {
                Vector3 size =  new Vector3(Mathf.Pow(Mathf.Pow(gameObject.transform.localScale.x, 3) + Mathf.Pow(collision.gameObject.transform.localScale.x, 3), (float)0.33333), Mathf.Pow(Mathf.Pow(gameObject.transform.localScale.y, 3) + Mathf.Pow(collision.gameObject.transform.localScale.y, 3), (float)0.33333), Mathf.Pow(Mathf.Pow(gameObject.transform.localScale.z, 3) + Mathf.Pow(collision.gameObject.transform.localScale.z, 3), (float)0.33333));  //makes the volume of the resultant planet equal to the sum of the volumes of the two initial planets
                
                rb.velocity = ((rb.velocity * rb.mass) + (rbCollision.velocity * rbCollision.mass) / (rb.mass + rbCollision.mass));  //conserves momentum throuhout the collision using m1v1 + m2v2 = mtvt

                rb.mass = rb.mass + rbCollision.mass;  //makes the resultant mass the sum of the two initial masses

                gameObject.gameObject.transform.localScale = size;  //changes the size of the object to the vector size
            }
            else
            {
                Destroy(gameObject);  //destroys the planet with the smaller name
            }
        }
    }

    //attached to the play buuton
    public void toPlay()
    {

        //switches the program to play if it is paused, and to be paused if it is playing
        if (pausePlay == false)
        {
            pausePlay = true;
            Time.timeScale = 1;
            playText.text = "Pause";
        }
        else
        {
            pausePlay = false;
            Time.timeScale = 0;
            playText.text = "Play";
        }
    }
    

    //stores the planets velocity when the simulation is paused
    private void savePlanetVelocity()
    {
        planetVelocity = rb.velocity;
        rb.velocity = new Vector3 (0, 0, 0);
    }

    //sets the position of the end of the velocity line
    private void OnMouseDrag()
    {       
        float y = Input.mousePosition.y;
        float x = Input.mousePosition.x;       
        initialVelocityLine.SetPosition(1, main.ScreenToWorldPoint(new Vector3(x, y, 100)));  //sets element 1 of the velocity line to the location of the mouse
    } 

    //adds any velocites to the planet that it should have at the start of the simulation or after pausing
    private void giveVelocity()
    {
        Vector3 initialVelocity;
        localAddVelocity = 1;
        initialVelocity = new Vector3 (initialVelocityLine.GetPosition(1).x - initialVelocityLine.GetPosition(0).x, initialVelocityLine.GetPosition(1).y - initialVelocityLine.GetPosition(0).y, 0);  //gets the difference in position of the initial velocity line form the object
        rb.velocity = initialVelocity + planetVelocity;  //adds the save velocity to the linn velocity
        initialVelocityLine.gameObject.SetActive(false);  //the initial velocity line is disabled
    }

    //sets delete to true if the delete button is pressed
    public void SetDelete()
    {
        delete = true; 
        //GetComponent<Image>().color = Color.red;
    }

    //changes the value of G to simulate different values of the gravitational constant
    public void ChangeG()
    {
        float tempg = g;
        g = (g * 9.529f * 0.001f);
        g = Mathf.Round(g);
        Gtext.text = (g.ToString() + "*10^-11");
        G = tempg;
    }

    //destroys the planets if the scrollwheel is pressed down
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(2))  //only activates if the right mouse button is pressed 
        {
            Destroy(gameObject);

        }
    }

}