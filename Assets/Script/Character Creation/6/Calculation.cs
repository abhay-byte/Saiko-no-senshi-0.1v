using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Calculation : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");

	public Text RaceT;
	public Text ClassT;
	public Text WeaponT;
	public Text NameT;
	public Text GenderT;	
	public Text HpT;
	public Text Physical_AttackT;
	public Text Magic_AttackT;
	public Text Physical_ResistanceT;
	public Text Physical_DefenseT;
	public Text Magic_DefenseT;
	public Text Magic_ResistanceT;
	public Text AgilityT;
	public Text StaminaT;
	public Text ManaT;
	public Text AttackSpeedT;
	
	public string Race;
	public string Class;
	public string Weapon;
	
	public double Strength;
	public double Endurance;
	public double Dexternity;
	public double Constitution;
	public double Vitality;
	public double Intelligence;
	
	public int Hp1;
	public int Physical_Attack1;
	public int Magic_Attack1;
	public int Physical_Resistance1;
	public int Physical_Defense1;
	public int Magic_Defense1;
	public int Magic_Resistance1;
	public int Agility1;
	public int Stamina1;
	public int Mana1;
	public int AttackSpeed1;
	
	public double Hp;
	public double Physical_Attack;
	public double Magic_Attack;
	public double Physical_Resistance;
	public double Physical_Defense;
	public double Magic_Defense;
	public double Magic_Resistance;
	public double Agility;
	public double Stamina;
	public double Mana;
	public double AttackSpeed;
	
	public string Name;
	public string Gender;
	public int Level = 1;
	public int ULevel = 1;
	public double Exp = 0;
	public double coin = 1000;
	public int Skill;
	public Vector3 Poval ;
	
	public int check = 0;
	
	
	int counter = 0;

    void Start()
    {
        QuickSaveReader.Create("Temp")
                       .Read<string>(cryptography.Encrypt("Race"), (r) => {  Race = cryptography.Decrypt<string>(r); })
                       .Read<string>(cryptography.Encrypt("Class"), (r) => { Class = cryptography.Decrypt<string>(r); })
                       .Read<string>(cryptography.Encrypt("Weapon"), (r) => { Weapon = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("Strength"), (r) => { Strength = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Endurance"), (r) => { Endurance = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Dexternity"), (r) => { Dexternity = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Constitution"), (r) => { Constitution = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Vitality"), (r) => { Vitality = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Intelligence"), (r) => { Intelligence = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Name"), (r) => { Name = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("Gender"), (r) => { Gender = cryptography.Decrypt<string>(r); });
			Race_c();
			Class_c();
			Weapon_c();
			
			cal();
	}
	

	void Update()
	{

	}
	
		public void Race_c(){
			if (Name==""){
				Name = "Dragon";
			}
				
			if (Race=="Elf"){
				Strength = Strength*0.75;
				Endurance = Endurance*0.75;
				Vitality = Vitality*0.75;
				Dexternity = Dexternity*1.75;
				}
			
			if (Race=="Dwarf"){
				Strength = Strength*1.25;
				Endurance = Endurance*1.75;
				Dexternity = Dexternity*0.5;
				Vitality = Vitality*1.5;
				}
			
			if (Race=="Orc"){
				Strength = Strength*1.5;
				Endurance = Endurance*1.5;
				Intelligence = Intelligence*0.5;
				Constitution = Constitution*0.5;
				}
		}
	
		public void Class_c(){

			
			if (Class == "Warrior"){
				Strength = Strength+10;
				Dexternity = Dexternity+10;
				Endurance = Endurance+10;
				Vitality = Vitality+10;	
			}
			
			if (Class == "Berseker"){
				Strength = Strength+20;
				Dexternity = Dexternity+20;
				Constitution = Constitution*0.90;
				Endurance = Endurance*1.30;
				Intelligence = Intelligence*0.80;
			}
			
			if (Class == "Paladin"){
				Strength = Strength+10;
				Dexternity = Dexternity+5;
				Endurance = Endurance+10;
				Intelligence = Intelligence+5;
				Constitution = Constitution+10;
				
			}
			
			if (Class == "Mage"){
				Strength = Strength*0.5;
				Dexternity = Dexternity*0.5;
				Endurance = Endurance*0.5;
				Intelligence = Intelligence+30;
				Constitution = Constitution+10;
				Intelligence = Intelligence*2.5;			
			}
			
			if (Class == "Knight"){
				Strength = Strength+15;
				Endurance = Endurance+15;
				Vitality = Vitality+10;
			}
		
			if (Class == "Barbarian"){
				Strength = Strength+10;
				Endurance = Endurance+20;
				Dexternity = Dexternity+10;
				Constitution = Constitution*0.80;
				Strength = Strength*1.10;
				Endurance = Endurance*1.10;
				}
			
			if (Class == "Duelist"){
				Strength = Strength+15;
				Endurance = Endurance+5;
				Dexternity = Dexternity+15;
				Vitality = Vitality+5;
				
			}
		}	
		
		public void Weapon_c(){
			
			if (Weapon == "One Handed Sword"){
				Dexternity = Dexternity*1.20;
				Vitality = Vitality*1.25;
			}
			
			if (Weapon == "Two Handed Sword"){
				Strength = Strength*2.2;
				Dexternity = Dexternity*0.75;
				Vitality = Vitality*1.35;
				
			}
			
			if (Weapon == "Halbred"){
				Dexternity = Dexternity*1.10;
				Vitality = Vitality*1.5;
			}
			
			if (Weapon == "Dagger"){
				Dexternity = Dexternity*1.5;
				Strength = Strength+10;
			}
			
			if (Weapon == "Magic Staff"){
				Intelligence = Intelligence*1.94;
				
			}
			
			if (Weapon == "Mace"){
				Strength = Strength*1.5;
				Vitality = Vitality*2.0;
				
			}
			
			if (Weapon == "Katana"){
				Strength = Strength*2.0;
				Dexternity = Dexternity*1.5;
				Vitality = Vitality*0.5;
				
				
			}
		}
		
	public void cal(){
		
		Hp1 = Convert.ToInt32(Endurance*30);
		Physical_Attack1 = Convert.ToInt32(Strength*10);
		Magic_Attack1 = Convert.ToInt32(Intelligence*10);
		Physical_Resistance1 = Convert.ToInt32((Vitality*5)+(Endurance*5));
		Physical_Defense1 = Convert.ToInt32(Vitality*10);
		Magic_Defense1 = Convert.ToInt32(Constitution*10);
		Magic_Resistance1 = Convert.ToInt32((Constitution*5)+(Endurance*5));
		Agility1 = Convert.ToInt32(Dexternity*10);
		Stamina1 = Convert.ToInt32((Endurance*7)+(Strength*2)+(Vitality*1));
		Mana1 = Convert.ToInt32((Intelligence*8)+(Strength*1)+(Constitution*1));
		AttackSpeed1 = Convert.ToInt32((Dexternity/10)+1);
		
		Hp = Endurance*30;
		Physical_Attack = Strength*10;
		Magic_Attack = Intelligence*10;
		Physical_Resistance = (Vitality*5)+(Endurance*5);
		Physical_Defense = Vitality*10;
		Magic_Defense = Constitution*10;
		Magic_Resistance = (Constitution*5)+(Endurance*5);
		Agility = Dexternity*10;
		Stamina = (Endurance*7)+(Strength*2)+(Vitality*1);
		Mana = (Intelligence*8)+(Strength*1)+(Constitution*1);
		AttackSpeed = (Dexternity/10)+1;
		
		HpT.text = Hp1.ToString();
		Physical_AttackT.text = Physical_Attack1.ToString();
		Magic_AttackT.text = Magic_Attack1.ToString();
		Physical_ResistanceT.text = Physical_Resistance1.ToString();
		Physical_DefenseT.text = Physical_Defense1.ToString();
		Magic_DefenseT.text = Magic_Defense1.ToString();
		Magic_ResistanceT.text = Magic_Resistance1.ToString();
		AgilityT.text = Agility1.ToString();
		StaminaT.text = Stamina1.ToString();
		ManaT.text = Mana1.ToString();
		AttackSpeedT.text = AttackSpeed1.ToString()+" / Sec";
		
		NameT.text = Name;
		GenderT.text = Gender;
		RaceT.text = Race;
		WeaponT.text = Weapon;
		ClassT.text = Class;
		
			
	}
	
	public void Next6(){
		Application.LoadLevel("Test");
			
			string encrypted1 = cryptography.Encrypt(Hp);
			string encrypted2 = cryptography.Encrypt(Physical_Attack);
			string encrypted3 = cryptography.Encrypt(Magic_Attack);
			string encrypted4 = cryptography.Encrypt(Physical_Resistance);
			string encrypted5 = cryptography.Encrypt(Physical_Defense);
			string encrypted6 = cryptography.Encrypt(Magic_Defense);
			string encrypted7 = cryptography.Encrypt(Magic_Resistance);
			string encrypted8 = cryptography.Encrypt(Agility);
			string encrypted9 = cryptography.Encrypt(Stamina);
			string encrypted10 = cryptography.Encrypt(Mana);
			string encrypted11 = cryptography.Encrypt(AttackSpeed);
			string encrypted12 = cryptography.Encrypt(Level);
			string encrypted13 = cryptography.Encrypt(Exp);
			string encrypted14 = cryptography.Encrypt(ULevel);
			string encrypted15 = cryptography.Encrypt(coin);
			string encrypted16 = cryptography.Encrypt(Race);
			string encrypted17 = cryptography.Encrypt(Class);
			string encrypted18 = cryptography.Encrypt(Weapon);
			string encrypted19 = cryptography.Encrypt(Strength);
			string encrypted20 = cryptography.Encrypt(Endurance);
			string encrypted21 = cryptography.Encrypt(Dexternity);
			string encrypted22 = cryptography.Encrypt(Constitution);
			string encrypted23 = cryptography.Encrypt(Vitality);
			string encrypted24 = cryptography.Encrypt(Intelligence);
			string encrypted25 = cryptography.Encrypt(Name);
			string encrypted26 = cryptography.Encrypt(Gender);
			string encrypted27 = cryptography.Encrypt(Poval);			
			
			
			QuickSaveWriter.Create("UserData")
						   .Write(cryptography.Encrypt("Hp"), encrypted1)
						   .Write(cryptography.Encrypt("Physical_Attack"), encrypted2)
						   .Write(cryptography.Encrypt("Magic_Attack"), encrypted3)
						   .Write(cryptography.Encrypt("Physical_Resistance"), encrypted4)
						   .Write(cryptography.Encrypt("Physical_Defense"), encrypted5)
						   .Write(cryptography.Encrypt("Magic_Defense"), encrypted6)
						   .Write(cryptography.Encrypt("Magic_Resistance"), encrypted7)
						   .Write(cryptography.Encrypt("Agility"), encrypted8)
						   .Write(cryptography.Encrypt("Stamina"), encrypted9)
						   .Write(cryptography.Encrypt("Mana"), encrypted10)
						   .Write(cryptography.Encrypt("AttackSpeed"), encrypted11)
						   .Write(cryptography.Encrypt("Level"), encrypted12)
						   .Write(cryptography.Encrypt("Exp"), encrypted13)
						   .Write(cryptography.Encrypt("ULevel"), encrypted14)
						   .Write(cryptography.Encrypt("Coin"), encrypted15)
						   .Write(cryptography.Encrypt("Race"), encrypted16)
						   .Write(cryptography.Encrypt("Class"), encrypted17)
						   .Write(cryptography.Encrypt("Weapon"), encrypted18)
						   .Write(cryptography.Encrypt("Strength"), encrypted19)
						   .Write(cryptography.Encrypt("Endurance"), encrypted20)
						   .Write(cryptography.Encrypt("Dexternity"), encrypted21)
						   .Write(cryptography.Encrypt("Constitution"), encrypted22)
						   .Write(cryptography.Encrypt("Vitality"), encrypted23)
						   .Write(cryptography.Encrypt("Intelligence"), encrypted24)
						   .Write(cryptography.Encrypt("Name"), encrypted25)
						   .Write(cryptography.Encrypt("Gender"), encrypted26)
						   .Commit();
						   
		string A_1_1 = cryptography.Encrypt("true");
		string A_1_2 = cryptography.Encrypt("false");
		string A_1_3 = cryptography.Encrypt("false");
		string A_1_4 = cryptography.Encrypt("false");
		string A_1_5 = cryptography.Encrypt("false");
		string A_1_6 = cryptography.Encrypt("false");
		string A_1_7 = cryptography.Encrypt("false");
		string A_1_8 = cryptography.Encrypt("false");
		string A_1_9 = cryptography.Encrypt("false");
		string A_1_10 = cryptography.Encrypt("false");
		
		string A_2_1 = cryptography.Encrypt("false");
		string A_2_2 = cryptography.Encrypt("true");
		string A_2_3 = cryptography.Encrypt("false");
		string A_2_4 = cryptography.Encrypt("false");
		string A_2_5 = cryptography.Encrypt("false");
		string A_2_6 = cryptography.Encrypt("false");
		string A_2_7 = cryptography.Encrypt("false");
		string A_2_8 = cryptography.Encrypt("false");
		string A_2_9 = cryptography.Encrypt("false");
		string A_2_10 = cryptography.Encrypt("false");
		
		string A_3_1 = cryptography.Encrypt("false");
		string A_3_2 = cryptography.Encrypt("false");
		string A_3_3 = cryptography.Encrypt("false");
		string A_3_4 = cryptography.Encrypt("false");
		string A_3_5 = cryptography.Encrypt("false");
		string A_3_6 = cryptography.Encrypt("true");
		string A_3_7 = cryptography.Encrypt("false");
		string A_3_8 = cryptography.Encrypt("false");
		string A_3_9 = cryptography.Encrypt("false");
		string A_3_10 = cryptography.Encrypt("false");
		
		string A_4_1 = cryptography.Encrypt("false");
		string A_4_2 = cryptography.Encrypt("false");
		string A_4_3 = cryptography.Encrypt("false");
		string A_4_4 = cryptography.Encrypt("false");
		string A_4_5 = cryptography.Encrypt("false");
		string A_4_6 = cryptography.Encrypt("false");
		string A_4_7 = cryptography.Encrypt("true");
		string A_4_8 = cryptography.Encrypt("false");
		string A_4_9 = cryptography.Encrypt("false");
		string A_4_10 = cryptography.Encrypt("false");
		
			QuickSaveWriter.Create("Settings")
						   .Write(cryptography.Encrypt("A_1_1"), A_1_1)
						   .Write(cryptography.Encrypt("A_1_2"), A_1_2)
						   .Write(cryptography.Encrypt("A_1_3"), A_1_3)
						   .Write(cryptography.Encrypt("A_1_4"), A_1_4)
						   .Write(cryptography.Encrypt("A_1_5"), A_1_5)
						   .Write(cryptography.Encrypt("A_1_6"), A_1_6)
						   .Write(cryptography.Encrypt("A_1_7"), A_1_7)
						   .Write(cryptography.Encrypt("A_1_8"), A_1_8)
						   .Write(cryptography.Encrypt("A_1_9"), A_1_9)
						   .Write(cryptography.Encrypt("A_1_10"), A_1_10)
						   .Write(cryptography.Encrypt("A_2_1"), A_2_1)
						   .Write(cryptography.Encrypt("A_2_2"), A_2_2)
						   .Write(cryptography.Encrypt("A_2_3"), A_2_3)
						   .Write(cryptography.Encrypt("A_2_4"), A_2_4)
						   .Write(cryptography.Encrypt("A_2_5"), A_2_5)
						   .Write(cryptography.Encrypt("A_2_6"), A_2_6)
						   .Write(cryptography.Encrypt("A_2_7"), A_2_7)
						   .Write(cryptography.Encrypt("A_2_8"), A_2_8)
						   .Write(cryptography.Encrypt("A_2_9"), A_2_9)
						   .Write(cryptography.Encrypt("A_2_10"), A_2_10)
						   .Write(cryptography.Encrypt("A_3_1"), A_3_1)
						   .Write(cryptography.Encrypt("A_3_2"), A_3_2)
						   .Write(cryptography.Encrypt("A_3_3"), A_3_3)
						   .Write(cryptography.Encrypt("A_3_4"), A_3_4)
						   .Write(cryptography.Encrypt("A_3_5"), A_3_5)
						   .Write(cryptography.Encrypt("A_3_6"), A_3_6)
						   .Write(cryptography.Encrypt("A_3_7"), A_3_7)
						   .Write(cryptography.Encrypt("A_3_8"), A_3_8)
						   .Write(cryptography.Encrypt("A_3_9"), A_3_9)
						   .Write(cryptography.Encrypt("A_3_10"), A_3_10)
						   .Write(cryptography.Encrypt("A_4_1"), A_4_1)
						   .Write(cryptography.Encrypt("A_4_2"), A_4_2)
						   .Write(cryptography.Encrypt("A_4_3"), A_4_3)
						   .Write(cryptography.Encrypt("A_4_4"), A_4_4)
						   .Write(cryptography.Encrypt("A_4_5"), A_4_5)
						   .Write(cryptography.Encrypt("A_4_6"), A_4_6)
						   .Write(cryptography.Encrypt("A_4_7"), A_4_7)
						   .Write(cryptography.Encrypt("A_4_8"), A_4_8)
						   .Write(cryptography.Encrypt("A_4_9"), A_4_9)
						   .Write(cryptography.Encrypt("A_4_10"), A_4_10)

						   .Commit();
		
		
	}
	
	

		
		
}















