using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour {
	public static SkillUI _instance;
	private TweenPosition tween;
	bool isShowing;
//	public int[] magcianSkillList;
//	public int[] swordmanSkillList;
	PlayerStatus pStatus;
//	public GameObject skillItem;
//	public UIGrid grid;
	public GameObject des;
	public UILabel detail;
	Vector3 posSkill1=new Vector3(175, 54, 0);
	Vector3 posSkill2=new Vector3(175, 14, 0);
	Vector3 posSkill3=new Vector3(175, -34, 0);
	Vector3 posSkill4=new Vector3(175, -75, 0);
	[SerializeField]
	GameObject add1;
	[SerializeField]
	GameObject add2;
	[SerializeField]
	GameObject add3;
	[SerializeField]
	GameObject add4;

	// Use this for initialization
	void Awake () {
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();
	}
	void Start(){
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
//		int[] idList=null;
//		if (pStatus.apType == ApplicationType.Swordman) {
//			idList=swordmanSkillList;
//				} else if (pStatus.apType == ApplicationType.Magician) {
//			idList=magcianSkillList;
//		}
//		foreach (int id in idList) {
//			GameObject itemGo=NGUITools.AddChild(grid.gameObject,skillItem);
//			grid.AddChild(itemGo.transform);
//			itemGo.GetComponent<SkillItem>().SetIdAndUpdateShow(id);
//		}
	}
	public void TransformState(){
		if (isShowing == false) {
			tween.PlayForward();
			isShowing=true;
				} else {
			tween.PlayReverse();
			isShowing=false;
				}
	}
	public void GetSkill1(){
		PlayerStatus.SetDamageCoe (1.2f);
		HideAddItem (add1);
		HideDetail ();
	}
	public void GetSkill2(){
		pStatus.isGetSkill2 = true;
		HideAddItem (add2);
		HideDetail ();
	}
	public void GetSkill3(){
		pStatus.attackSpeed *= 0.75f;
		PlayerAnimationS.SetAttackTimer(pStatus.attackSpeed);
		HideAddItem (add3);
		HideDetail ();
	}
	public void GetSkill4(){
		pStatus.isGetSkill4 = true;
		HideAddItem (add4);
		HideDetail ();
	}
	public void ShowSkill1(){
		ShowDetail ("5",posSkill1);
	}
	public void ShowSkill2(){
		ShowDetail ("7",posSkill2);
	}
	public void ShowSkill3(){
		ShowDetail ("10",posSkill3);
	}
	public void ShowSkill4(){
		ShowDetail ("12",posSkill4);
	}

	void ShowDetail(string text,Vector3 pos){
		des.SetActive (true);
		detail.text = text;
		des.transform.localPosition = pos;
	}
	public void HideDetail(){
		des.gameObject.SetActive (false);
	}
	void HideAddItem(GameObject obj){
		obj.SetActive (false);
	}
}
