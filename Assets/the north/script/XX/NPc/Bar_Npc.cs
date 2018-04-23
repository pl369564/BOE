using UnityEngine;
using System.Collections;

public class Bar_Npc : Npc {
	public static bool isTasking=false;
	public static bool isDone = false;
    public NPCType npcType = NPCType.Normal;
	int id=1;
	int ii;
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
            switch (npcType)
            {
                case NPCType.Normal:
                    LabelControl.Instance.Talk(QuestTxt.BarNpcWords);
                    LabelControl.Instance.Hide ();
                    QuestUI.Instance.ShowQuestUI(1);
                    break;
                case NPCType.WeaponShoper:
                    LabelControl.Instance.Talk(QuestTxt.WeaponNpcWords);
                    QuestUI.Instance.ShowWeaponUI();
                    break;
                case NPCType.DurgShoper:
                    LabelControl.Instance.Talk(QuestTxt.DragNpcWords);
                    QuestUI.Instance.ShowDrugUI();
                    break;
                case NPCType.Talker:
                    break;
                default:
                    break;
            }
            
            //if (!isDone) {
            //	if (!isTasking) {
            //		QuestUI.Instance.ShowAcceptUI (QuestTxt.killWolfBaby, id);
            //	} else {
            //		LabelControl.Instance.Talk (QuestTxt.BarNpcWords);
            //		LabelControl.Instance.Hide ();
            //	}
            //} else {
            //	questComplete ();
            //}
        }
	}
	void questComplete(){
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
			LabelControl.Instance.Talk (StoryTxt.C1S1P7);
			break;
		case 1:
			LabelControl.Instance.Talk (StoryTxt.C1S1P8);
			if (GameIO._instance == null) {
				GameObject.FindWithTag (Tags.player).GetComponent<PlayerStatus> ().GetCoin (1000);
			} else {
				GameIO._instance.PS.GetCoin (1000);
				GameIO._instance.PS.GetExp (100);
			}
			break;
		case 2:
			LabelControl.Instance.Talk (StoryTxt.C1S1P9);
			break;
		case 3:
			LabelControl.Instance.Talk (StoryTxt.C1S1P10);
			LabelControl.Instance.Hide ();
			break;
		}
		ii++;
	}

}
public enum NPCType
{
    Normal,
    WeaponShoper,
    DurgShoper,
    Talker
}

