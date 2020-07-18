using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Gender1 : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
	public string G = "";
	public string Race;
	public string Class;
	public GameObject Player;


	public GameObject Male_Human;
	public GameObject Male_Elf;
	public GameObject Male_Orc;
	
	public GameObject Male_Human_Warrior;
	public GameObject Male_Human_Berseker;
	public GameObject Male_Human_Paladin;
	public GameObject Male_Human_Mage;
	public GameObject Male_Human_Knight;
	public GameObject Male_Human_Duelist;
	
	public GameObject Male_Elf_Warrior;
	public GameObject Male_Elf_Berseker;
	public GameObject Male_Elf_Mage;
	
	public GameObject Male_Orc_Warrior;
	public GameObject Male_Orc_Berseker;
	
	public GameObject Female_Human;
	public GameObject Female_Elf;
	public GameObject Female_Orc;
	
	public GameObject Female_Human_Warrior;
	public GameObject Female_Human_Berseker;
	public GameObject Female_Human_Paladin;
	public GameObject Female_Human_Mage;
	public GameObject Female_Human_Knight;
	public GameObject Female_Human_Duelist;
	
	public GameObject Female_Elf_Warrior;
	public GameObject Female_Elf_Berseker;
	public GameObject Female_Elf_Mage;
	
	public GameObject Female_Orc_Warrior;
	public GameObject Female_Orc_Berseker;
	

    void Update()
    {
		Player_Data Data = Player.GetComponent<Player_Data>();
		Race = Data.Race;
		Class = Data.Class;
		
		
		if (Race == "Human"){
		Male_Human.SetActive(true);
		Male_Elf.SetActive(false);	
		Male_Orc.SetActive(false);
		Female_Human.SetActive(true);
		Female_Elf.SetActive(false);	
		Female_Orc.SetActive(false);			
		}
		
		if (Race == "Elf"){
		Male_Human.SetActive(false);
		Male_Elf.SetActive(true);	
		Male_Orc.SetActive(false);
		Female_Human.SetActive(false);
		Female_Elf.SetActive(true);	
		Female_Orc.SetActive(false);				
		}	

		if (Race == "Orc"){
		Male_Human.SetActive(false);
		Male_Elf.SetActive(false);	
		Male_Orc.SetActive(true);
		Female_Human.SetActive(false);
		Female_Elf.SetActive(false);	
		Female_Orc.SetActive(true);				
		}	
		
		if (Class == "Warrior" && Race == "Human"){
			Male_Human_Warrior.SetActive(true);
			Female_Human_Warrior.SetActive(true);
			
			Male_Human_Berseker.SetActive(false);
			Male_Human_Paladin.SetActive(false);
			Male_Human_Mage.SetActive(false);
			Male_Human_Knight.SetActive(false);
			Male_Human_Duelist.SetActive(false);
			
			Female_Human_Duelist.SetActive(false);
			Female_Human_Berseker.SetActive(false);
			Female_Human_Paladin.SetActive(false);
			Female_Human_Mage.SetActive(false);
			Female_Human_Knight.SetActive(false);			
		}
		
		if (Class == "Berseker" && Race == "Human"){
			Male_Human_Berseker.SetActive(true);
			Female_Human_Berseker.SetActive(true);
			
			Male_Human_Warrior.SetActive(false);
			Male_Human_Paladin.SetActive(false);
			Male_Human_Mage.SetActive(false);
			Male_Human_Knight.SetActive(false);
			Male_Human_Duelist.SetActive(false);
			
			Female_Human_Duelist.SetActive(false);
			Female_Human_Warrior.SetActive(false);
			Female_Human_Paladin.SetActive(false);
			Female_Human_Mage.SetActive(false);
			Female_Human_Knight.SetActive(false);		
		}
		
		if (Class == "Paladin" && Race == "Human"){
			
			Male_Human_Paladin.SetActive(true);
			Female_Human_Paladin.SetActive(true);
			
			Male_Human_Warrior.SetActive(false);
			Male_Human_Berseker.SetActive(false);
			Male_Human_Mage.SetActive(false);
			Male_Human_Knight.SetActive(false);
			Male_Human_Duelist.SetActive(false);
			
			Female_Human_Duelist.SetActive(false);
			Female_Human_Warrior.SetActive(false);
			Female_Human_Berseker.SetActive(false);
			Female_Human_Mage.SetActive(false);
			Female_Human_Knight.SetActive(false);		
		}
		
		if (Class == "Mage" && Race == "Human"){
			Male_Human_Mage.SetActive(true);
			Female_Human_Mage.SetActive(true);
			
			Male_Human_Warrior.SetActive(false);
			Male_Human_Berseker.SetActive(false);
			Male_Human_Paladin.SetActive(false);
			Male_Human_Knight.SetActive(false);
			Male_Human_Duelist.SetActive(false);
			
			Female_Human_Duelist.SetActive(false);
			Female_Human_Warrior.SetActive(false);
			Female_Human_Berseker.SetActive(false);
			Female_Human_Paladin.SetActive(false);
			Female_Human_Knight.SetActive(false);
		}
		
		if (Class == "Knight" && Race == "Human"){
			
			Male_Human_Knight.SetActive(true);
			Female_Human_Knight.SetActive(true);
			
			Male_Human_Warrior.SetActive(false);
			Male_Human_Berseker.SetActive(false);
			Male_Human_Paladin.SetActive(false);
			Male_Human_Mage.SetActive(false);
			Male_Human_Duelist.SetActive(false);
			
			Female_Human_Duelist.SetActive(false);
			Female_Human_Warrior.SetActive(false);
			Female_Human_Berseker.SetActive(false);
			Female_Human_Paladin.SetActive(false);
			Female_Human_Mage.SetActive(false);		
		}
		
		if (Class == "Duelist" && Race == "Human"){
			Male_Human_Duelist.SetActive(true);
			Female_Human_Duelist.SetActive(true);
			
			Male_Human_Knight.SetActive(false);
			Male_Human_Berseker.SetActive(false);
			Male_Human_Paladin.SetActive(false);
			Male_Human_Mage.SetActive(false);
			Male_Human_Warrior.SetActive(false);
			
			Female_Human_Knight.SetActive(false);
			Female_Human_Warrior.SetActive(false);
			Female_Human_Berseker.SetActive(false);
			Female_Human_Paladin.SetActive(false);
			Female_Human_Mage.SetActive(false);	
		}
		
		if (Class == "Warrior" && Race == "Elf"){
			Male_Elf_Warrior.SetActive(true);
			Female_Elf_Warrior.SetActive(true);
			
			Male_Elf_Berseker.SetActive(false);
			Male_Elf_Mage.SetActive(false);
			
			Female_Elf_Berseker.SetActive(false);
			Female_Elf_Mage.SetActive(false);
		}
		
		if (Class == "Berseker" && Race == "Elf"){
			Male_Elf_Berseker.SetActive(true);
			Female_Elf_Berseker.SetActive(true);
			
			Male_Elf_Warrior.SetActive(false);
			Male_Elf_Mage.SetActive(false);
			
			Female_Elf_Warrior.SetActive(false);
			Female_Elf_Mage.SetActive(false);
		}
		
		if (Class == "Mage" && Race == "Elf"){
			Male_Elf_Mage.SetActive(true);
			Female_Elf_Mage.SetActive(true);
			
			Male_Elf_Warrior.SetActive(false);
			Male_Elf_Berseker.SetActive(false);
			
			Female_Elf_Warrior.SetActive(false);
			Female_Elf_Berseker.SetActive(false);
		}
		
		if (Class == "Warrior" && Race == "Orc"){
			Male_Orc_Warrior.SetActive(true);
			Female_Orc_Warrior.SetActive(true);
			
			Male_Orc_Berseker.SetActive(false);
			
			Female_Orc_Berseker.SetActive(false);
		}
		
		if (Class == "Berseker" && Race == "Orc"){
			Male_Orc_Berseker.SetActive(true);
			Female_Orc_Berseker.SetActive(true);
			
			Male_Orc_Warrior.SetActive(false);
			
			Female_Orc_Warrior.SetActive(false);
		}
	}
	
	public void male_Human_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Human_Warrior.GetComponent<Toggle>().isOn = true;
			Female_Human_Warrior.GetComponent<Toggle>().isOn = false;


			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}
	
	public void male_Human_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Human_Berseker.GetComponent<Toggle>().isOn = true;
			Female_Human_Berseker.GetComponent<Toggle>().isOn = false;
			

			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void male_Human_Paladin(bool val)
	{
		if (val == true)
		{
			Male_Human_Paladin.GetComponent<Toggle>().isOn = true;
			Female_Human_Paladin.GetComponent<Toggle>().isOn = false;

			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void male_Human_Mage(bool val)
	{
		if (val == true)
		{
			Male_Human_Mage.GetComponent<Toggle>().isOn = true;
			Female_Human_Mage.GetComponent<Toggle>().isOn = false;
			
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}			
	
	public void male_Human_Knight(bool val)
	{
		if (val == true)
		{
			Male_Human_Knight.GetComponent<Toggle>().isOn = true;
			Female_Human_Knight.GetComponent<Toggle>().isOn = false;

			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void male_Human_Duelist(bool val)
	{
		if (val == true)
		{
			Male_Human_Duelist.GetComponent<Toggle>().isOn = true;
			Female_Human_Duelist.GetComponent<Toggle>().isOn = false;
			
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	public void female_Human_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Human_Warrior.GetComponent<Toggle>().isOn = false;
			Female_Human_Warrior.GetComponent<Toggle>().isOn = true;
			
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}
	
	public void female_Human_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Human_Berseker.GetComponent<Toggle>().isOn = false;
			Female_Human_Berseker.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();			
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void female_Human_Paladin(bool val)
	{
		if (val == true)
		{
			Male_Human_Paladin.GetComponent<Toggle>().isOn = false;
			Female_Human_Paladin.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
		
	
	public void female_Human_Mage(bool val)
	{
		if (val == true)
		{
			Male_Human_Mage.GetComponent<Toggle>().isOn = false;
			Female_Human_Mage.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}			
	
	public void female_Human_Knight(bool val)
	{
		if (val == true)
		{
			Male_Human_Knight.GetComponent<Toggle>().isOn = false;
			Female_Human_Knight.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void female_Human_Duelist(bool val)
	{
		if (val == true)
		{
			Male_Human_Duelist.GetComponent<Toggle>().isOn = false;
			Female_Human_Duelist.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void male_Elf_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Elf_Warrior.GetComponent<Toggle>().isOn = true;
			Female_Elf_Warrior.GetComponent<Toggle>().isOn = false;
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void male_Elf_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Elf_Berseker.GetComponent<Toggle>().isOn = true;
			Female_Elf_Berseker.GetComponent<Toggle>().isOn = false;
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}			
	
	public void male_Elf_Mage(bool val)
	{
		if (val == true)
		{
			Male_Elf_Mage.GetComponent<Toggle>().isOn = true;
			Female_Elf_Mage.GetComponent<Toggle>().isOn = false;
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	

	public void female_Elf_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Elf_Warrior.GetComponent<Toggle>().isOn = false;
			Female_Elf_Warrior.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void female_Elf_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Elf_Berseker.GetComponent<Toggle>().isOn = false;
			Female_Elf_Berseker.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}			
	
	public void female_Elf_Mage(bool val)
	{
		if (val == true)
		{
			Male_Elf_Mage.GetComponent<Toggle>().isOn = false;
			Female_Elf_Mage.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
	
	public void male_Orc_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Orc_Warrior.GetComponent<Toggle>().isOn = true;
			Female_Orc_Warrior.GetComponent<Toggle>().isOn = false;
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void male_Orc_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Orc_Berseker.GetComponent<Toggle>().isOn = true;
			Female_Orc_Berseker.GetComponent<Toggle>().isOn = false;
			
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void female_Orc_Warrior(bool val)
	{
		if (val == true)
		{
			Male_Orc_Warrior.GetComponent<Toggle>().isOn = false;
			Female_Orc_Warrior.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}	
	
	public void female_Orc_Berseker(bool val)
	{
		if (val == true)
		{
			Male_Orc_Berseker.GetComponent<Toggle>().isOn = false;
			Female_Orc_Berseker.GetComponent<Toggle>().isOn = true;
			
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();		
						   
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.gender(G);
		}	
	}		
}