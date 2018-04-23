using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FounctionKeyListener : MonoBehaviour {

	FounctionBar fb;
	// Use this for initialization
	void Start () {
		fb = GameObject.Find ("UIRoot/FounctionBar").GetComponent<FounctionBar> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            fb.CloseOnClick();
        }
        if (Input.GetKeyDown (KeyCode.E)) {
			fb.OnEquipButtonClick ();
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			fb.OnBagButtonClick ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			fb.OnSkillButtonClick ();
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			fb.OnStatusButtonClick ();
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			fb.OnHelpClick ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			QuestUI.Instance.TransformState ();
		}
	}
}
