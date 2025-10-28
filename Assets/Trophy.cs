using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    //there is a timer that is set to four seconds 
    [SerializeField] float timer = 4f;
    public GameObject trophyPre;

    CurrentScore cscore;

    GameObject trophy;
    public GameObject score;
    //the amount of trophy touches is initlaized to 0 at the beginning 
    public int trophyTouch = 0;

    //there is a camera boundary at -10 for the z axis so all objects would be shown and once passed this boundary then they would go to their inital point 
    public float cameraBoundary = -10f;
    //this is how fast the trophy gets to move 
    public float movementOfItem = 3f;
    Vector3 currentPosition;


    private void Start()
    {
        //this is a reference to CurrentScore script to know the current score from the start and update it with the lastest version of it 

        cscore = score.GetComponent<CurrentScore>();
    }
   
    void Update()
    {
        //this is the currentPosition with the vector 3, whcih are for x axis, y axis and z axis initlaized to transform position to reterieve the most current position 
        Vector3 currentPosition = transform.position;
      //this is a timer that counts down until it reaches zero, so it is decrementing 
        timer -= Time.deltaTime;
        //this checks if timer is less than 0 and if so then 
        if (timer <= 0)
        {
            // a box collider would be enabled for trophy is to detect anything that would collide with the trophy 
            this.GetComponent<BoxCollider>().enabled = true;
            //current position at the z axis is incrementing in the negative side in order to be closer to the camera 
            currentPosition.z += -1*(movementOfItem * Time.deltaTime);
            //this updates the transform psotion with the current position 
            transform.position = currentPosition;
            //checks if current position at the z axis is less then the camera boundary, then that means that the trophy has passed the range,
            //so reset position of the trophy needs to be done by the calling of the resetPosition function 
            if (currentPosition.z < cameraBoundary)
            {
                resetPosition();
            }
        }
    }
    void OnTriggerEnter(Collider obj)
    {
       //the object that it is collided with is the soccer ball 
        GameObject collidedWith = obj.gameObject;

        //this would increment the current score by 100 each time the trophy is touched
        cscore.current += 100;

        cscore.setText();
        trophyTouch += 1;
        //this is reterieving the new current score as the best score if possible 
        BestScore.BestScoreAttempt(cscore.current);       
        resetPosition();
    }
    void resetPosition()
    {
        //r is initialized to rnadom range for the x-axis, so that when the object is regenerated, it happens within this range only randomly 
        int r = Random.Range(-5, 5);
        //when the trophy resets, its x-axis is randomly generated within random range where 3.1f for the y-axis in which the trophy will always be with this number and 4f for z axis for the depth of the trophy. 
        this.transform.position = new Vector3(r, 3.1f, 4f);
      //this is a timer for when the trophy would start to reappear to slide. 
        timer = 0.2f;
    }
}



