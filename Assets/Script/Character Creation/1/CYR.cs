using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class CYR : MonoBehaviour
{
	public Text selectedName;
	public string R = "";
	Cryptography cryptography = new Cryptography("Rey@2626");
	

	void Start()
	{
	
	}
	
	public void Dropdown_IndexChanged(int index)
	{
		int abc = index;
		if (abc==0)
		{
			R = "Human";
			selectedName.text = "Human : Good At Everything.";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();


		}
		
		if (abc==1)
		{
			R = "Elf";
			selectedName.text = "Elf : -25% Base Strength \n -25% Base Endurance(HP) \n -25% Base Vitality(Defense) \n +75% Base Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
			
		}
		
		if (abc==2)
		{
			R = "Dwarf";			
			selectedName.text = "Drwaf : +25% Base Strength \n +75% Base Endurance(HP) \n -50% Base Dexternity(Speed) \n -50% Base Vitality(Defense)";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
				
		}
		
		if (abc==3)
		{
			R = "Orc";
			selectedName.text = "Orc : +50% Base Strength \n +50% Base Endurance(HP) \n -50% Base Intelligence(Magic Attack) \n -50% Base Constitution(M Defense) ";
			string encrypted = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted)
						   .Commit();
				
		}
	}
}





