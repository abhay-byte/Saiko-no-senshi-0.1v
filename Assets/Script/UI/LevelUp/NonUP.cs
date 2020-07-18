using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class NonUP : MonoBehaviour
{
	int counter = 0;
	public string Race ;
	public string Class ;
	public string Weapon ;
	
	public double Strength;
	public double Endurance;
	public double Dexternity;
	public double Constitution;
	public double Vitality;
	public double Intelligence;
	
	public double Hp1;
	public double Physical_Attack1;
	public double Magic_Attack1;
	public double Physical_Resistance1;
	public double Physical_Defense1;
	public double Magic_Defense1;
	public double Magic_Resistance1;
	public double Agility1;
	public double Stamina1;
	public double Mana1;
	public double AttackSpeed1;
	
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
	public int Level;
	public int ULevel;
	public double Exp;
	public double coin;
	public double ReqExp;
	public double Points;

	public GameObject Button;
	public GameObject UIElements0;
	public GameObject UIElements1;
	public GameObject UIElements2;
	public GameObject UIElements3;
	public GameObject UIElements4;
	public GameObject UIElements5;
	
	public GameObject data1;

	Cryptography cryptography = new Cryptography("Rey@2626");
	
    void Start()
    {
        QuickSaveReader.Create("UserData")
                       .Read<string>(cryptography.Encrypt("Race"), (r) => {  Race = cryptography.Decrypt<string>(r); })
                       .Read<string>(cryptography.Encrypt("Class"), (r) => { Class = cryptography.Decrypt<string>(r); })
                       .Read<string>(cryptography.Encrypt("Weapon"), (r) => { Weapon = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("Strength"), (r) => { Strength = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Endurance"), (r) => { Endurance = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Dexternity"), (r) => { Dexternity = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Constitution"), (r) => { Constitution = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Vitality"), (r) => { Vitality = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Intelligence"), (r) => { Intelligence = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Name"), (r) => { Name = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("Gender"), (r) => { Gender = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("Hp"), (r) => { Hp = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Physical_Attack"), (r) => { Physical_Attack = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Magic_Attack"), (r) => { Magic_Attack = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Physical_Resistance"), (r) => { Physical_Resistance = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Physical_Defense"), (r) => { Physical_Defense = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Magic_Defense"), (r) => { Magic_Defense = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Magic_Resistance"), (r) => { Magic_Resistance = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Agility"), (r) => { Agility = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Stamina"), (r) => { Stamina = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Mana"), (r) => { Mana = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("AttackSpeed"), (r) => { AttackSpeed = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Coin"), (r) => { coin = cryptography.Decrypt<double>(r); })
				       .Read<string>(cryptography.Encrypt("Level"), (r) => { Level = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("ULevel"), (r) => { ULevel = cryptography.Decrypt<int>(r); })
					   .Read<string>(cryptography.Encrypt("Exp"), (r) => { Exp = cryptography.Decrypt<double>(r); });
					   }
	
	public void Point1(double p)
	{
		Points = p;
	}
	
	public void Strength1(double p1)
	{
		Strength = p1;
	}

	public void Endurance1(double p2)
	{
		Endurance = p2;
	}
	
	public void Dexternity1(double p3)
	{
		Dexternity = p3;
	}
	
	public void Constitution1(double p4)
	{
		Constitution = p4;
	}
	
	public void Vitality1(double p5)
	{
		Vitality = p5;
	}
	
	public void Intelligence1(double p6)
	{
		Intelligence = p6;
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
		

			
	}
	
	public void Next6(){
		if (Points==0){

		cal();
		ULevel = 0;
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

		HeroT Data = data1.GetComponent<HeroT>();
		
		Data.strength(Strength);
		Data.endurance(Endurance);
		Data.dexternity(Dexternity);
		Data.constitution(Constitution);
		Data.vitality(Vitality);
		Data.intelligence(Intelligence);
		Data.hp1(Hp);
		Data.physical_Attack(Physical_Attack);
		Data.magic_Attack(Magic_Attack);
		Data.physical_Resistance(Physical_Resistance);
		Data.physical_Defense(Physical_Defense);
		Data.magic_Defense(Magic_Defense);
		Data.magic_Resistance(Magic_Resistance);
		Data.agility(Agility);
		Data.stamina(Stamina);
		Data.mana(Mana);
		Data.attackSpeed(AttackSpeed);
		
		
		Button.SetActive(false);
		UIElements0.SetActive(true);
		UIElements1.SetActive(true);
		UIElements2.SetActive(true);
		UIElements3.SetActive(true);
		UIElements4.SetActive(true);
		UIElements5.SetActive(true);



		}
	}
}