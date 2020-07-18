using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class enter1 : MonoBehaviour
{	Cryptography cryptography = new Cryptography("Rey@2626");

	string strs;
	public GameObject Disable; 	
    void Start()
    {
        QuickSaveReader.Create("UserData")
                       .Read<string>(cryptography.Encrypt("Name"), (r) => {  strs = cryptography.Decrypt<string>(r); });
	if (strs != null){
							Disable.SetActive(false);
	}
 
}
}