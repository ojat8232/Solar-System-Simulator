using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Load1 : MonoBehaviour {

    public Rigidbody Planet;  //holds the planet prefab
    public Rigidbody Star;  //holds the star prefab
    public Rigidbody Comet;  //holds the comet prefab

    public void LoadFile()    //reads the file and outputs the objects back into the simulation
    {
       

        string path = "Planetsave.txt";     //stores the filepath to the save file
        StreamReader reader = new StreamReader(File.OpenRead(path));   //opens the file
        string sizeOfList = reader.ReadLine();  //reads the first line of the file and stores the result, which is the number of planets in the file + 1
        int sizeOfListInt = int.Parse(sizeOfList);  //converts this value into an integer
        sizeOfListInt = sizeOfListInt - 2;  //converts the value so it can be used to access the correct planets

        if (sizeOfListInt > -1)  //only allows the program to proceed if any planets were saved
        {
            for (int x = 0; x <= sizeOfListInt; x++)    //scrolls through all the planets stored and instantiates them, and then gives them the correct properties
            {
                string position = reader.ReadLine();  //reads the next line of the file
                string[] planetPositions = new string[4];  //creates a new array to store the outputs of the file
                planetPositions = position.Split(',');  //splits the output of the file into the values seperated by the commas
                Vector3 pos;  //declares a new Vector
                pos.x = float.Parse(planetPositions[0]);  //sets the x value of the vector to the first value from the file converted into a float
                pos.y = float.Parse(planetPositions[1]);  //sets the y value of the vector to the second value from the file converted into a float
                pos.z = 0;  //sets the z value of the vector to 0
                Rigidbody planetObj;  //declares a new rigidbody (unity variable)
                planetObj = Instantiate(Planet, pos, transform.rotation) as Rigidbody;  //instantiates a new planet
                planetObj.mass = float.Parse(planetPositions[3]);  //changes the mass of the planet
                Vector3 size = new Vector3 (float.Parse(planetPositions[2]), float.Parse(planetPositions[2]), float.Parse(planetPositions[2]));  //assigns the x, y, and z valuse of the vector size to be the same value from the save file
                planetObj.gameObject.transform.localScale = size;   //changes the size of the planet
            }
        }


        path = "Starsave.txt";  //stores the filepath to the savefile
        StreamReader starReader = new StreamReader(File.OpenRead(path));  //opens the file
        sizeOfList = starReader.ReadLine();  //reads the first line of the file and stores the result, which is the number of stars in the file + 1
        sizeOfListInt = int.Parse(sizeOfList);  //converts this value into an integer
        sizeOfListInt = sizeOfListInt - 2;  //converts the value so it can be used to access the correct planets

        if (sizeOfListInt > -1)  //only allows the program to proceed if any stars were saved
        {
            for (int x = 0; x <= sizeOfListInt; x++)  //scrolls through all the planets stored and instantiates them, and then gives them the correct properties
            {
                string position = starReader.ReadLine();  //reads the next line of the file
                string[] starPositions = new string[2];  //creates a new array to store the outputs of the file
                starPositions = position.Split(',');  //splits the output of the file into the values seperated by the commas
                Vector3 pos;  //declares a new Vector
                pos.x = float.Parse(starPositions[0]);  //sets the x value of the vector to the first value from the file converted into a float
                pos.y = float.Parse(starPositions[1]);  //sets the y value of the vector to the second value from the file converted into a float
                pos.z = 0;  //sets the z value of the vector to 0
                Rigidbody planetObj;  //declares a new rigidbody (unity variable)
                planetObj = Instantiate(Star, pos, transform.rotation) as Rigidbody;  //instantiates a new star
            }

        }


        path = "Cometsave.txt";  //stores the filepath to the savefile
        StreamReader cometReader = new StreamReader(File.OpenRead(path));  //opens the file
        sizeOfList = cometReader.ReadLine();  //reads the first line of the file and stores the result, which is the number of comets in the file + 1
        sizeOfListInt = int.Parse(sizeOfList);  //converts this value into an integer
        sizeOfListInt = sizeOfListInt - 2;  //converts the value so it can be used to access the correct planets

        if (sizeOfListInt > -1)  //only allows the program to proceed if any stars were saved
        {
            for (int x = 0; x <= sizeOfListInt; x++)  //scrolls through all the planets stored and instantiates them, and then gives them the correct properties
            {
                string position = cometReader.ReadLine();  //reads the next line of the file
                string[] cometPositions = new string[2];  //creates a new array to store the outputs of the file
                cometPositions = position.Split(',');  //splits the output of the file into the values seperated by the commas
                Vector3 pos;  //declares a new Vector
                pos.x = float.Parse(cometPositions[0]);  //sets the x value of the vector to the first value from the file converted into a float
                pos.y = float.Parse(cometPositions[1]);  //sets the y value of the vector to the second value from the file converted into a float
                pos.z = 0;  //sets the z value of the vector to 0
                Rigidbody planetObj;  //declares a new rigidbody (unity variable)
                planetObj = Instantiate(Comet, pos, transform.rotation) as Rigidbody;  //instantiates a new comet
            }

        }
    }
}
