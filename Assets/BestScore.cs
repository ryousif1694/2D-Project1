using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    static private TextMeshProUGUI Text;
    static private int point = 100;
    private TextMeshProUGUI txtCom;
    public bool resetBestScore = false;
    void Awake()
        {
            Text = GetComponent<TextMeshProUGUI>();

            if (PlayerPrefs.HasKey("BestScore"))
            {
                result = PlayerPrefs.GetInt("BestScore");
            }
            PlayerPrefs.SetInt("BestScore", result);
        }
        static public int result{
            get { 
            return point;
        }
            private set
            {
                point = value;
                PlayerPrefs.SetInt("BestScore", value);

                if (Text!= null)
                {
                    Text.text = "Best Score: " + value.ToString("#,0");
                }
            }
        }

        static public void TRY_SET_BEST_SCORE(int goalScore)
        {
          if (result >= goalScore)
         {
            return;
         }
            result = goalScore;
         }
        
    }

