using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Stat6 : MonoBehaviour
{
	public string Intelligence = "Intelligence";
	public double i ;
	public double i1 ;
	public Text selectedName;
	public Text info;

	void Start()
	{
		NonUP Data = GetComponent<NonUP>();
		i = Data.Intelligence;
		i1 =  Data.Intelligence;
	}
    void Update()
    {
      
    }
	public void Red()
	{
		info.text = "Intelligence : Increases Magic Attack and Mana";
		if (i>i1){
		i = i-1;
		StatPoint rb = GetComponent<StatPoint>();
		double a = rb.points;
		rb.Changepoint(+1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
		selectedName.text = s;
		NonUP SD = GetComponent<NonUP>();
		SD.Intelligence1(i);}
	}
	public void OnMouseClick()
	{ 
		info.text = "Intelligence : Increases Magic Attack and Mana";
		StatPoint rb = GetComponent<StatPoint>();
		double a = rb.points;
		if (a>0)
		{i = i+1;
		rb.Changepoint(-1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
		selectedName.text = s;
		NonUP SD = GetComponent<NonUP>();
		SD.Intelligence1(i);}
	}
}

