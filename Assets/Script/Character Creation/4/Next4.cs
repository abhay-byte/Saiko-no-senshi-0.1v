using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Next4 : MonoBehaviour
{
	public GameObject Player;
	public int Points = 18;
	public int strength = 10;
	public int endurance = 10;
	public int dexternity = 10;
	public int constitution = 10;
	public int vitality = 10;
	public int intelligence = 10;
	Cryptography cryptography = new Cryptography("Rey@2626");
	
	public GameObject Enable;
	public GameObject Disable;


	void Start()
	{
	
	}
	
	public void Point(int p)
	{
		Points = p;
	}
	
	public void Strength(int p1)
	{
		strength = p1;
	}

	public void Endurance(int p2)
	{
		endurance = p2;
	}
	
	public void Dexternity(int p3)
	{
		dexternity = p3;
	}
	
	public void Constitution(int p4)
	{
		constitution = p4;
	}
	
	public void Vitality(int p5)
	{
		vitality = p5;
	}
	
	public void Intelligence(int p6)
	{
		intelligence = p6;
	}
	


	public void OnMouseClick()
	{ 
		if (Points==0)
		{
			Player_Data Data = Player.GetComponent<Player_Data>();
			
			Data.strength(Convert.ToDouble(strength));
			Data.endurance(Convert.ToDouble(endurance));
			Data.dexternity(Convert.ToDouble(dexternity));
			Data.constitution(Convert.ToDouble(constitution));
			Data.vitality(Convert.ToDouble(vitality));
			Data.intelligence(Convert.ToDouble(intelligence));

			
			string encrypted1 = cryptography.Encrypt(strength);
			string encrypted2 = cryptography.Encrypt(endurance);
			string encrypted3 = cryptography.Encrypt(dexternity);
			string encrypted4 = cryptography.Encrypt(constitution);
			string encrypted5 = cryptography.Encrypt(vitality);
			string encrypted6 = cryptography.Encrypt(intelligence);
			
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Strength"), encrypted1)
						   .Write(cryptography.Encrypt("Endurance"), encrypted2)
						   .Write(cryptography.Encrypt("Dexternity"), encrypted3)
						   .Write(cryptography.Encrypt("Constitution"), encrypted4)
						   .Write(cryptography.Encrypt("Vitality"), encrypted5)
						   .Write(cryptography.Encrypt("Intelligence"), encrypted6)
						   .Commit();
						   
		Enable.SetActive(true);
		Disable.SetActive(false);
			

		}
	}

}