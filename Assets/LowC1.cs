using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class LowC1 : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
 public GameObject Tog; 
 string strs;
    void Start()
    {
        QuickSaveReader.Create("UserData")
                       .Read<string>(cryptography.Encrypt("LowC"), (r) => {  strs = cryptography.Decrypt<string>(r); });
       Tog.GetComponent<Toggle>().isOn = bool.Parse(strs); 
    }
	public GameObject AnimW; 
	public GameObject NAnimW;	
	 public void Enable1(bool val1)
		{

			if (val1==true){	
					NAnimW.SetActive(true);
					AnimW.SetActive(false);
			string encrypted29 = cryptography.Encrypt("true");	
			QuickSaveWriter.Create("UserData")
						   .Write(cryptography.Encrypt("LowC"), encrypted29)
						   .Commit();
						   }
			if (val1==false){	
					NAnimW.SetActive(false);
					AnimW.SetActive(true);
			string encrypted29 = cryptography.Encrypt("false");	
			QuickSaveWriter.Create("UserData")
						   .Write(cryptography.Encrypt("LowC"), encrypted29)
						   .Commit();
			
}
}}