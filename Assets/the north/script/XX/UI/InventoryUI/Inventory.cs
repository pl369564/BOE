 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public static Inventory _instance;
	private TweenPosition tween;
	public List<InventoryItemgrid> itemGridList=new List<InventoryItemgrid>();
	//private int coinCount=0;
	public UILabel coinNumberLabel;
	public GameObject inventoryItem;
	private PlayerStatus pStatus;
	private bool isShow=false;

	// Use this for initialization
	void Awake () {
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();
	}
	void Start(){
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();}
	void Update(){
		if (Input.GetKeyDown (KeyCode.X)) {
			int id=Random.Range(2001,2019);
			GetId (id);
	    }
	}
	public void PickDropItem(){
		int id = 3001;
		GetId (id);
	}
	public void GetId(int id,int count=1){
		InventoryItemgrid grid = null;
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		foreach (InventoryItemgrid temp in itemGridList) {
			if (temp.id == id) {
				grid = temp;
				break;
			}
		}
		if (grid != null && info.type != ObjectType.Equip) {
			grid.PlusNumber (count);
		} else {
			foreach (InventoryItemgrid temp in itemGridList) {
				if (temp.id == 0) {
					grid = temp;
					break;
				} else {
					grid = null;
				}
			}
			if (grid != null) {
				GameObject itemGo = NGUITools.AddChild (grid.gameObject, inventoryItem);
				itemGo.transform.localPosition = Vector3.zero;
				itemGo.GetComponentInParent<UISprite> ().depth = 4;
				grid.SetId (id, count);
			}
		}
	}

	void Show () {
		tween.PlayForward();
		isShow = true;
	}
	void hide(){
		tween.PlayReverse();
		isShow = false;
	}
	public void TransformState(){
		if (isShow == false) {
						Show ();
				} else {
			hide ();}
		transformCoin ();
	}
	public void transformCoin(){
		coinNumberLabel.text = pStatus.coin.ToString ();
	}
	public bool MinusItem(int id,int num){
		bool ii=false;
		foreach (InventoryItemgrid temp in itemGridList) {
						if (temp.id == id) {
								ii = temp.MinusNumber (num);
								break;
						}
				}
		return ii;
	}
}
