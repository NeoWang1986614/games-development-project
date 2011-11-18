using UnityEngine;
using System.Collections;
using System;


public class GameSettings : MonoBehaviour {
	public const string PLAYER_SPAWN_POINT = " Player Spawn Point"; // this is the name of the game Object where the player spawns
	
	void Awake(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SaveCharacterData(){
		GameObject pc = GameObject.Find("pc");
		
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		PlayerPrefs.SetString("Player Name", pcClass.Name);
		
		for(int cnt = 0; cnt< Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+ "BaseValue",pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+ "  -Exp To Level",pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
		}
		for(int cnt = 0; cnt< Enum.GetValues(typeof(VitalName)).Length; cnt++){
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+ "BaseValue",pcClass.GetVital(cnt).BaseValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+ "  -Exp To Level",pcClass.GetVital(cnt).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+ "  Cur Value",pcClass.GetVital(cnt).CurValue);
			//PlayerPrefs.SetString(((VitalName)cnt).ToString() + "- Mods", pcClass.GetVital(cnt).GetModifingAttributeString());
			
		}
		for(int cnt = 0; cnt< Enum.GetValues(typeof(SkillName)).Length; cnt++){
			PlayerPrefs.SetInt(((SkillName)cnt).ToString()+ "BaseValue",pcClass.GetSkill(cnt).BaseValue);
			PlayerPrefs.SetInt(((SkillName)cnt).ToString()+ "  -Exp To Level",pcClass.GetSkill(cnt).ExpToLevel);
			//PlayerPrefs.SetString(((SkillName)cnt).ToString() + "- Mods", pcClass.GetSkill(cnt).GetModifingAttributeString());
			
			
		}
		
	}
	public void LoadCharacterData(){
		GameObject pc = GameObject.Find("pc");
		
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		
		pcClass.Name = PlayerPrefs.GetString("Player Name", "Name Me");
		
		for(int cnt = 0; cnt< Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			pcClass.GetPrimaryAttribute(cnt).BaseValue = PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+ "BaseValue",0);
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+ "  -Exp To Level",Attribute.STARTING_EXP_COST);
		}
		
		for(int cnt = 0; cnt< Enum.GetValues(typeof(VitalName)).Length; cnt++){
			pcClass.GetVital(cnt).BaseValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString()+ "BaseValue",0);
			pcClass.GetVital(cnt).ExpToLevel = PlayerPrefs.GetInt(((VitalName)cnt).ToString()+ "  -Exp To Level",0);
			
			pcClass.GetVital(cnt).Update();
			
			
			pcClass.GetVital(cnt).CurValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString()+ "  Cur Value",1);
		}

		for(int cnt = 0; cnt< Enum.GetValues(typeof(SkillName)).Length; cnt++){
			pcClass.GetSkill(cnt).BaseValue = PlayerPrefs.GetInt(((SkillName)cnt).ToString()+ "BaseValue",0);
			pcClass.GetSkill(cnt).ExpToLevel = PlayerPrefs.GetInt(((SkillName)cnt).ToString()+ "  -Exp To Level",0);
			}
		
		for(int cnt = 0; cnt<Enum.GetValues(typeof(SkillName)).Length; cnt++ ){
			Debug.Log(((SkillName)cnt).ToString()+ " : " + pcClass.GetSkill(cnt).BaseValue + " - " + pcClass.GetSkill(cnt).ExpToLevel);
		}
		
	}
}
