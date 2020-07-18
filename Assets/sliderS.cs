using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;


public class sliderS : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
	public Slider slider;
	int val;
	public Text Vl;
	public GameObject Player;
 int Fps1;
	void Start()
	{
		        QuickSaveReader.Create("UserData")
					   .Read<string>(cryptography.Encrypt("fps"), (r) => { Fps1 = cryptography.Decrypt<int>(r); });	
	slider.value = Fps1;
	}
	public void change(){
		val = Convert.ToInt32(slider.value);
			string encrypted30 = cryptography.Encrypt(val);
			QuickSaveWriter.Create("UserData")			
						   .Write(cryptography.Encrypt("fps"), encrypted30)
						   .Commit();
		Vl.text = val+"";
        HeroT Data = Player.GetComponent<HeroT>();
		Data.Fps(val);
				
	}
}
