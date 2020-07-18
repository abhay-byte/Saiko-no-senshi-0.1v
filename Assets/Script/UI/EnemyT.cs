using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemyT : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public GameObject dialogBox1;
    float timerDisplay;
	
	public double Hp = 500;
    
    void Start()
    {
        dialogBox.SetActive(false);
		dialogBox1.SetActive(true);
        timerDisplay = -1.0f;
    }
    
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
				Hp = Hp - 100;
                dialogBox.SetActive(false);

            }
        }
    }
    
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
		dialogBox1.SetActive(false);
    }
}





	


