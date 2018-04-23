using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemPool : MonoBehaviour {
	[SerializeField]
	GameObject dropItem;
	public static DropItemPool Instance;
	Stack<GameObject> dropStack=new Stack<GameObject>();
	void Start(){
		Instance = this;
		for (int i = 0; i < 5; i++) {
			GameObject go=Instantiate (dropItem);
			Recycle (go);
		}
	}
	public GameObject GetADropItem(Vector3 pos,int id){
		GameObject go;
		if (dropStack.Count > 0) {
			go = dropStack.Pop();
			go.SetActive (true);
		} else {
			go = Instantiate (dropItem);
		}
		pos.y += 0.2f;
		go.transform.position = pos;
		go.GetComponent<DropItem> ().id = id;
		return go;
	}
	public void Recycle(GameObject boj){
		dropStack.Push (boj);
		boj.SetActive (false);
	}
}