using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Weapon1 : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");

	public string Race;
	public string Class;
	public GameObject Player;
	public string W = "";
	public Text selectedName;
	
	public GameObject Warrior;
	public GameObject Berseker;
	public GameObject Paladin;
	public GameObject Mage;
	public GameObject Knight;
	public GameObject Duelist;
	
	public GameObject Warrior_Sword;
	public GameObject Warrior_Dagger;
	public GameObject Warrior_Mace;
	public GameObject Warrior_Katana;
	public GameObject Warrior_Wand;
	public GameObject Warrior_Spear;
	
	public GameObject Berseker_Spear;
	public GameObject Berseker_Sword;
	public GameObject Berseker_Katana;
	
	public GameObject Paladin_Sword;
	public GameObject Paladin_Spear;
	public GameObject Paladin_Mace;
	public GameObject Paladin_Wand;
	
	public GameObject Mage_Wand;
	public GameObject Mage_Dagger;
	
	public GameObject Knight_Sword;
	public GameObject Knight_Katana;
	
	public GameObject Duelist_Sword;
	public GameObject Duelist_Spear;
	public GameObject Duelist_Dagger;
	public GameObject Duelist_Mace;
	public GameObject Duelist_Katana;


	

    void Update()
    {
		Player_Data Data = Player.GetComponent<Player_Data>();
		Race = Data.Race;
		Class = Data.Class;
		
		if (Class == "Warrior" && Race != "Orc"){
		Warrior.SetActive(true);
		Berseker.SetActive(false);	
		Paladin.SetActive(false);
		Mage.SetActive(false);	
		Knight.SetActive(false);	
		Duelist.SetActive(false);
		
		}
		
		if (Class == "Berseker"){
		Warrior.SetActive(false);
		Berseker.SetActive(true);	
		Paladin.SetActive(false);
		Mage.SetActive(false);	
		Knight.SetActive(false);	
		Duelist.SetActive(false);
		}	

		if (Class == "Paladin"){
		Warrior.SetActive(false);
		Berseker.SetActive(false);	
		Paladin.SetActive(true);
		Mage.SetActive(false);	
		Knight.SetActive(false);	
		Duelist.SetActive(false);
		}	   

		if (Class == "Mage"){
		Warrior.SetActive(false);
		Berseker.SetActive(false);	
		Paladin.SetActive(false);
		Mage.SetActive(true);	
		Knight.SetActive(false);	
		Duelist.SetActive(false);
		}

		if (Class == "Knight"){
		Warrior.SetActive(false);
		Berseker.SetActive(false);	
		Paladin.SetActive(false);
		Mage.SetActive(false);	
		Knight.SetActive(true);	
		Duelist.SetActive(false);
		}

		if (Class == "Duelist"){
		Warrior.SetActive(false);
		Berseker.SetActive(false);	
		Paladin.SetActive(false);
		Mage.SetActive(false);	
		Knight.SetActive(false);	
		Duelist.SetActive(true);
		}
		
		if (Class == "Warrior" && Race == "Orc"){
		Warrior.SetActive(false);
		Berseker.SetActive(false);	
		Paladin.SetActive(false);
		Mage.SetActive(false);	
		Knight.SetActive(false);	
		Duelist.SetActive(true);
		}		
    }
	
	 
	public void warrior_Sword(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = true;
			Warrior_Dagger.GetComponent<Toggle>().isOn = false;
			Warrior_Mace.GetComponent<Toggle>().isOn = false;
			Warrior_Katana.GetComponent<Toggle>().isOn = false;
			Warrior_Wand.GetComponent<Toggle>().isOn = false;
			Warrior_Spear.GetComponent<Toggle>().isOn = false;
			
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void warrior_Dagger(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = false;
			Warrior_Dagger.GetComponent<Toggle>().isOn = true;
			Warrior_Mace.GetComponent<Toggle>().isOn = false;
			Warrior_Katana.GetComponent<Toggle>().isOn = false;
			Warrior_Wand.GetComponent<Toggle>().isOn = false;
			Warrior_Spear.GetComponent<Toggle>().isOn = false;
			
			W = "Dagger";
			selectedName.text = "Dagger : \n + 50% Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void warrior_Mace(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = false;
			Warrior_Dagger.GetComponent<Toggle>().isOn = false;
			Warrior_Mace.GetComponent<Toggle>().isOn = true;
			Warrior_Katana.GetComponent<Toggle>().isOn = false;
			Warrior_Wand.GetComponent<Toggle>().isOn = false;
			Warrior_Spear.GetComponent<Toggle>().isOn = false;
			
			W = "Mace";
			selectedName.text = "Mace : +50% Strength \n +100% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void warrior_Katana(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = false;
			Warrior_Dagger.GetComponent<Toggle>().isOn = false;
			Warrior_Mace.GetComponent<Toggle>().isOn = false;
			Warrior_Katana.GetComponent<Toggle>().isOn = true;
			Warrior_Wand.GetComponent<Toggle>().isOn = false;
			Warrior_Spear.GetComponent<Toggle>().isOn = false;
			
			W = "Katana";
			selectedName.text = "Katana : +100% Strength \n + 50% Dexternity(Speed) \n -50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void warrior_Wand(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = false;
			Warrior_Dagger.GetComponent<Toggle>().isOn = false;
			Warrior_Mace.GetComponent<Toggle>().isOn = false;
			Warrior_Katana.GetComponent<Toggle>().isOn = false;
			Warrior_Wand.GetComponent<Toggle>().isOn = true;
			Warrior_Spear.GetComponent<Toggle>().isOn = false;
			
			W = "Wand";
			selectedName.text = "Wand :\n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void warrior_Spear(bool val)
	{	
		if (val == true)
		{
			Warrior_Sword.GetComponent<Toggle>().isOn = false;
			Warrior_Dagger.GetComponent<Toggle>().isOn = false;
			Warrior_Mace.GetComponent<Toggle>().isOn = false;
			Warrior_Katana.GetComponent<Toggle>().isOn = false;
			Warrior_Wand.GetComponent<Toggle>().isOn = false;
			Warrior_Spear.GetComponent<Toggle>().isOn = true;
			
			W = "Spear";
			selectedName.text = "Spear :\n +10% Dexternity(Speed) \n +50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	
	 
	public void berseker_Sword(bool val)
	{	
		if (val == true)
		{
			Berseker_Sword.GetComponent<Toggle>().isOn = true;
			Berseker_Spear.GetComponent<Toggle>().isOn = false;
			Berseker_Katana.GetComponent<Toggle>().isOn = false;

			
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	
	public void berseker_Spear(bool val)
	{	
		if (val == true)
		{
			Berseker_Sword.GetComponent<Toggle>().isOn = false;
			Berseker_Spear.GetComponent<Toggle>().isOn = true;
			Berseker_Katana.GetComponent<Toggle>().isOn = false;
			
			W = "Spear";
			selectedName.text = "Spear :\n +10% Dexternity(Speed) \n +50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}	
	public void berseker_Katana(bool val)
	{	
		if (val == true)
		{
			Berseker_Sword.GetComponent<Toggle>().isOn = false;
			Berseker_Spear.GetComponent<Toggle>().isOn = false;
			Berseker_Katana.GetComponent<Toggle>().isOn = true;
			
			W = "Katana";
			selectedName.text = "Katana : +100% Strength \n + 50% Dexternity(Speed) \n -50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}	
	
	public void paladin_Sword(bool val)
	{	
		if (val == true)
		{
			Paladin_Sword.GetComponent<Toggle>().isOn = true;
			Paladin_Spear.GetComponent<Toggle>().isOn = false;
			Paladin_Mace.GetComponent<Toggle>().isOn = false;
			Paladin_Wand.GetComponent<Toggle>().isOn = false;

			
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	
	public void paladin_Spear(bool val)
	{	
		if (val == true)
		{
			Paladin_Sword.GetComponent<Toggle>().isOn = false;
			Paladin_Spear.GetComponent<Toggle>().isOn = true;
			Paladin_Mace.GetComponent<Toggle>().isOn = false;
			Paladin_Wand.GetComponent<Toggle>().isOn = false;
			
			W = "Spear";
			selectedName.text = "Spear :\n +10% Dexternity(Speed) \n +50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}	
	public void paladin_Mace(bool val)
	{	
		if (val == true)
		{
			Paladin_Sword.GetComponent<Toggle>().isOn = false;
			Paladin_Spear.GetComponent<Toggle>().isOn = false;
			Paladin_Mace.GetComponent<Toggle>().isOn = true;
			Paladin_Wand.GetComponent<Toggle>().isOn = false;
			
			W = "Wand";
			selectedName.text = "Wand :\n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	
	public void paladin_Wand(bool val)
	{	
		if (val == true)
		{
			Paladin_Sword.GetComponent<Toggle>().isOn = false;
			Paladin_Spear.GetComponent<Toggle>().isOn = false;
			Paladin_Mace.GetComponent<Toggle>().isOn = false;
			Paladin_Wand.GetComponent<Toggle>().isOn = true;
			
			W = "Mace";
			selectedName.text = "Mace : +50% Strength \n +100% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	public void mage_Dagger(bool val)
	{	
		if (val == true)
		{
			Mage_Dagger.GetComponent<Toggle>().isOn = true;
			Mage_Wand.GetComponent<Toggle>().isOn = false;

			
			W = "Dagger";
			selectedName.text = "Dagger : \n + 50% Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	public void mage_Wand(bool val)
	{	
		if (val == true)
		{
			Mage_Dagger.GetComponent<Toggle>().isOn = false;
			Mage_Wand.GetComponent<Toggle>().isOn = true;
			
			W = "Wand";
			selectedName.text = "Wand :\n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}

	public void knight_Sword(bool val)
	{	
		if (val == true)
		{
			Knight_Sword.GetComponent<Toggle>().isOn = true;
			Knight_Katana.GetComponent<Toggle>().isOn = false;

			
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}	
	
	public void knight_Katana(bool val)
	{	
		if (val == true)
		{
			Knight_Sword.GetComponent<Toggle>().isOn = false;
			Knight_Katana.GetComponent<Toggle>().isOn = true;


			
			W = "Katana";
			selectedName.text = "Katana : +100% Strength \n + 50% Dexternity(Speed) \n -50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	public void duelist_Sword(bool val)
	{	
		if (val == true)
		{
			Duelist_Sword.GetComponent<Toggle>().isOn = true;
			Duelist_Spear.GetComponent<Toggle>().isOn = false;
			Duelist_Dagger.GetComponent<Toggle>().isOn = false;
			Duelist_Mace.GetComponent<Toggle>().isOn = false;
			Duelist_Katana.GetComponent<Toggle>().isOn = false;
			
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void duelist_Dagger(bool val)
	{	
		if (val == true)
		{
			Duelist_Sword.GetComponent<Toggle>().isOn = false;
			Duelist_Spear.GetComponent<Toggle>().isOn = false;
			Duelist_Dagger.GetComponent<Toggle>().isOn = true;
			Duelist_Mace.GetComponent<Toggle>().isOn = false;
			Duelist_Katana.GetComponent<Toggle>().isOn = false;
			
			W = "Dagger";
			selectedName.text = "Dagger : \n + 50% Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void duelist_Mace(bool val)
	{	
		if (val == true)
		{
			Duelist_Sword.GetComponent<Toggle>().isOn = false;
			Duelist_Spear.GetComponent<Toggle>().isOn = false;
			Duelist_Dagger.GetComponent<Toggle>().isOn = false;
			Duelist_Mace.GetComponent<Toggle>().isOn = true;
			Duelist_Katana.GetComponent<Toggle>().isOn = false;
			
			W = "Mace";
			selectedName.text = "Mace : +50% Strength \n +100% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();		
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	 
	public void duelist_Katana(bool val)
	{	
		if (val == true)
		{
			Duelist_Sword.GetComponent<Toggle>().isOn = false;
			Duelist_Spear.GetComponent<Toggle>().isOn = false;
			Duelist_Dagger.GetComponent<Toggle>().isOn = false;
			Duelist_Mace.GetComponent<Toggle>().isOn = false;
			Duelist_Katana.GetComponent<Toggle>().isOn = true;
			
			W = "Katana";
			selectedName.text = "Katana : +100% Strength \n + 50% Dexternity(Speed) \n -50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	public void duelist_Spear(bool val)
	{	
		if (val == true)
		{
			Duelist_Sword.GetComponent<Toggle>().isOn = false;
			Duelist_Spear.GetComponent<Toggle>().isOn = true;
			Duelist_Dagger.GetComponent<Toggle>().isOn = false;
			Duelist_Mace.GetComponent<Toggle>().isOn = false;
			Duelist_Katana.GetComponent<Toggle>().isOn = false;
			
			W = "Spear";
			selectedName.text = "Spear :\n +10% Dexternity(Speed) \n +50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();	
			Player_Data Data = Player.GetComponent<Player_Data>();
			Data.weapon(W);
		}
	}
	
	 

}