using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class ClASS1 : MonoBehaviour
{

	public string Race;
	public GameObject Player;
	public string C = "";
	
	public GameObject Human;
	public GameObject Elf;
	public GameObject Orc;
	public Text selectedName;
	Cryptography cryptography = new Cryptography("Rey@2626");
	
	public GameObject Human_toggle1;
	public GameObject Human_toggle2;
	public GameObject Human_toggle3;	
	public GameObject Human_toggle4;
	public GameObject Human_toggle5;
	public GameObject Human_toggle6;
	public GameObject Human_toggle7;

	public GameObject Elf_toggle1;
	public GameObject Elf_toggle2;
	public GameObject Elf_toggle3;
	
	public GameObject Orc_toggle1;
	public GameObject Orc_toggle2;
	
	 void Update()
	 {
		Player_Data Data = Player.GetComponent<Player_Data>();
		Race = Data.Race;
		
		if (Race == "Human"){
		Human.SetActive(true);
		Elf.SetActive(false);	
		Orc.SetActive(false);			
		}
		
		if (Race == "Elf"){
		Human.SetActive(false);
		Elf.SetActive(true);	
		Orc.SetActive(false);			
		}	

		if (Race == "Orc"){
		Human.SetActive(false);
		Elf.SetActive(false);	
		Orc.SetActive(true);			
		}		

	 }
	 
	public void Human_Warrior(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = true;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
				C = "Warrior";
				selectedName.text = "Warrior : Strength +10 \n Dexternity(Speed) +10 \n Endurance(HP) +10 \n Vitality(Defense) +10";
				string encrypted = cryptography.Encrypt(C);
				QuickSaveWriter.Create("Temp")
							   .Write(cryptography.Encrypt("Class"), encrypted)
							   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	
	public void Human_Berseker(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = true;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
			C = "Berseker";
			selectedName.text = "Berseker : Strength +20 \n Dexternity(Speed) +20 \n -10% Constitution(M Defense) \n +30% Endurance(HP) \n -20% Intelligence";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}

	public void Human_Paladin(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = true;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
			C = "Paladin";
			selectedName.text = "Paladin: Strength +10 \n Dexternity(Speed) +5 \n Endurance(HP) +10 \n Intelligence(Magic Attack) +5 \n Constitution(M Defense) +10";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}	
	
	public void Human_Mage(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = true;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
			C = "Mage";
			selectedName.text = "Mage : -50% Strength \n -50%  Dexternity(Speed) \n -50% Endurance(HP) \n Intelligence(Magic Attack) +30 \n Constitution(M Defense) +10 \n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	
	public void Human_Knight(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = true;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
			C = "Knight";
			selectedName.text = "Knight : Strength +15 \n Endurance(HP) +15 \n Vitality(Defense) +10";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}

	public void Human_Barbarian(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = true;
			Human_toggle7.GetComponent<Toggle>().isOn = false;
			
			C = "Barbarian";
			selectedName.text = "Barbarian : Strength +10 \n Endurance(HP) +20 \n Dexternity(Speed) +10 \n -20% Constitution(M Defense) \n +10% Strength \n +10% Endurance(HP)";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
		public void Human_Duelist(bool val)
	{	
		if (val == true)
		{
			Human_toggle1.GetComponent<Toggle>().isOn = false;
			Human_toggle2.GetComponent<Toggle>().isOn = false;
			Human_toggle3.GetComponent<Toggle>().isOn = false;
			Human_toggle4.GetComponent<Toggle>().isOn = false;
			Human_toggle5.GetComponent<Toggle>().isOn = false;
			Human_toggle6.GetComponent<Toggle>().isOn = false;
			Human_toggle7.GetComponent<Toggle>().isOn = true;
			
			C = "Duelist";
			selectedName.text = "Duelist : Strength +15 \n Endurance(HP) +5 \n Dexternity(Speed) +15 \n Vitality(Defense) +5";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Char")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	public void Elf_Warrior(bool val)
	{	
		if (val == true)
		{
			Elf_toggle1.GetComponent<Toggle>().isOn = true;
			Elf_toggle2.GetComponent<Toggle>().isOn = false;
			Elf_toggle3.GetComponent<Toggle>().isOn = false;

			
				C = "Warrior";
				selectedName.text = "Warrior : Strength +10 \n Dexternity(Speed) +10 \n Endurance(HP) +10 \n Vitality(Defense) +10";
				string encrypted = cryptography.Encrypt(C);
				QuickSaveWriter.Create("Temp")
							   .Write(cryptography.Encrypt("Class"), encrypted)
							   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	
	public void Elf_Berseker(bool val)
	{	
		if (val == true)
		{
			Elf_toggle1.GetComponent<Toggle>().isOn = false;
			Elf_toggle2.GetComponent<Toggle>().isOn = true;
			Elf_toggle3.GetComponent<Toggle>().isOn = false;

			
			C = "Berseker";
			selectedName.text = "Berseker : Strength +20 \n Dexternity(Speed) +20 \n -10% Constitution(M Defense) \n +30% Endurance(HP) \n -20% Intelligence";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	
	public void Elf_Mage(bool val)
	{	
		if (val == true)
		{
			Elf_toggle1.GetComponent<Toggle>().isOn = false;
			Elf_toggle2.GetComponent<Toggle>().isOn = false;
			Elf_toggle3.GetComponent<Toggle>().isOn = true;

			
			C = "Mage";
			selectedName.text = "Mage : -50% Strength \n -50%  Dexternity(Speed) \n -50% Endurance(HP) \n Intelligence(Magic Attack) +30 \n Constitution(M Defense) +10 \n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}

	public void Orc_Warrior(bool val)
	{	
		if (val == true)
		{
			Orc_toggle1.GetComponent<Toggle>().isOn = true;
			Orc_toggle2.GetComponent<Toggle>().isOn = false;

			
				C = "Warrior";
				selectedName.text = "Warrior : Strength +10 \n Dexternity(Speed) +10 \n Endurance(HP) +10 \n Vitality(Defense) +10";
				string encrypted = cryptography.Encrypt(C);
				QuickSaveWriter.Create("Temp")
							   .Write(cryptography.Encrypt("Class"), encrypted)
							   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
	
	public void Orc_Berseker(bool val)
	{	
		if (val == true)
		{
			Orc_toggle1.GetComponent<Toggle>().isOn = false;
			Orc_toggle2.GetComponent<Toggle>().isOn = true;

			
			C = "Berseker";
			selectedName.text = "Berseker : Strength +20 \n Dexternity(Speed) +20 \n -10% Constitution(M Defense) \n +30% Endurance(HP) \n -20% Intelligence";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.class1(C);
		}
	}
}