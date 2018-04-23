using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// Use this for initialization
	void OnMouseEnter () {
		cursorManager._instance.SetEnemy ();
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		cursorManager._instance.SetNormal ();
	}
}
