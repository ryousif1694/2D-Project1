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
 
    public bool resetBestScore = false;
    void Awake()
        {
            //The component of the TextMeshProUGUI is assigned to Text object 
            Text = GetComponent<TextMeshProUGUI>();
            //checks if the 
            if (PlayerPrefs.HasKey("BestScore"))
            {
                result = PlayerPrefs.GetInt("BestScore");
            }
            PlayerPrefs.SetInt("BestScore", result);
        }
        static public int result{
            get { 
            //this would reterieve and rteurn the point there are 
            return point;
        }
            private set
            {
                //point would initialized to value where in set it contains the numbers that are given to point in a variable way 
                point = value;
                //this would use 
                PlayerPrefs.SetInt("BestScore", value);

                if (Text!= null)
                {
                    Text.text = "Best Score: " + value.ToString("#,0");
                }
            }
        }

        static public void TRY_SET_BEST_SCORE(int goalScore)
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

