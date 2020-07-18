using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class character : MonoBehaviour
{
	public GameObject Enable;
	public GameObject Disable1;
	public GameObject Disable2;
	public GameObject Disable3;
	public GameObject Disable4;
	public GameObject Disable5;

	public int i;
	void Update(){
		NonUP Data = UIElements11.GetComponent<NonUP>();
		i = Data.ULevel;
		Lvl.text = "LevelUp("+i+")";
	}
	public Text Lvl;
	public GameObject UIElements11;

	
	public void OnMouseClick(){
		Enable.SetActive(true);
		Disable1.SetActive(false);
		Disable2.SetActive(false);
		Disable3.SetActive(false);
		Disable4.SetActive(false);
		Disable5.SetActive(false);
	}
}