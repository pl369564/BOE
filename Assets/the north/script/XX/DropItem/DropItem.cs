using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	public int id;
	void OnTriggerEnter(Collider col) {
		if (col.CompareTag (Tags.player)) {
			WinMessage.Instance.ShowWinMessage ("你获得了一件物品!");
			Inventory._instance.PickDropItem ();
			Destroy (this.gameObject);
		}
	}
}
