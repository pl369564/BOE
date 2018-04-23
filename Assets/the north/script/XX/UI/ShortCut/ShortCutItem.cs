using UnityEngine;
using System.Collections;

public enum ShortCutType{
	Skill,
	Drug,
	Equip,
	None
}
public class ShortCutItem : MonoBehaviour {

	public KeyCode keyCode;
	private UISprite icon;
	int id;
	SkillsInfo skillsInfo;
	ObjectsInfo objectsInfo;
	ShortCutType type=ShortCutType.None;
	PlayerStatus pStatus;

	void Awake(){
		icon = this.transform.GetComponent<UISprite> ();
		this.gameObject.SetActive (false);
	}
	void Start(){
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
	}
	void Update(){
		if (Input.GetKeyDown (keyCode)&&type!=ShortCutType.None) {
			if(type==ShortCutType.Drug){
				int hp= objectsInfo.hp;
				int mp=objectsInfo.mp;
				pStatus.UseDrug(hp,mp);
				HeadStatusUI._instance.OnUpdateShow();
				int num=1;
				if(Inventory._instance.MinusItem(id,num)){
					this.gameObject.SetActive(false);
				}
			}
			if(type==ShortCutType.Skill){
				if(pStatus.dealMp(skillsInfo.mp)){
				switch (skillsInfo.applyType){
				case ApplyType.Passive:
					UsePassive();
					break;
				case ApplyType.Buf:
					UseBuf();
					break;
				case ApplyType.SingleTarget:
					UseSingleTarget ();
					break;
				case ApplyType.MultlTarget:
					UseMultlTarget ();
					break;
				}
				}
			}
		}
	}
	public void SetItem(int id,ShortCutType type){
		this.gameObject.SetActive (true);
		this.id = id;
		this.type = type;
		if (type == ShortCutType.Skill) {
			skillsInfo = SkillInfo._instance.GetSkillsInfoById (id);
			icon.spriteName = skillsInfo.icon_name;
			}
		if (type == ShortCutType.Drug) {
			objectsInfo=ObjectInfo._instance.GetOjectInfoById(id);
			icon.spriteName=objectsInfo.icon_name;
		}

	}
	void UsePassive(){
		int value=skillsInfo.applyValue;
		switch (skillsInfo.applyproperty) {
		case ApplyProperty.Hp:
			pStatus.UseDrug(value,0);
			break;
		case ApplyProperty.Mp:
			pStatus.UseDrug (0,value);
			break;
		case ApplyProperty.Attack:
			pStatus.attack_extra=value;
			break;
		case ApplyProperty.Def:
			pStatus.def_extra=value;
			break;
		case ApplyProperty.AttackSpeed:
			pStatus.speed_extra=value;
			break;
				}
	}
	void UseBuf(){

	}
	void UseSingleTarget(){

	}
	void UseMultlTarget(){

	}
}

