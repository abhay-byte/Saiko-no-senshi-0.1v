using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Updater2 : MonoBehaviour
{
	public string Dexternity = "Dexternity";
	public int i = 10;
	public Text selectedName;
	public Text info;
	public void Red()
	{
		info.text = "Dexternity : Increases Agility";
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
		SD.Dexternity(i);}
	}
	public void OnMouseClick()
	{ 
		info.text = "Strength : Increases Agility";
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
		SD.Dexternity(i);}
	}
}
