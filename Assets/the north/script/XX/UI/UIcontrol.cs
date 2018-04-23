using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour {
	public GameObject[] uiList;
	FounctionKeyListener fkl;
	public static UIcontrol _instance;
	void Awake(){
		_instance = this;
		HideUI ();
		OpeningAnmation.onOpEnded += ShowUI;
	}
	void HideUI(){
		int l = uiList.Length;
		for (int i = 0; i < l; i++) {
			uiList [i].SetActive (false);
		}
	}
	void ShowUI(){
		if(fkl==null)
		fkl=this.gameObject.AddComponent<FounctionKeyListener> ();
		int l = uiList.Length;
		for (int i = 0; i < l; i++) {
			uiList [i].SetActive (true);
		}
	}
}
