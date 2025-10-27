using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cones : MonoBehaviour
{

    [SerializeField] float timer = 3f;
   
    public float movementOfItem = 3f;
    public GameObject conePre;
    public GameObject trophyPre;
    public float changing = 2f;
    public float itemExist = 2f;

    CurrentScore cscore;
    BestScore bscore;
    public int coneTouch = 0;
    public int coneMaxCountTouch = 3;
    public GameObject scoreGO;
    // Start is called before the first frame update
    private void Start()
    {
        cscore = scoreGO.GetComponent<CurrentScore>();
    }
    public float cameraBoundary = -10f;
    

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


