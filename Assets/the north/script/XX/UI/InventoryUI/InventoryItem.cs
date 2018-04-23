using UnityEngine;
using System.Collections;

public class InventoryItem : UIDragDropItem {
	private	UISprite sprite;
	public int id;
	bool isHoving;
	bool isExchange=false;
	public ObjectType objectType;
	public DressType dressType;
	PlayerStatus pStatus;

	void Awake(){
		sprite = this.GetComponent<UISprite>();
	}
	void Start(){
		base.Start ();
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
	}
	void Update(){
		if (isHoving == true) {
			if(Input.GetMouseButtonDown(1)){
				if(objectType==ObjectType.Equip){
				bool isDress=EquipMentUI._instance.Dress(id,this.gameObject);
				isExchange=EquipMentUI._instance.isExchange;
				if(isExchange==true){
					InventoryItemgrid grid=this.transform.parent.GetComponent<InventoryItemgrid>();
					int num=1;
					grid.SetId(EquipMentUI._instance.oldId,num);
					EquipMentUI._instance.isExchange=false;
				}
				if(isDress==false){
						print ("DressFalse");
				}else{EquipMentUI._instance.UpdateProperty();
				}
			}
				if(objectType==ObjectType.Drug||objectType==ObjectType.Mat){
					int hp=ObjectInfo._instance.GetOjectInfoById(id).hp;
					int mp=ObjectInfo._instance.GetOjectInfoById(id).mp;
					pStatus.UseDrug(hp,mp);
					HeadStatusUI._instance.OnUpdateShow();
					int num=1;
					Inventory._instance.MinusItem(id,num);
				}
			}
		}
	}
	protected override void OnDragDropRelease (GameObject surface)
	{
		base.OnDragDropRelease (surface);
		if (surface != null) {
			if(surface.tag==Tags.item_grid){
				if(surface==this.transform.parent){

				}else{
					InventoryItemgrid oldParent=this.transform.parent.GetComponent<InventoryItemgrid>();
					this.transform.parent=surface.transform;
					InventoryItemgrid newParent=surface.transform.GetComponent<InventoryItemgrid>();
					newParent.SetId(oldParent.id,oldParent.num);
					oldParent.ClearInfo();
				}
			}else if(surface.tag==Tags.item){
				InventoryItemgrid grid1=this.transform.parent.GetComponent<InventoryItemgrid>();
				InventoryItemgrid grid2=surface.GetComponentInParent<InventoryItemgrid>();
				int id=grid1.id;int num=grid1.num;
				grid1.SetId(grid2.id,grid2.num);
				grid2.SetId(id,num);

			}
			if(surface.tag==Tags.shortCutItem&&objectType==ObjectType.Drug){
				ShortCutType type=ShortCutType.Drug;
				surface.transform.Find("icon").GetComponent<ShortCutItem>().SetItem(id,type);
			}
				}
		ResetPosition ();
	}
	public void ResetPosition(){
		this.transform.localPosition = Vector3.zero;
	}
	public void SetId(int id){
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		sprite.spriteName = info.icon_name;
	}
	public void SetIconName(int id,string icon_name){
		sprite.spriteName =icon_name;
		this.id = id;
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		objectType = info.type;
		if (info.type == ObjectType.Equip) {
			dressType=info.dressType;
		}
	}
	public void OnHoverOver(){
		InventoryDes._instance.Show (id);
		isHoving = true;
	}
	public void OnHoverOut(){
		InventoryDes._instance.Clear ();
		isHoving = false;
	}
}
