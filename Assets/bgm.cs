﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class bgm : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
 public GameObject Tog; 
 string strs;
    void Start()
    {
        QuickSaveReader.Create("UserData")
                       .Read<string>(cryptography.Encrypt("Bmg"), (r) => {  strs = cryptography.Decrypt<string>(r); });
       Tog.GetComponent<Toggle>().isOn = bool.Parse(strs); 
    }
	public GameObject Disable; 
	
	 public void Enable1(bool val1)
		{
					Disable.SetActive(val1);
			if (val1==true){	
			string encrypted29 = cryptography.Encrypt("true");	
			QuickSaveWriter.Create("UserData")
						   .Write(cryptography.Encrypt("Bmg"), encrypted29)
						   .Commit();
						   }
			if (val1==false){	
			string encrypted29 = cryptography.Encrypt("false");	
			QuickSaveWriter.Create("UserData")
						   .Write(cryptography.Encrypt("Bmg"), encrypted29)
						   .Commit();
						   }
		}
}
