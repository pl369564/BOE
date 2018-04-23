using UnityEngine;
using System.Collections;

public class SkillItem : MonoBehaviour {
	private UISprite icon_name_sprite;
	private UILabel des_label;
	private UILabel name_label;
	private UILabel mp_label;
	private UILabel applytype_label;
	public int id;
	void InitProperty(){
		icon_name_sprite = transform.Find ("icon_name").GetComponent<UISprite> ();
		des_label = transform.Find ("property/des").GetComponent<UILabel> ();
		name_label=transform.Find ("property/name").GetComponent<UILabel> ();
		mp_label=transform.Find ("property/mp").GetComponent<UILabel> ();
		applytype_label=transform.Find ("property/applyType/buff").GetComponent<UILabel> ();
	}
	public void SetIdAndUpdateShow(int id){
		InitProperty ();
		this.id = id;
		SkillsInfo info= SkillInfo._instance.GetSkillsInfoById (id);
		icon_name_sprite.spriteName = info.icon_name;
		name_label.text = info.name;
		switch (info.applyType) {
		case ApplyType.Passive:
			applytype_label.text="增益";
			break;
		case ApplyType.Buf:
			applytype_label.text="BUFF";
			break;
		case ApplyType.SingleTarget:
			applytype_label.text="单体";
			break;
		case ApplyType.MultlTarget:
			applytype_label.text="群体";
			break;
		}
		des_label.text=info.des;
		mp_label.text = info.mp.ToString ();
	}
}
