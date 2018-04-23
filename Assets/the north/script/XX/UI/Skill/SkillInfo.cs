using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillInfo : MonoBehaviour {
	public TextAsset SkillInfoText;
	public static SkillInfo _instance;
	int id;
	private Dictionary<int,SkillsInfo>skillInfoDict=new Dictionary<int,SkillsInfo>();

	// Use this for initialization
	void Awake () {
		_instance = this;
		ReadInfo ();
	}
	void ReadInfo(){
		string text = SkillInfoText.text;
		string[] strArray=text.Split('\n');
		
		foreach (string str in strArray) {
						string[] proArray = str.Split (',');
						SkillsInfo info = new SkillsInfo ();
						info.id = int.Parse (proArray [0]);
						int id = int.Parse (proArray [0]);
						info.name = proArray [1];
						info.icon_name = proArray [2];
						info.des = proArray [3];
						string str_type = proArray [4];
						switch (str_type) {
						case"Passive":
								info.applyType = ApplyType.Passive;
								break;
						case"Buf":
								info.applyType = ApplyType.Buf;
								break;
						case"SingleTarget":
								info.applyType = ApplyType.SingleTarget;
								break;
						case"MultlTarget":
								info.applyType = ApplyType.MultlTarget;
								break;
						}
						str_type = proArray [5];
						switch (str_type) {
						case"Attack":
								info.applyproperty = ApplyProperty.Attack;
								break;
						case"AttackSpeed":
								info.applyproperty = ApplyProperty.AttackSpeed;
								break;
						case"Def":
								info.applyproperty = ApplyProperty.Def;
								break;
						case"Hp":
								info.applyproperty = ApplyProperty.Hp;
								break;
						case"Mp":
								info.applyproperty = ApplyProperty.Mp;
								break;
						}
						info.applyValue = int.Parse (proArray [6]);
						info.applyTime = int.Parse (proArray [7]);
						info.mp = int.Parse (proArray [8]);
						info.cd = int.Parse (proArray [9]);
						str_type = proArray [10];
						switch (str_type) {
						case"Swordman":
								info.applicableRole = ApplicableRole.Swordman;
								break;
						case"Magician":
								info.applicableRole = ApplicableRole.Magician;
								break;
						}
						info.level = int.Parse (proArray [11]);
						str_type = proArray [12];
						switch (str_type) {
						case"Enmy":
								info.releaseType = ReleaseType.Enmy;
								break;
						case"Position":
								info.releaseType = ReleaseType.Position;
								break;
						case"Self":
								info.releaseType = ReleaseType.Self;
								break;
						}
						info.distance = float.Parse (proArray [13]);
			info.efx_name=proArray[14];
			info.aniname=proArray[15];
			info.anitime=float.Parse(proArray[16]);
						skillInfoDict.Add (id, info);
				}
			
		}
	public SkillsInfo GetSkillsInfoById(int id){
		SkillsInfo info = null;
		skillInfoDict.TryGetValue (id, out info);
		return info;
	}
	}
public class SkillsInfo{//4001,致命一击,skill-02,伤害 250%,SingleTarget,Attack,250,0,6,1,Swordman,1,Enemy,1.5
	public int id;
	public string name;
	public string icon_name;
	public string des;
	public ApplyType applyType;
	public ApplyProperty applyproperty;
	public int applyValue;
	public int applyTime;
	public int mp;
	public int cd;
	public ApplicableRole applicableRole;
	public int level;
	public ReleaseType releaseType;
	public float distance;
	public string efx_name;
	public string aniname;
	public float anitime;
}
public enum ApplicableRole{//
	Swordman,
	Magician
}
public enum ApplyType{//作用类型
	Passive,
	Buf,
	SingleTarget,
	MultlTarget
}
public enum ApplyProperty{//作用属性
	Attack,
	Def,
	AttackSpeed,
	Hp,
	Mp
}
public enum ReleaseType{
	Self,
	Enmy,
	Position
}