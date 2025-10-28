using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
   CurrentScore cscore;
    public GameObject score;
   
    public GameObject conePre;
   //declaration of sound using AudioSource 
    public AudioSource sound;

    void Start()
   {
     cscore = score.GetComponent<CurrentScore>();
        Debug.Log(cscore.ToString());
    }

    void Update()
    {
      //this is the mouse control form of input 
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
        

        if (Mathf.Abs(conePre.transform.position.z - this.transform.position.z)<=0.01f)
        {

            sound.Play();
            Debug.Log("Cone passes ball");

        }
        

    }
   


}

