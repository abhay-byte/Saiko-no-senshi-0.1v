using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class HeroT : MonoBehaviour
{ 

	public Text HPT;
	public Text MANAT;
	public Text STT;
	public Text Gold;
	
	public Text NameT;
	public Text GenderT;
	public Text RaceT;
	public Text ClassT;
	public Text WeaponT;
	public Text ExpT;
	public Text coinT;
	public Text Hp1T;
	public Text Mana1T;
	public Text Stamina1T;
	public Text Physical_AttackT;
	public Text Physical_DefenseT;
	public Text Physical_ResistanceT;
	public Text Magic_AttackT;
	public Text Magic_DefenseT;
	public Text Magic_ResistanceT;
	public Text AgilityT;
	public Text AttackSpeedT;
	public Text StrengthT;
	public Text EnduranceT;
	public Text DexternityT;
	public Text ConstitutionT;
	public Text VitalityT;
	public Text IntelligenceT;
	

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
	public Vector3 Poval;
	public int fps;
	

	
	   public float speed = 3.0f;
	   int counter = 0;
	Cryptography cryptography = new Cryptography("Rey@2626");

    Animator animator;
	
	
    Rigidbody2D rigidbody2d;
	Transform transform;
	SpriteRenderer spriteRenderer;
    
    Vector2 lookDirection = new Vector2(1,0);
    public VariableJoystick variableJoystick;
    
    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
		spriteRenderer = GetComponent<SpriteRenderer>();
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
					   .Read<string>(cryptography.Encrypt("Exp"), (r) => { Exp = cryptography.Decrypt<double>(r); })
					   .Read<string>(cryptography.Encrypt("Poval"), (r) => { Poval = cryptography.Decrypt<Vector3>(r); })
					   .Read<string>(cryptography.Encrypt("fps"), (r) => { fps = cryptography.Decrypt<int>(r); });
					   Hp1 = Hp;
					   Mana1 = Mana;
					   Stamina1 = Stamina;
					   transform.position = Poval;
		Application.targetFrameRate = fps;
    }    
	void Update()
    {

        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        Vector2 position = rigidbody2d.position;
        
        position = position + move * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
	
		
		float HP1 = Convert.ToSingle(Hp1);
		float HP = Convert.ToSingle(Hp);
		float MANA = Convert.ToSingle(Mana);
		float MANA1 = Convert.ToSingle(Mana1);
		float ST = Convert.ToSingle(Stamina);
		float ST1 = Convert.ToSingle(Stamina1);

		
		HPT.text = 	"HP : "+ Convert.ToInt32(HP) + "/" + Convert.ToInt32(HP1);
		MANAT.text = "Mana : "+ Convert.ToInt32(MANA) + "/" + Convert.ToInt32(MANA1);
		STT.text = 	"Stamina : "+ Convert.ToInt32(ST) + "/" + Convert.ToInt32(ST1);
		Gold.text = " " + coin + " ";
		
		hp.instance.SetValue(HP/HP1);
		mp.instance.SetValue(MANA/MANA1);
		sa.instance.SetValue(ST/ST1);
		
		Exper();
	
		NameT.text = Name;
		GenderT.text = Gender;
		RaceT.text = Race;
		ClassT.text = Class;
		WeaponT.text = Weapon;
		ExpT.text = Exp +"/"+ ReqExp;
		coinT.text = " "+coin;
		Hp1T.text = " "+Hp1;
		Mana1T.text = " "+Mana1;
		Stamina1T.text = " "+Stamina1;
		Physical_AttackT.text = " "+Physical_Attack;
		Physical_DefenseT.text = " "+Physical_Defense;
		Physical_ResistanceT.text = " "+Physical_Resistance;
		Magic_AttackT.text = " "+Magic_Attack;
		Magic_DefenseT.text = " "+Magic_Defense;
		Magic_ResistanceT.text = " "+Magic_Resistance;
		AgilityT.text = " "+Agility;
		AttackSpeedT.text = " "+AttackSpeed;
		StrengthT.text = " "+Strength;
		EnduranceT.text = " "+Endurance;
		DexternityT.text = " "+Dexternity;
		ConstitutionT.text = " "+Constitution;
		VitalityT.text = " "+Vitality;
		IntelligenceT.text = " "+Intelligence;
		
		if (Input.GetButton("Normal_Attack")){
		animator.SetTrigger("Launch");
		}
        if (Input.GetButton("Interact"))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                EnemyT character = hit.collider.GetComponent<EnemyT>();
                if (character != null)
                {
				
                    character.DisplayDialog();
                }
            }
        }

	}

	void OnCollisionEnter2D(Collision2D other)
		{
			Enemy player = other.gameObject.GetComponent<Enemy>();

			if (player != null)
			{
				
				Debug.Log("HIT BY Player_Action_Anim");

			}
		}
		
	void Exper(){
		ReqExp = 100*Level*Level;
		if (Exp >= ReqExp){
			Level = Level+1;
		}
	}
	

	public void strength(double val){
		Strength = val;
		}
		
	public void endurance(double val){
		Endurance = val;
		}
		
	public void dexternity(double val){
		Dexternity = val;
		}
		
	public void constitution(double val){
		Constitution = val;
		}
		
	public void vitality(double val){
		Vitality = val;
		}
		
	public void intelligence(double val){
		Intelligence = val;
		}
		
	public void hp1(double val){
		Hp = val;
		Hp1 = val;
		}
		
	public void physical_Attack(double val){
		Physical_Attack = val;
		}
		
	public void magic_Attack(double val){
		Magic_Attack = val;
		}
		
	public void physical_Resistance(double val){
		Physical_Resistance = val;
		}
		
	public void physical_Defense(double val){
		Physical_Defense = val;
		}
		
	public void magic_Defense(double val){
		Magic_Defense = val;
		}
		
	public void magic_Resistance(double val){
		Magic_Resistance = val;
		}
		
	public void agility(double val){
		Agility = val;
		}
		
	public void stamina(double val){
		Stamina = val;
		Stamina1 = val;
		}
		
	public void mana(double val){
		Mana = val;
		Mana1 = val;
		}
		
	public void attackSpeed(double val){
		AttackSpeed = val;
		}
	public void Ft(Vector3 val){
		Poval = val;
		transform.position = Poval;
		}
	public void Fps(int val){
		fps = val;
		Application.targetFrameRate = fps;
		}
	public void Save(){
		
			Poval = transform.position;
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
						   .Write(cryptography.Encrypt("Poval"), encrypted27)
						   .Commit();						   
						  
		}
}