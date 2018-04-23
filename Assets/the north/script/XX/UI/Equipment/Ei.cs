using UnityEngine;
using System.Collections;

public class Ei : MonoBehaviour {
	private UISprite sprite;
	bool isHoving=false;
	public DressType dressType;



	public int id;

	void Awake(){
		sprite = this.GetComponent<UISprite> ();
	}
	void Update(){
		if (isHoving == true) {
			if(Input.GetMouseButtonDown(1)){
				Inventory._instance.GetId(id);
				this.id=0;
				EquipMentUI._instance.UpdateProperty();
				GameObject.Destroy(this.gameObject);
			}	
		}
	}
	public void SetId(int id){
		ObjectsInfo info=ObjectInfo._instance.GetOjectInfoById(id);
		SetInfo (info);
		}
	public void SetInfo(ObjectsInfo info){
		this.id = info.id;
		sprite.spriteName = info.icon_name;
		dressType = info.dressType;
	}
	public void OnHover(bool ii){
		isHoving = ii;
	}
}
