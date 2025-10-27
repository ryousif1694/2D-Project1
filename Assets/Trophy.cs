using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    [SerializeField] float timer = 4f;
   
    public GameObject conePre;
    public GameObject trophyPre;

    public float changing = 2f;
    public float itemExist = 2f;

    CurrentScore cscore;

    GameObject trophy;
    public GameObject scoreGO;
    public int trophyTouch = 0;

    public float cameraBoundary = -10f;
    public float movementOfItem = 3f;
    Vector3 currentPosition;

    
    private void Start()
    {
        cscore = scoreGO.GetComponent<CurrentScore>();
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
       //this is the declaration of gameObject class for object collidedwith 
       //checks 
        GameObject collidedWith = obj.gameObject;
        
       
        cscore.current += 100;
        cscore.setText();
        trophyTouch += 1;

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



