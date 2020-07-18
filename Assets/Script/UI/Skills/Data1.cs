using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CI.QuickSave;
using SaveSystem;

public class Data1 : MonoBehaviour
{
	Cryptography cryptography = new Cryptography("Rey@2626");
	
	public GameObject A_1_1;
	public GameObject A_1_2;
	public GameObject A_1_3;
	public GameObject A_1_4;
	public GameObject A_1_5;
	public GameObject A_1_6;
	public GameObject A_1_7;
	public GameObject A_1_8;
	public GameObject A_1_9;
	public GameObject A_1_10;
	
	public GameObject A_2_1;
	public GameObject A_2_2;
	public GameObject A_2_3;
	public GameObject A_2_4;
	public GameObject A_2_5;
	public GameObject A_2_6;
	public GameObject A_2_7;
	public GameObject A_2_8;
	public GameObject A_2_9;
	public GameObject A_2_10;
	
	public GameObject A_3_1;
	public GameObject A_3_2;
	public GameObject A_3_3;
	public GameObject A_3_4;
	public GameObject A_3_5;
	public GameObject A_3_6;
	public GameObject A_3_7;
	public GameObject A_3_8;
	public GameObject A_3_9;
	public GameObject A_3_10;
	
	public GameObject A_4_1;
	public GameObject A_4_2;
	public GameObject A_4_3;
	public GameObject A_4_4;
	public GameObject A_4_5;
	public GameObject A_4_6;
	public GameObject A_4_7;
	public GameObject A_4_8;
	public GameObject A_4_9;
	public GameObject A_4_10;
	
	public string A_1_1s;
	public string A_1_2s;
	public string A_1_3s;
	public string A_1_4s;
	public string A_1_5s;
	public string A_1_6s;
	public string A_1_7s;
	public string A_1_8s;
	public string A_1_9s;
	public string A_1_10s;
	
	public string A_2_1s;
	public string A_2_2s;
	public string A_2_3s;
	public string A_2_4s;
	public string A_2_5s;
	public string A_2_6s;
	public string A_2_7s;
	public string A_2_8s;
	public string A_2_9s;
	public string A_2_10s;
	
	public string A_3_1s;
	public string A_3_2s;
	public string A_3_3s;
	public string A_3_4s;
	public string A_3_5s;
	public string A_3_6s;
	public string A_3_7s;
	public string A_3_8s;
	public string A_3_9s;
	public string A_3_10s;
	
	public string A_4_1s;
	public string A_4_2s;
	public string A_4_3s;
	public string A_4_4s;
	public string A_4_5s;
	public string A_4_6s;
	public string A_4_7s;
	public string A_4_8s;
	public string A_4_9s;
	public string A_4_10s;
	void Start()
	{
        QuickSaveReader.Create("Settings")
                       .Read<string>(cryptography.Encrypt("A_1_1"), (r) => {  A_1_1s = cryptography.Decrypt<string>(r); })	
					   .Read<string>(cryptography.Encrypt("A_1_2"), (r) => {  A_1_2s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_3"), (r) => {  A_1_3s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_4"), (r) => {  A_1_4s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_5"), (r) => {  A_1_5s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_6"), (r) => {  A_1_6s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_7"), (r) => {  A_1_7s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_8"), (r) => {  A_1_8s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_9"), (r) => {  A_1_9s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_1_10"), (r) => {  A_1_10s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_1"), (r) => {  A_2_1s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_2"), (r) => {  A_2_2s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_3"), (r) => {  A_2_3s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_4"), (r) => {  A_2_4s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_5"), (r) => {  A_2_5s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_6"), (r) => {  A_2_6s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_7"), (r) => {  A_2_7s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_8"), (r) => {  A_2_8s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_9"), (r) => {  A_2_9s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_2_10"), (r) => {  A_2_10s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_1"), (r) => {  A_3_1s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_2"), (r) => {  A_3_2s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_3"), (r) => {  A_3_3s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_4"), (r) => {  A_3_4s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_5"), (r) => {  A_3_5s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_6"), (r) => {  A_3_6s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_7"), (r) => {  A_3_7s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_8"), (r) => {  A_3_8s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_9"), (r) => {  A_3_9s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_3_10"), (r) => {  A_3_10s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_1"), (r) => {  A_4_1s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_2"), (r) => {  A_4_2s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_3"), (r) => {  A_4_3s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_4"), (r) => {  A_4_4s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_5"), (r) => {  A_4_5s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_6"), (r) => {  A_4_6s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_7"), (r) => {  A_4_7s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_8"), (r) => {  A_4_8s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_9"), (r) => {  A_4_9s = cryptography.Decrypt<string>(r); })
					   .Read<string>(cryptography.Encrypt("A_4_10"), (r) => {  A_4_10s = cryptography.Decrypt<string>(r); });
			
			A_1_1.SetActive(bool.Parse(A_1_1s));
			A_1_2.SetActive(bool.Parse(A_1_2s));
			A_1_3.SetActive(bool.Parse(A_1_3s));
			A_1_4.SetActive(bool.Parse(A_1_4s));
			A_1_5.SetActive(bool.Parse(A_1_5s));
			A_1_6.SetActive(bool.Parse(A_1_6s));
			A_1_7.SetActive(bool.Parse(A_1_7s));
			A_1_8.SetActive(bool.Parse(A_1_8s));
			A_1_9.SetActive(bool.Parse(A_1_9s));
			A_1_10.SetActive(bool.Parse(A_1_10s));
			
			A_2_1.SetActive(bool.Parse(A_2_1s));
			A_2_2.SetActive(bool.Parse(A_2_2s));
			A_2_3.SetActive(bool.Parse(A_2_3s));
			A_2_4.SetActive(bool.Parse(A_2_4s));
			A_2_5.SetActive(bool.Parse(A_2_5s));
			A_2_6.SetActive(bool.Parse(A_2_6s));
			A_2_7.SetActive(bool.Parse(A_2_7s));
			A_2_8.SetActive(bool.Parse(A_2_8s));
			A_2_9.SetActive(bool.Parse(A_2_9s));
			A_2_10.SetActive(bool.Parse(A_2_10s));
			
			A_3_1.SetActive(bool.Parse(A_3_1s));
			A_3_2.SetActive(bool.Parse(A_3_2s));
			A_3_3.SetActive(bool.Parse(A_3_3s));
			A_3_4.SetActive(bool.Parse(A_3_4s));
			A_3_5.SetActive(bool.Parse(A_3_5s));
			A_3_6.SetActive(bool.Parse(A_3_6s));
			A_3_7.SetActive(bool.Parse(A_3_7s));
			A_3_8.SetActive(bool.Parse(A_3_8s));
			A_3_9.SetActive(bool.Parse(A_3_9s));
			A_3_9.SetActive(bool.Parse(A_3_10s));
			
			A_4_1.SetActive(bool.Parse(A_4_1s));
			A_4_2.SetActive(bool.Parse(A_4_2s));
			A_4_3.SetActive(bool.Parse(A_4_3s));
			A_4_4.SetActive(bool.Parse(A_4_4s));
			A_4_5.SetActive(bool.Parse(A_4_5s));
			A_4_6.SetActive(bool.Parse(A_4_6s));
			A_4_7.SetActive(bool.Parse(A_4_7s));
			A_4_8.SetActive(bool.Parse(A_4_8s));
			A_4_9.SetActive(bool.Parse(A_4_9s));
			A_4_10.SetActive(bool.Parse(A_4_10s));
	}
}