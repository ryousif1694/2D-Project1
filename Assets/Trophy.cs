using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    [SerializeField] float timer = 4f;
    public GameObject trophyPre;

    CurrentScore cscore;

    GameObject trophy;
    public GameObject score;
    public int trophyTouch = 0;

    public float cameraBoundary = -10f;
    public float movementOfItem = 3f;
    Vector3 currentPosition;

    
    private void Start()
    {
        cscore = score.GetComponent<CurrentScore>();
    }
   
    void Update()
    {
        //
        Vector3 currentPosition = transform.position;
      
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //the reason as to enabling a box collider for trophy is to detect anything that would collide with the trophy 
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
        BestScore.TRY_SET_BEST_SCORE(cscore.current);
       
        resetPosition();
    }
    void resetPosition()
    {
        int r = Random.Range(-5, 5);
        this.transform.position = new Vector3(r, 3.1f, 4f);
      
        timer = 0.2f;
    }
}



