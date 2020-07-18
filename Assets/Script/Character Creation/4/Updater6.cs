using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updater6 : MonoBehaviour
{
	public int i = 5;
	public Text selectedName;
	public Text info;
	public void Red()
	{
		info.text = "Strength : Increases Physical Attack";
		if (i>1){
		i = i-1;
		Changer rb = GetComponent<Changer>();
		int a = rb.points;
		rb.Changepoint(+1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
	selectedName.text = s;}
	}
	public void OnMouseClick()
	{ 
		info.text = "Strength : Increases Physical Attack";
		Changer rb = GetComponent<Changer>();
		int a = rb.points;
		if (a>0)
		{i = i+1;
		rb.Changepoint(-1);
		Debug.Log(a);
		string s;
		s = (i).ToString();
		selectedName.text = s;}
	}
}

