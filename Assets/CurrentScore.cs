using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public int current = 0;
    private TextMeshProUGUI Text;
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
    public void setText()
    {
        Debug.Log("Current Score: " + current);
        Text.text = "Current Score: " + current.ToString();
    }
}

