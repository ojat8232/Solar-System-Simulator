using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gstartup : MonoBehaviour {
    public Text G;
	
    //initialises the starting value of the text box showing the value of G
	void Start ()
    {
        G.text = ("7*10^-11");
    }
	
}
