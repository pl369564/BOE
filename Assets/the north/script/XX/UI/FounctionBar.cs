using UnityEngine;
using System.Collections;

public class FounctionBar : MonoBehaviour {

	[SerializeField]
	GameObject help;
	public void OnEquipButtonClick(){
		EquipMentUI._instance.TransfromStates();
	}
	public void OnSkillButtonClick(){
		SkillUI._instance.TransformState ();
	}
	public void OnBagButtonClick(){
		Inventory._instance.TransformState ();
	}
	public void OnStatusButtonClick(){
		Status._instance.TransformState ();
	}
	public void OnSettingButtonClick(){
		
	}
	public void OnHelpClick(){
		if (help.activeInHierarchy) {
			help.SetActive (false);
		} else {
			help.SetActive (true);
		}
	}
    public void CloseOnClick() {
        if (help.activeInHierarchy) {
            help.SetActive(false);
        }
    }
}
