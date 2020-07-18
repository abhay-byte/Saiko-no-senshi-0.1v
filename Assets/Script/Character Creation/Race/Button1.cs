using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Button1 : MonoBehaviour
{
	public bool val;
	public GameObject toggle1;
	public GameObject toggle2;
	public GameObject toggle3;	
	public GameObject Player;
	public Text selectedName;
	public string R = "";
	Cryptography cryptography = new Cryptography("Rey@2626");	

	public void Enable1(bool val1)
	{
		if (val1 == true){
		toggle1.GetComponent<Toggle>().isOn = true;
		toggle2.GetComponent<Toggle>().isOn = false;
		toggle3.GetComponent<Toggle>().isOn = false;

			R = "Human";
			selectedName.text = "Human : 1x to all stats.";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
		Player_Data Data = Player.GetComponent<Player_Data>();
		Data.race(R);
		
	}

	}
	public void Enable2(bool val2)
	{
		if (val2 == true){
		toggle1.GetComponent<Toggle>().isOn = false;
		toggle2.GetComponent<Toggle>().isOn = true;
		toggle3.GetComponent<Toggle>().isOn = false;
			R = "Elf";
			selectedName.text = "Elf : -25% Base Strength \n -25% Base Endurance(HP) \n -25% Base Vitality(Defense) \n +75% Base Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
		Player_Data Data = Player.GetComponent<Player_Data>();
		Data.race(R);
		}

	}
	public void Enable3(bool val3)
	{
		if (val3 == true){
		toggle1.GetComponent<Toggle>().isOn = false;
		toggle2.GetComponent<Toggle>().isOn = false;
		toggle3.GetComponent<Toggle>().isOn = true;
			R = "Orc";
			selectedName.text = "Orc : +50% Base Strength \n +50% Base Endurance(HP) \n -50% Base Intelligence(Magic Attack) \n -50% Base Constitution(M Defense) ";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
		Player_Data Data = Player.GetComponent<Player_Data>();
		Data.race(R);
		}

	}

}
