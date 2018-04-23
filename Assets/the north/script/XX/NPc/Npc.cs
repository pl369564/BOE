using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter () {
		cursorManager._instance.SetNpcTalk();
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		cursorManager._instance.SetNormal ();
	}
}
