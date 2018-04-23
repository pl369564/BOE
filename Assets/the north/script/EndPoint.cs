using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : Singletem<EndPoint> {
	[SerializeField]
	TweenAlpha ta;
	[SerializeField]
	GameObject go;
	[SerializeField]
	BoxCollider bc;

	int ii;
	void OnTriggerEnter(Collider col){
		if (col.CompareTag (Tags.player)) {
			ta.gameObject.SetActive (true);
			ta.enabled = true;
		}
	}
	public void jkl(){
		go.SetActive (true);	
	} 
	public void killboss(){
		float time = 0.5f;
		float t = 2.5f;
		int j = 4;
		for (int i = 0; i < j; i++) {
			Invoke ("talk",time);
			time += t;
		}
	}
	void talk(){
		switch (ii) {
		case 0:
			LabelControl.Instance.Talk (StoryTxt.C1S3P1);
			break;
		case 1:
			LabelControl.Instance.Talk (StoryTxt.C1S3P2);
			break;
		case 2:
			LabelControl.Instance.Talk (StoryTxt.C1S3P3);
			break;
		case 3:
			LabelControl.Instance.Talk (StoryTxt.C1S3P4);
			LabelControl.Instance.Hide ();
			bc.isTrigger=true;
			break;
		}
		ii++;
	}
}
