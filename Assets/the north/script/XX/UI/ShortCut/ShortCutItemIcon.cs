using UnityEngine;
using System.Collections;

public class ShortCutItemIcon : UIDragDropItem {
	private int skillid;
	protected override void OnDragDropStart(){
		base.OnDragDropStart ();
		skillid = transform.parent.GetComponent<SkillItem> ().id;
		transform.parent = transform.root;
		this.GetComponent<UISprite> ().depth=40;
	}
	protected override void OnDragDropRelease(GameObject surface){
		base.OnDragDropRelease (surface);
		if(surface!=null&&surface.tag==Tags.shortCutItem){
			ShortCutType type=ShortCutType.Skill;
			surface.transform.Find("icon").GetComponent<ShortCutItem>().SetItem(skillid,type);
		}
	}
}