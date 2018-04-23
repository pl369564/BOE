using UnityEngine;
using System.Collections;

public class InventoryItemgrid : MonoBehaviour {

	public int id=0;
	private ObjectsInfo info=null;
	public int num=0;
	public InventoryItem item;

	private UILabel numLabel;
	// Use this for initialization
	void Awake () {
		numLabel = this.GetComponentInChildren<UILabel> ();
	}
	
	public void SetId(int id,int num){
		this.id = id;
		info = ObjectInfo._instance.GetOjectInfoById (id);
		item = this.GetComponentInChildren<InventoryItem> ();
						item.SetIconName (info.id, info.icon_name);
						numLabel.enabled = true;
						if (info.type != ObjectType.Equip) {
								this.num += num;
								numLabel.text = this.num.ToString ();
						}
	}
	public void PlusNumber(int num){
		this.num += num;
		numLabel.text = this.num.ToString ();
	}
	public void ClearInfo(){
		id=0;
		info=null;
		num=0;
		numLabel.enabled=false;	
	}
	public bool MinusNumber(int num){
		this.num -= num;
		if (this.num <= 0) {
			Destroy(item.gameObject);
			numLabel.enabled = false;
			id=0;
			return true;
		} else {
			numLabel.text = this.num.ToString ();
			return false;
		}
	}
}
