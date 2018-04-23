using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningAnmation : MonoBehaviour {
	[SerializeField]
	Transform Mc_OPo;
	[SerializeField]
	FollowPlayer fp;
	[SerializeField]
	GameObject firstC;
	Quaternion qua;
	Transform myTransF;
	float rotateTime=1f;

	bool isRotated;
	bool isMoved;

	int i;

	public delegate void OpEnd();
	public static event OpEnd onOpEnded;
	public void StartOP () {
		myTransF = this.transform;
		Invoke ("Talk",1f);
		Invoke ("Talk",4f);
		Invoke ("Talk",7f);
		Invoke ("Talk",10f);
		Invoke ("Talk",13f);
		Invoke ("Talk",16f);
		InvokeRepeating ("MoveToMcOP",2f,Time.fixedDeltaTime);
		onOpEnded += hide;
	}
	void MoveToMcOP(){
		if (Vector3.Dot (myTransF.forward, Mc_OPo.forward)<CommonNumber.sameDot) {
			qua = Quaternion.LookRotation (Mc_OPo.forward, myTransF.up);
			myTransF.rotation = Quaternion.Lerp (myTransF.rotation, qua, rotateTime * Time.deltaTime);
		} else {
			isRotated = true;
		}
		if (Vector3.Distance (myTransF.position, Mc_OPo.position) > 0.1f) {
			myTransF.position = Vector3.Lerp (myTransF.position, Mc_OPo.position, rotateTime * Time.deltaTime);
		} else {
			isMoved = true;
		}
		if (isRotated && isMoved) {
			fp.enabled = true;
			CancelInvoke ("MoveToMcOP");
		}
	}
	void hide(){
		LabelControl.Instance.Hide ();
	}
	void Talk(){
		switch (i) {
		case 0:
			LabelControl.Instance.Talk (StoryTxt.C1S1P1);
			break;
		case 1:
			LabelControl.Instance.Talk (StoryTxt.C1S1P2);
			break;
		case 2:
			LabelControl.Instance.Talk (StoryTxt.C1S1P3);
			break;
		case 3:
			LabelControl.Instance.Talk (StoryTxt.C1S1P4);
			//firstC.SetActive (true);
			break;
		case 4:
			LabelControl.Instance.Talk (StoryTxt.C1S1P5);
			//firstC.SetActive (false);
			break;
		case 5:
			LabelControl.Instance.Talk (StoryTxt.C1S1P6);
			//if(GameIO._instance!=null)
			//GameIO._instance.PlayerBgm (0,2f);
			onOpEnded ();
			break;
		}
		i++;
	}
}
