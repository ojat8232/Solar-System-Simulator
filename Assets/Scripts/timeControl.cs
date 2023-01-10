using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControl : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 1; //changes the time scale of the simulation
        Time.fixedDeltaTime = 1;  //changes fixedDeltaTime to help the physics keep in time
    }

    public void Control(int time) //takes a time parameter to allow the speed of the simulation to be set
    {
        Time.timeScale = time; //changes the time scale of the simulation
        Time.fixedDeltaTime = time;  //changes fixedDeltaTime to help the physics keep in time
	}
}
