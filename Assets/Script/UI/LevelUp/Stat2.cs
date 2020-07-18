using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Stat2 : MonoBehaviour
{
	public string Endurance = "Endurance";
	public double i ;
	public double i1 ;
	public Text selectedName;
	public Text info;
	
	void Start(){
		NonUP Data = GetComponent<NonUP>();
		i = Data.Endurance;
		i1 =  Data.Endurance;
	}
    void Update()
    {
      
    }
	public void Red()
	{

		info.text = "Endurance : Increases HP And Stamina";
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
		SD.Endurance1(i);}
	}
	public void OnMouseClick()
	{ 
		info.text = "Strength : Increases HP And Stamina";
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
		SD.Endurance1(i);}
	}
}
