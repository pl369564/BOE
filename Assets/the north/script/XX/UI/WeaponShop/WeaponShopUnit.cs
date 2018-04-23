using UnityEngine;
using System.Collections;

public class WeaponShopUnit : MonoBehaviour {

	private UISprite itemIcon;
	private UILabel simplePre;
	private UILabel presentation;
	public int id;
	void Awake(){
		itemIcon = transform.Find ("Item_icon").GetComponent<UISprite> ();
		simplePre = transform.Find ("simple_pre").GetComponent<UILabel> ();
		presentation = transform.Find ("presentation").GetComponent<UILabel> ();
	}
	public void SetById(int id){
		this.id = id;
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		itemIcon.spriteName = info.icon_name;
		simplePre.text="名称;"+info.name+" 售价:"+info.price_buy;
		string str="";
		if (info.attack > 0) {
			str+="攻击力:"+info.attack+" ";
		}
		if (info.def > 0) {
			str+="防御力:"+info.def+" ";	
		}
		if (info.speed > 0) {
			str+="速度:"+info.speed+" ";	
		}
		presentation.text = str;
	}
	public void OnBtnBuy(){
//		WeaponShopUI._instance.OnBtnBuy (this.id);
	}
}
