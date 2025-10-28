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
     //this references the component of the script from the CurrentScore and assigns it to cscore to be current score at the start 
     cscore = score.GetComponent<CurrentScore>();
        //this would convert the numerical values from cscore to string 
        Debug.Log(cscore.ToString());
    }

    void Update()
    {
      //this is the mouse control form of input that is used to take in the position of the mouse 
        Vector3 mousePos2D = Input.mousePosition;
        //where the position of the mouse at z axis would have camera position at z axis subtracted from it to see the position of the camera to see how far the mouse needs to go in the form of 3D 
        mousePos2D.z = -Camera.main.transform.position.z;
        //this makes a convertion into 3D positon for game world space from 2D space of the screen 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //this is the location of the soccer ball that would stored into location
        Vector3 location = this.transform.position;
        //location at the x-axis would have mouse in 3D position space at x-axis assigned to it 
        location.x = mousePos3D.x;
        //this is the soccer ball position intilaized to the new location 
        this.transform.position = location;
        
        //this checks if cone prefab and the soccer ball game object have the close z position values 
        //this would be done using the absolute value to make the distance always positive
        //where "this" is the positon of the soccer ball that is being subtracted from the position of cone prefab at z axis 
        //and this condition checks if that value subtracted is less than or equal to 0.01 to see that the distance ebtwene the objects is little 
        if (Mathf.Abs(conePre.transform.position.z - this.transform.position.z)<=0.01f)
        {
            //this is a AudioSource object named sound calling the built in play function to play that would be playing when the distance is small, which means that it almost collided 
            sound.Play();
            Debug.Log("Cone passes ball");

        }
        

    }
   


}

