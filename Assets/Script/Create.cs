using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Create : MonoBehaviour
{
	
	Cryptography cryptography = new Cryptography("Rey@2626");
	
    void Start()
    {	
			string R = "Human";
			string encrypted1 = cryptography.Encrypt(R);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Race"), encrypted1)
						   .Commit();

			string C = "Warrior";
			string encrypted2 = cryptography.Encrypt(C);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Class"), encrypted2)
						   .Commit();						   

			string W = "One Handed Sword";
			string encrypted3 = cryptography.Encrypt(W);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Weapon"), encrypted3)
						   .Commit();


			string G = "Male";
			string encrypted4 = cryptography.Encrypt(G);
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Gender"), encrypted4)
						   .Commit();
						   
			string encrypted5 = cryptography.Encrypt("Dragon");
			QuickSaveWriter.Create("Temp")
						   .Write(cryptography.Encrypt("Name"), encrypted5)
						   .Commit();						   
						   		


		int Idw = 50;
		string weapon1 = "Black Dragon Sword";
		string type = "One Handed Sword";
		int phyattack1 = 35;
		int magattack1 = 35;
		int strengthmodifier = 5;
		int dexternitymodifier = 5;
		int intelligencemodifier = 1;
		int phyattackmodifier = 10;
		int magattackmodifier = 10;
		int pointstrength = 50;
		int pointdexternity = 45;
		int pointintelligence = 0;

		int Ida;
		int ArmorName;
		int BaseDefense;
		int PhyDefense;
		int MagDefense;
		int ModifierPhysicalAttack;
		int ModifierMagicAttack;
		int ModifierStrength;
		int ModifierDexternity;
		int ModifierIntelligence;
		int PointStrength;
		int PointDexternity;
		int Pointintelligence;
		int ModifierPhysiccalDefense;
		int ModifierMagicalDefense;
		int PointEndurance;
		int ModifierEndurance;
		
		List<string> Weapon7 = new List<string> (){"id7w","Steel Katana","Katana","15","5","6","6","1","10","1","10","15","5"};
		List<string> Weapon6 = new List<string> (){"id6w","Steel Mace","Mace","10","10","5","5","5","2","2","5","5","5"};
		List<string> Weapon5 = new List<string> (){"id5w","Leron Staff","Magic Staff","1","15","1","1","5","1","5","0","0","10"};
		List<string> Weapon4 = new List<string> (){"id4w","Scale Dagger","Dagger","5","1","1","5","1","2","1","0","10","0"};
		List<string> Weapon3 = new List<string> (){"id3w","Faron","Halberd","15","5","1","1","1","5","1","2","3","0"};
		List<string> Weapon2 = new List<string> (){"id2w","Great Sword","Two Handed Sword","25","1","3","2","1","3","2","10","2","0"};
		List<string> Weapon1 = new List<string> (){"id1w","Long Sword","One Handed Sword","10","0.1","1","1","0.1","1","0.1","2","1","0"};

		List<string> Armor1 = new List<string> (){"id1a","Leather Armor","10","12","8","1","1","1","1","1","1","0","0","0","1","1","0","1"};


		
		
		        
    }

}
