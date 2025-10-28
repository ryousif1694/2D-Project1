using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    //this is a Text object made to reference the TextMeshProUGUI 
    static private TextMeshProUGUI Text;
    //this is the never changing score that would be 
    static private int point = 100;
 
    void Start()
        {
            //The component of the TextMeshProUGUI is assigned to Text object 
            Text = GetComponent<TextMeshProUGUI>();
            //checks if PlayerPrefs has best score reference occurs and if so 
            if (PlayerPrefs.HasKey("BestScore"))
            {
            //the integer value from best score would be reterieved by using getInt function of PlayerPrefs and stored into result 
                result = PlayerPrefs.GetInt("BestScore");
            }
            //this now sets the best score with the result 
            PlayerPrefs.SetInt("BestScore", result);
        }
        static public int result{
          
            private 

            set{
                //point would initialized to value where in set it contains the numbers that are given to point in a variable way 
                point = value;
                //this would the integer value that is set for best score for PlayerPrefs 
                PlayerPrefs.SetInt("BestScore", value);
                
                Text.text = ("Best Score: " ) + value.ToString("#,0");
            }
            get{
            //this would reterieve and rteurn the point there are 
            return point;
            }
    }

        static public void BestScoreAttempt(int goalScore)
        {
        //this condition would check if the result is greater than the score that the player is aiming for called goalScore, then return
          if (result >= goalScore)
         {
            //this would get out of this condition 
            return ;
         }
          //and the goalScore would be assigned to result or else best score would be stuck at 0
            result = goalScore;
         }
        
    }

