using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cones : MonoBehaviour
{
    //this timer is made so there cones would start after three seconds of game play 
    [SerializeField] float timer = 3f;
   //the movementOfItem is initialized to 3 to be the speed of the cones's movmeent 
    public float movementOfItem = 3f;
    //cone prefab game object 
    public GameObject conePre;

    CurrentScore cscore;
    BestScore bscore;
    //coneTouch is made and intilaized to 0 because the game starts at 0 being touched 
    public int coneTouch = 0;
    //the maximum amount that the cone can be touch is 3 where once it reaches three times, the game would restart
    public int coneMaxCountTouch = 3;
    public GameObject score;
    //this is the cameraBoundary intialized to -10 so the ball, cones and trophy would be shown and not go passed this 
    public float cameraBoundary = -10f;

    private void Start()
    {
        //this would reterieve the current score of the game from the start of the game 
        cscore = score.GetComponent<CurrentScore>();
    }

    void Update()
    {
        
        Vector3 currentPosition = transform.position;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            currentPosition.z += -1*(movementOfItem * Time.deltaTime);
            transform.position = currentPosition;

            if (currentPosition.z < cameraBoundary)
            {
                resetPosition();
            }
        }
        
    }
    void OnTriggerEnter(Collider obj)
    {
        //the collided with is the soccer ball 
        GameObject collidedWith = obj.gameObject;
        //this would decrement the current score by 100 when the cone would be touched 
        cscore.current -= 100;
        cscore.setText();
        //this would increment amount of times cone has been tocuhed 
        coneTouch += 1;
        
        //if coneTouch is more than 3 times, which is the maximum amount that the cone can be touched 
        if (coneTouch >= coneMaxCountTouch)
        {
          //this makes the cscore to be in the form a string in order for the current score to be shown 
            Debug.Log(cscore.ToString());
            //this would reload the scene to restart the game 
            SceneManager.LoadScene("MakeItToNet");
            //this would capture the new best score 
            BestScore.TRY_SET_BEST_SCORE(cscore.current);
        }
        //this calls the resetPosition function everytime 
        resetPosition();
    }
    void resetPosition()
    {
        //this is the random position that the cone would be in before it would start sliding where this contains the minimum 
        //range and the maximum range. 
        int r = Random.Range(-5, 5);
        //this would set the position of the cone at what r is initilaized to as the range for x-axis, it would be 0 for y to always be on the field and depth would go as far as 4 for z. 
        this.transform.position = new Vector3(r, 0f, 4f);
        //this is the timer for everytime the cone reappears 
        timer = 0.2f;
    }
}


