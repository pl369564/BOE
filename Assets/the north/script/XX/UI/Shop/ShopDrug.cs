using UnityEngine;
using System.Collections;

public class ShopDrug : MonoBehaviour {
	private TweenPosition tween;
	int count=1;
	private PlayerStatus status;
	public Inventory inventory;
	public UILabel buy1001;
	public UILabel buy1002;
	public UILabel buy1003;

	void Awake(){
		tween = this.GetComponent<TweenPosition> ();
	}
	void Start(){
		status = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus>();
	}
	public void OnBtnBuy1001(){
		count = int.Parse (buy1001.text);
		Buy (1001,count);
	}
	public void OnBtnBuy1002(){
		count = int.Parse (buy1002.text);
		Buy (1002,count);
	}
	public void OnBtnBuy1003(){
		count = int.Parse (buy1003.text);
		Buy (1003,count);
	}
	void Buy(int id,int count){
		ObjectsInfo info=ObjectInfo._instance.GetOjectInfoById (id);
		int price_total = count * info.price_buy;
		bool isBuy=status.isBuy (price_total);
		if (isBuy == true) {
            WinMessage.Instance.ShowWinMessage("购买成功!");
			status.Pay (price_total);
			inventory.GetId(id,count);
			inventory.transformCoin ();
		} else {
            WinMessage.Instance.ShowWinMessage("购买失败,金钱不足");
        }
		}
	public void OnBtnClose(){
		tween.PlayReverse ();
		buy1001.text="1";
		buy1002.text="1";
		buy1003.text="1";
	}
}
