using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    
    //this is the initialization of current score to 0 because it would start at that first 
    public int current = 0;
    //this is a TextMeshProUGUI type with Text as name for that type 
    private TextMeshProUGUI Text;
    void Start()
    {
        //this is reference for the TextMeshProUGUI compoenent that would be given for the Text at the start  
        Text = GetComponent<TextMeshProUGUI>();
    }
   
    public void setText()
    {
        //this would print current score value with the text of current score 
        Debug.Log("Current Score: " + current);
        //this would convert the current score value to a string with the current score text 
        Text.text = "Current Score: " + current.ToString();
    }
}

