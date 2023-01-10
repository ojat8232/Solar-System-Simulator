using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class save : MonoBehaviour
{
    public static List<save> Planets;  //holds a list of all the planets in the simulation
    public static List<save> Stars;  //holds a list of all the stars in the simulation
    public static List<save> Comets;  //holds a list of all the comets in the simulation
    public static Stack<GameObject> undoStack = new Stack<GameObject>();  //holds a stack of the gameobjects, in the order they were added.


    //saves a file of the current objects in the simulation
    public void SaveFile()
    {
        string path = "Planetsave.txt";  //stores the filepath of the file
        StreamWriter writer = new StreamWriter(path);  //creates the new file
        int sizeOfList = Planets.Count;  //stores the number of planets in the simulation
        writer.WriteLine(sizeOfList);  //writes this number to the file

        foreach (save Planet in Planets)  //writes each planet's information to the file
        {
            string size = Planet.gameObject.transform.localScale.x.ToString();  //converts the size of the object to a string
            Rigidbody rbPlanet = Planet.gameObject.GetComponent<Rigidbody>();  //gets the rigidbody component of the planet
            string mass = rbPlanet.mass.ToString();  //converts the planets mass to a string so it  can be written to the file
                
            Vector3 pos = Planet.transform.position; //converts the planets mass to strings so it  can be written to the file
            string x = pos.x.ToString();
            string y = pos.y.ToString();
            string z = pos.z.ToString();
            writer.WriteLine(x + "," + y + "," + size + "," + mass); //writes all the planets information to the file
        }
        writer.Close(); //closes the file

        //repeats the process but for the stars
        path = "Starsave.txt";
        StreamWriter StarWriter = new StreamWriter(path);
        sizeOfList = Stars.Count;
        StarWriter.WriteLine(sizeOfList);
        foreach (save Star in Stars)
        {
            Vector3 pos = Star.transform.position;
            string x = pos.x.ToString();
            string y = pos.y.ToString();
            string z = pos.z.ToString();
            StarWriter.WriteLine(x + "," + y);
        }
        StarWriter.Close();

        //repeats the process but for comets
        path = "Cometsave.txt";
        StreamWriter cometWriter = new StreamWriter(path);
        sizeOfList = Comets.Count;
        cometWriter.WriteLine(sizeOfList);
        foreach (save comet in Comets)
        {
            Vector3 pos = comet.transform.position;
            string x = pos.x.ToString();
            string y = pos.y.ToString();
            string z = pos.z.ToString();
            cometWriter.WriteLine(x + "," + y);
        }
        cometWriter.Close();

    }

    //adds the different types of objects to a list so that they can be saved later
    void OnEnable()
    {
        string name = gameObject.name;  //gets the name of the object
        if (name.IndexOf("Star") > -1)  //if it contains Star the object gets added to the stars list
        {
            if (Stars == null)
            {
                Stars = new List<save>();
            }
            Stars.Add(this);
            undoStack.Push(gameObject);  //adds the object to the undo stack
        }
        else if (name.IndexOf("Planet") > -1) //if it contains Star the object gets added to the planets list
        {
            if (Planets == null)
                Planets = new List<save>();
            Planets.Add(this);
            undoStack.Push(gameObject);  //adds the object to the undo stack
        }
        else if (name.IndexOf("Comet") > -1)  //if it contains Star the object gets added to the comets list
        {
            if (Comets == null)
                Comets = new List<save>();
            Comets.Add(this);
            undoStack.Push(gameObject);  //adds the object to the undo stack
        }
    }

    //removes the object from the lists when the object is destroyed
    private void OnDisable()
    {
        if (name.IndexOf("Star") > -1)
        {
            Stars.Remove(this);
        }
        else if (name.IndexOf("Planet") > -1)
        {
            Planets.Remove(this);
        }
        else if (name.IndexOf("Comet") > -1)
        {
            Comets.Remove(this);
        }
        Planets.Remove(this);
    }

    public void undo()
    {
        GameObject objToDestroy = undoStack.Pop();  //pops the last object from the stack
        Destroy(objToDestroy);  //destroys that object
    }
}


  