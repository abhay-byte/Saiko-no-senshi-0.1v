using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Gender : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
	void Start()
	{
	}
	public string G;
	
	public void Dropdown_IndexChanged(int index)
	{
		int abc = index;
		if (abc==0)
		{
			G = "Male";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();
		}
		
		if (abc==1)
		{
			G = "Female";
			string encrypted = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted)
						   .Commit();
		}
		
	}
}