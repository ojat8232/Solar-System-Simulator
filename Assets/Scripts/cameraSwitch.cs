using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

    public Transform setPlayer;
    public static Transform Player;
    public static Camera camera1, camera2;
    public Camera firstCameera, secondCamera;
    public KeyCode TKey;
    public bool camSwitch = false;

  
        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))  //only activates if the right mouse button is pressed 
            {
                camSwitch = !camSwitch;
            camera1.gameObject.SetActive(camSwitch);
            camera2.gameObject.SetActive(!camSwitch);
        }


        //void Start()
        //{
        //    camera1 = firstCameera;
        //    camera2 = secondCamera;
        //}

        //private void OnMouseOver()
        //{
        //    if (Input.GetMouseButtonDown(1))  //only activates if the right mouse button is pressed 
        //    {


            }
}