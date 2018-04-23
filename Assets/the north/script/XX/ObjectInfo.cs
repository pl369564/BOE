using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectInfo : MonoBehaviour {
	public static ObjectInfo _instance;

	private Dictionary<int,ObjectsInfo> objectInfoDict=new Dictionary<int, ObjectsInfo>();

	public TextAsset objectInfoListText;

	// Use this for initialization
	void Awake () {
		_instance = this;
		ReadInfo ();
		//print (objectInfoDict.Keys.Count);

	}
	public ObjectsInfo GetOjectInfoById(int id){
		ObjectsInfo info = null;
		objectInfoDict.TryGetValue (id, out info);
		return info;
	}

	void ReadInfo(){
		string text = objectInfoListText.text;
		string[] strArray=text.Split('\n');

		foreach (string str in strArray) {
			string[] proArray=str.Split(',');
			ObjectsInfo info=new ObjectsInfo();
			info.id=int.Parse(proArray[0]);
			int id=int.Parse(proArray[0]);
			info.name=proArray[1];
			info.icon_name=proArray[2];
			string str_type=proArray[3];
			switch(str_type){
			case"Drug":
					info.type=ObjectType.Drug;
				break;
			case"Equip":
					info.type=ObjectType.Equip;
				break;
			case"Mat":
					info.type=ObjectType.Mat;
				break;
			}
			if(info.type==ObjectType.Drug||info.type==ObjectType.Mat)
			{
				info.hp=int.Parse(proArray[4]);
				info.mp=int.Parse(proArray[5]);
				info.price_sell=int.Parse(proArray[6]);
				info.price_buy=int.Parse(proArray[7]);
			}else if(info.type==ObjectType.Equip){
				info.attack=int.Parse(proArray[4]);
				info.def=int.Parse(proArray[5]);
				info.speed=int.Parse(proArray[6]);
				info.price_sell=int.Parse(proArray[9]);
				info.price_buy=int.Parse(proArray[10]);
				string str_dressType=proArray[7];
				string str_applic=proArray[8];
				switch(str_dressType){
				case "Headgear":
					info.dressType=DressType.Headgear;
					break;
				case "Armor":
					info.dressType=DressType.Armor;
					break;
				case "LeftHand":
					info.dressType=DressType.LeftHand;
					break;
				case "RightHand":
					info.dressType=DressType.RightHand;
					break;
				case "Shoe":
					info.dressType=DressType.Shoe;
					break;
				case "Accessory":
					info.dressType=DressType.Accessory;
					break;
			}
				switch(str_applic){
				case "Common":
					info.applicationType=ApplicationType.Common;
					break;
				case "Magician":
					info.applicationType=ApplicationType.Magician;
					break;
				case "Swordman":
					info.applicationType=ApplicationType.Swordman;
					break;
				}
			}
//			if (info.type == ObjectType.Mat) {
//				info.hp=int.Parse(proArray[4]);
//				info.mp=int.Parse(proArray[5]);
//				info.price_sell=int.Parse(proArray[6]);
//				info.price_buy=int.Parse(proArray[7]);
//			}
			objectInfoDict.Add(id,info);

		}
	}
	// Update is called once per frame

}
public enum ObjectType{
	Drug,
	Equip,
	Mat
}
public enum DressType{
	Headgear,
	RightHand,
	LeftHand,
	Shoe,
	Armor,
	Accessory
}
public enum ApplicationType{
	Swordman,
	Magician,
	Common
}
public class ObjectsInfo{
	public int id;
	public string name;
	public string icon_name;
	public ObjectType type;
	public int hp;
	public int mp;
	public int price_sell;
	public int price_buy;

	public int attack;
	public int def;
	public int speed;
	public DressType dressType;
	public ApplicationType applicationType;
}