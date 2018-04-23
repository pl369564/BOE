using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopUIItem : MonoBehaviour {
	[SerializeField]
	int id;
//	int Price{
//		get{if (price = 0) {
//				price=
//			}
//		
//		}
//	}
	[SerializeField]
	UILabel detail;
	[SerializeField]
	GameObject des;
	[SerializeField]
	int price;
	PlayerStatus ps;
	public void BuyThisItem(){
		if (ps == null)
			ps = GameObject.FindWithTag (Tags.player).GetComponent<PlayerStatus>();
		if (ps.isBuy (price)) {
            WinMessage.Instance.ShowWinMessage("购买成功!");
            Inventory._instance.GetId (id);
			ps.coin -= price;
		} else {
            WinMessage.Instance.ShowWinMessage("购买失败,金钱不足");
        }
	}
	void ShowDetail(string name,int price){
		des.SetActive (true);
		detail.text = name+"\n价格："+price;
	}
	public void HideDetail(){
		des.gameObject.SetActive (false);
	}
	void OnMouseOver(){
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		ShowDetail (info.name,info.price_buy);
	}
	void OnMouseOut(){
		HideDetail ();
	}
}
