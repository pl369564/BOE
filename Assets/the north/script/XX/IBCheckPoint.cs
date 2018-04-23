using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBCheckPoint : GameBase {
	[SerializeField]
	Transform door;
	Transform player;
	float yoffset;
	float repeatRate=0.1f;
	float time;
	float temp;

	Vector3 pos;

	bool isOpen=false;
	bool isTalked=false;
	bool isTalking;
	public static bool isDone;
	public static bool isTaked;

	int id=2;
	int ii=0;
	void Start(){
		pos = door.position;
		yoffset = 3f/ (3f/Time.fixedDeltaTime);
		player = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<Transform>();
		InvokeRepeating("Check",repeatRate,repeatRate);
	}
	void Check(){
		temp = Vector3.Distance (player.position,myTransform.position);
		if (temp <= 2f) {
			if (!isTalking) {
				isTalking = true;
				if (!isTaked) {
					if (!isTalked) {
						Invoke ("Talk", 0);
						isTalked = true;
					}
				} else{
					if (isDone) {
						Invoke ("Talk", 0);
						CancelInvoke ("Check");
					} else {
						LabelControl.Instance.Talk (QuestTxt.DragNpcWords);
						LabelControl.Instance.Hide ();
					}
				}
			}
		} else if(temp>=10f){
			isTalking = false;
		}
	}
	void Talk(){
		float time = 0.5f;
		float t = 2.5f;
		int j = 3;
		for (int i = 0; i < j; i++) {
			Invoke ("talk",time);
			time += t;
		}
	}
	void talk(){
		switch (ii) {
		case 0:
			LabelControl.Instance.Talk (StoryTxt.C1S2P1);
			break;
		case 1:
			LabelControl.Instance.Talk (StoryTxt.C1S2P2);
			break;
		case 2:
			LabelControl.Instance.Talk (StoryTxt.C1S2P3);
			LabelControl.Instance.Hide ();
			QuestUI.Instance.ShowAcceptUI(QuestTxt.killWolfNormal,id);
			break;
		case 3:
			LabelControl.Instance.Talk (StoryTxt.C1S2P4);
			break;
		case 4:
			LabelControl.Instance.Talk (StoryTxt.C1S2P5);
			break;
		case 5:
			LabelControl.Instance.Talk (StoryTxt.C1S2P6);
			LabelControl.Instance.Hide ();
			Inventory._instance.GetId (1001,2);
			if(GameIO._instance!=null)
			GameIO._instance.PS.GetExp(200);
			InvokeRepeating("OpenTheGate",repeatRate,repeatRate);
			break;
		}
		ii++;
	}
	void OpenTheGate(){
		time += Time.fixedDeltaTime;
		if (time <= 3f) {
			pos.y -= yoffset;
			door.position = pos;
		} else {
			CancelInvoke ("OpenTheGate");
		}
	}
}
