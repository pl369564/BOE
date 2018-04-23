using UnityEngine;
using System.Collections;


public class EIDrag : UIDragDropItem {
	private EiGrid parent;
	public GameObject inventoryItem;
	private Ei ei;
	void Awake(){
		parent = this.GetComponentInParent<EiGrid> ();
		ei = this.GetComponent<Ei> ();
	}
	protected override void OnDragDropRelease (GameObject surface)
	{
		base.OnDragDropRelease (surface);
		if (surface != null) {
			if(surface.tag==Tags.item_grid){
				InventoryItemgrid grid=surface.transform.GetComponent<InventoryItemgrid>();
				if (grid != null) {
					GameObject itemGo = NGUITools.AddChild (grid.gameObject, inventoryItem);
					itemGo.transform.localPosition = Vector3.zero;
					itemGo.GetComponentInParent<UISprite> ().depth = 4;
					grid.SetId (ei.id,grid.num);
					ei.id=0;
					EquipMentUI._instance.UpdateProperty();
					GameObject.Destroy(this.gameObject);
				} 
			}
			if(surface.tag==Tags.item){
				print("item!");
				InventoryItem item=surface.GetComponent<InventoryItem>();
				if(item.objectType==ObjectType.Equip){
					print("Equip!");
					if(item.dressType==ei.dressType){
						print ("DressType!");
				InventoryItemgrid grid=surface.transform.GetComponentInParent<InventoryItemgrid>();
				if (grid != null) {
					int count=1;
					int oldId=ei.id;
					ei.SetId(grid.id);
					grid.SetId (oldId,count);
							EquipMentUI._instance.UpdateProperty();
						}
					}
					}
			}
			}
			ResetPosition();
		}
	public void ResetPosition(){
		this.transform.localPosition = Vector3.zero;
	}
}
