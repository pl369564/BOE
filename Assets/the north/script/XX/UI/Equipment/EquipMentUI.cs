using UnityEngine;
using System.Collections;

public class EquipMentUI : MonoBehaviour {
	private TweenPosition tween;
	bool isShowing=false;
	public static EquipMentUI _instance;
	private PlayerStatus pStatus;
	private GameObject headgear;
	private GameObject accessory;
	private GameObject armor;
	private GameObject shoe;
	private GameObject leftHand;
	private GameObject rightHand;
	public int oldId;
	public bool isExchange=false;
	public GameObject EquipItem;
	public int attack;
	public int def;
	public int speed;

	void Awake(){
		tween = this.GetComponent<TweenPosition> ();
	}
	void Start(){
		_instance=this;
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
		headgear = transform.Find ("Headgear").gameObject;
		accessory= transform.Find ("Accessory").gameObject;
		armor= transform.Find ("Armor").gameObject;
		shoe= transform.Find ("Shoe").gameObject;
		leftHand = transform.Find ("LeftHand").gameObject;
		rightHand = transform.Find ("RightHand").gameObject;
	}
	public void TransfromStates(){
		if (isShowing == false) {
						tween.PlayForward ();
						isShowing = true;
				} else {
			tween.PlayReverse();
			isShowing=false;}
	}
	public bool Dress(int id,GameObject gO){
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		if (info.type != ObjectType.Equip) {
						return false;
		} else if (info.applicationType != pStatus.apType&&info.applicationType!=ApplicationType.Common) {
						return false;
				} else {
			GameObject parent=null;
			switch(info.dressType){
			case DressType.Accessory:
				parent=accessory;
				break;
			case DressType.Armor:
				parent=armor;
				break;
			case DressType.Shoe:
				parent=shoe;
				break;
			case DressType.Headgear:
				parent=headgear;
				break;
			case DressType.LeftHand:
				parent=leftHand;
				break;
			case DressType.RightHand:
				parent=rightHand;
				break;
			}
			Ei ei=parent.GetComponentInChildren<Ei>();
			if(ei==null){
				GameObject itemGo=NGUITools.AddChild(parent,EquipItem);
				itemGo.transform.localPosition=Vector3.zero;
				itemGo.GetComponent<Ei>().SetInfo(info);
				gO.GetComponentInParent<InventoryItemgrid>().ClearInfo();
				GameObject.Destroy(gO);
			}else{
				oldId=ei.id;
				ei.SetInfo(info);
				isExchange=true;
			}
			return true;
	}
}
	public void UpdateProperty(){
		this.attack=0;
		this.def=0;
		this.speed=0;
		Ei headgearItem = headgear.GetComponentInChildren<Ei> ();
		PlusProperty (headgearItem);
		Ei accessoryItem = accessory.GetComponentInChildren<Ei> ();
		PlusProperty (accessoryItem);
		Ei armorItem = armor.GetComponentInChildren<Ei> ();
		PlusProperty (armorItem);
		Ei leftHandItem = leftHand.GetComponentInChildren<Ei> ();
		PlusProperty (leftHandItem);
		Ei rightHandItem = rightHand.GetComponentInChildren<Ei> ();
		PlusProperty (rightHandItem);
		Ei shoeItem = shoe.GetComponentInChildren<Ei> ();
		PlusProperty (shoeItem);
		Status._instance.UpdateShow ();
	}
	void PlusProperty(Ei ei){
		if (ei != null) {
						ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (ei.id);
			if(info==null){

			}else{
						this.attack += info.attack;
						this.def += info.def;
						this.speed += info.speed;
			}
				}
	}
}