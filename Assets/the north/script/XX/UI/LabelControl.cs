using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelControl : Singletem<LabelControl> {
	[SerializeField]
	UILabel lb;
	[SerializeField]
	TweenAlpha ta;
	bool isTalking;
	string txt;
	public void Talk(string txt){
		if (isTalking) {
			return;
		} else {
			isTalking = true;
			ta.PlayForward ();
			this.txt = txt;
			Invoke ("Setlb",0.5f);
		}
	}
	void Setlb(){
		lb.text = txt;
		isTalking = false;
		ta.PlayReverse ();
	}
	public void Hide(){
		Invoke ("hide",2f);
	}
	void hide(){
		ta.PlayForward ();
	}
}
