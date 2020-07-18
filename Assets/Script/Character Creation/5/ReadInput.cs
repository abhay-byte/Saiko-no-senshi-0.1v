using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class ReadInput : MonoBehaviour
{

	Cryptography cryptography = new Cryptography("Rey@2626");
	public GameObject Player;

	public void Text_Changed(string newText)
	{
		Player_Data Data = Player.GetComponent<Player_Data>();
		Data.name(newText);
			string encrypted = cryptography.Encrypt(newText);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Name"), encrypted)
						   .Commit();
	}



}