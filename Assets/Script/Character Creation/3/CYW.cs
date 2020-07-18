using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class CYW : MonoBehaviour
{
	public Text selectedName;
	public string W = "";
	Cryptography cryptography = new Cryptography("Rey@2626");
	

	void Start()
	{
		
	}
	
	public void Dropdown_IndexChanged(int index)
	{
		int abc = index;
		if (abc==0)
		{
			W = "One Handed Sword";
			selectedName.text = "One Handed Sword : \n +20% Dexternity(Speed) \n +25% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		
		if (abc==1)
		{
			W = "Two Handed Sword";
			selectedName.text = "Two Handed Sword :\n +120% Strength \n-25% Dexternity(Speed) \n+35% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		
		if (abc==2)
		{
			W = "Halberd";
			selectedName.text = "Halbred :\n +10% Dexternity(Speed) \n +50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		
		if (abc==3)
		{
			W = "Dagger";
			selectedName.text = "Dagger : \n + 50% Dexternity(Speed)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		if (abc==4)
		{
			W = "Magic Staff";
			selectedName.text = "Magic Staff :\n +100% Intelligence(Magic Attack)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		
		if (abc==5)
		{
			W = "Mace";
			selectedName.text = "Mace : +50% Strength \n +100% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
		
		if (abc==6)
		{
			W = "Katana";
			selectedName.text = "Katana : +100% Strength \n + 50% Dexternity(Speed) \n -50% Vitality(Defense)";
			string encrypted = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted)
						   .Commit();
		}
	}


}
