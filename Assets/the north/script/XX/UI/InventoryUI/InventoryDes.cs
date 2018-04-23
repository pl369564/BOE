using UnityEngine;
using System.Collections;

public class InventoryDes : MonoBehaviour {
	public static InventoryDes _instance;
	private UILabel label;

	// Use this for initialization
	void Awake () {
		_instance = this;
		label = this.GetComponentInChildren<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Show(int id){
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		string des = "";
		switch (info.type) {
				case ObjectType.Drug:
						des = GetDrugDes (info);
						break;
				case ObjectType.Equip:
						des = GeteEquipDes (info);
						break;
				}
		label.text = des;
	}
	public void Clear(){
		label.text = "";}
	string GetDrugDes(ObjectsInfo info){
		string str="";
		str+="名称:"+info.name+"\n";
		str+="+hp"+info.hp+"\n";
		str+="+mp"+info.mp+"\n";
		//str+= "出售价格：" + info.price_sell + "\n";
		return str;
	}
	string GeteEquipDes(ObjectsInfo info){
		string str="";
		str+="名称:"+info.name+"\n";
		switch (info.dressType) {
				case DressType.Accessory:
						str += "穿戴部位:首饰  ";
						break;
				case DressType.Armor:
						str += "穿戴部位:衣服  ";
						break;
				case DressType.Headgear:
						str += "穿戴部位:头部  ";
						break;
				case DressType.LeftHand:
						str += "穿戴部位:左手  ";
						break;
				case DressType.RightHand:
						str += "穿戴部位:右手  ";
						break;
				case DressType.Shoe:
						str += "穿戴部位:鞋  ";
						break;
				}
		switch (info.applicationType) {
				case ApplicationType.Common:
						str += "职业:通用\n";
						break;
				case ApplicationType.Magician:
						str += "职业:魔法师\n";
						break;
				case ApplicationType.Swordman:
						str += "职业:剑士\n";
						break;
				}
		str += "攻击:" + info.attack ;
		str += "防御:" + info.def;
		str += "速度:" + info.speed;
		//str+= "出售价格：" + info.price_sell;
		return str;
	}
}
