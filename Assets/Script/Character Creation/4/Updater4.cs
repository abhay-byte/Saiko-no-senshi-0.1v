using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Updater4 : MonoBehaviour
{
	public string Vitality = "Vitality";
	public int i = 10;
	public Text selectedName;
	public Text info;
	public void Red()
	{
		info.text = "Vitality : Increases Physical Defence/Resistance";
		if (i>8){
		i = i-1;
		Changer rb = GetComponent<Changer>();
		int a = rb.points;
		rb.Changepoint(+1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
		selectedName.text = s;
		Next4 SD = GetComponent<Next4>();
		SD.Vitality(i);}
	}
	public void OnMouseClick()
	{ 
		info.text = "Vitality : Increases Physical Defence/Resistance";
		Changer rb = GetComponent<Changer>();
		int a = rb.points;
		if (a>0)
		{i = i+1;
		rb.Changepoint(-1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
		selectedName.text = s;
		Next4 SD = GetComponent<Next4>();
		SD.Vitality(i);}
	}
}
