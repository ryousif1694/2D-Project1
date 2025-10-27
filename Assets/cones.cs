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
        GameObject collidedWith = obj.gameObject;

        cscore.current -= 100;
        cscore.setText();
        coneTouch += 1;


        
        if (coneTouch >= coneMaxCountTouch)
        {
            Debug.Log(cscore.ToString());
            SceneManager.LoadScene("MakeItToNet");
            BestScore.TRY_SET_BEST_SCORE(cscore.current);
        }
        resetPosition();
    }
    void resetPosition()
    {
        int r = Random.Range(-5, 5);
        this.transform.position = new Vector3(r, 0f, 4f);
        timer = 0.2f;
    }
}


