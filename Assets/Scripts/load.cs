using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class Load : MonoBehaviour {
public Rigidbody Planet;
    public void LoadFile()
    {

        //List<Vector3> positions; 
        string path = "save.txt";

        StreamReader reader = new StreamReader(File.OpenRead(path));
        //Rigidbody planetObj;
        reader.Read();
        string position = reader.ReadLine();
        string[] planetPositions = new string[2];
        planetPositions = position.Split();
        Vector3 pos;
        pos.x = float.Parse(planetPositions[0]);
        pos.y = float.Parse(planetPositions[1]);
        pos.z = float.Parse(planetPositions[2]);

        Rigidbody planetObj;
        planetObj = Instantiate(Planet, pos , transform.rotation) as Rigidbody;


    }

}
