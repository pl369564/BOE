using UnityEngine;
using System.Collections;

public class InventoryItemType : MonoBehaviour {
	public ObjectType objectType;
	public DressType dressType;
	public void SetItemType(int id){
		ObjectsInfo info = ObjectInfo._instance.GetOjectInfoById (id);
		objectType = info.type;
		dressType = info.dressType;
	}


}
