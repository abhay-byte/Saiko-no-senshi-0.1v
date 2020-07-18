using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class CYC : MonoBehaviour
{
	public Text selectedName;
	public string C = "";
	Cryptography cryptography = new Cryptography("Rey@2626");
	

	void Start()
	{
	
	}
	
	public void Dropdown_IndexChanged(int index)
	{
		int abc = index;
		if (abc==0)
		{
			C = "Warrior";
			selectedName.text = "Warrior : Strength +10 \n Dexternity(Speed) +10 \n Endurance(HP) +10 \n Vitality(Defense) +10";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
		
		if (abc==1)
		{
			C = "Berseker";
			selectedName.text = "Berseker : Strength +20 \n Dexternity(Speed) +20 \n -10% Constitution(M Defense) \n +30% Endurance(HP) \n -20% Intelligence";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();			
		}
		
		if (abc==2)
		{
			C = "Paladin";
			selectedName.text = "Paladin: Strength +10 \n Dexternity(Speed) +5 \n Endurance(HP) +10 \n Intelligence(Magic Attack) +5 \n Constitution(M Defense) +10";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
		
		if (abc==3)
		{
			C = "Mage";
			selectedName.text = "Mage : -50% Strength \n -50%  Dexternity(Speed) \n -50% Endurance(HP) \n Intelligence(Magic Attack) +30 \n Constitution(M Defense) +10 \n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
		if (abc==4)
		{
			C = "Knight";
			selectedName.text = "Knight : Strength +15 \n Endurance(HP) +15 \n Vitality(Defense) +10";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
		
		if (abc==5)
		{
			C = "Barbarian";
			selectedName.text = "Barbarian : Strength +10 \n Endurance(HP) +20 \n Dexternity(Speed) +10 \n -20% Constitution(M Defense) \n +10% Strength \n +10% Endurance(HP)";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
		
		if (abc==6)
		{
			C = "Duelist";
			selectedName.text = "Duelist : Strength +15 \n Endurance(HP) +5 \n Dexternity(Speed) +15 \n Vitality(Defense) +5";
			string encrypted = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Char")
						   .Write(cryptography.Encrypt("Class"), encrypted)
						   .Commit();
		}
	}


}