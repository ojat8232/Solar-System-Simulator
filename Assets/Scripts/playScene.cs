using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using start;

public class playScene : MonoBehaviour {

    start.Play toPlay = new start.Play();

    public void pausePlay()
        {
        toPlay.ToPlay();
    }
        
}
