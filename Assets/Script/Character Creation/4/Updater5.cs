using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Updater5 : MonoBehaviour
{
	public string Intelligence = "Intelligence";
	public int i = 10;
	public Text selectedName;
	public Text info;
	public void Red()
	{
		info.text = "Intelligence : Increases Magic Attack and Mana";
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
		SD.Intelligence(i);}
	}
	public void OnMouseClick()
	{ 
		info.text = "Intelligence : Increases Magic Attack and Mana";
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
		SD.Intelligence(i);}
	}
}

