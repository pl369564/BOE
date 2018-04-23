using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
	public static Status _instance;
	private TweenPosition tween;
	private bool isShowing=false;
	private PlayerStatus pStatus;

	private UILabel attack_num;
	private UILabel def_num;
	private UILabel speed_num;
	private UILabel pointR_num;

	// Use this for initialization
	void Start () {
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();
		pStatus = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();

		attack_num = transform.Find ("Attack_num").GetComponent<UILabel> ();
		def_num=transform.Find ("Def_num").GetComponent<UILabel> ();
		speed_num=transform.Find ("Speed_num").GetComponent<UILabel> ();
		pointR_num=transform.Find ("PointR_num").GetComponent<UILabel> ();
	}
	public void TransformState() {
		if (isShowing == false) {
			tween.PlayForward ();
			isShowing = true;
			UpdateShow();
				} else {
			tween.PlayReverse ();
			isShowing = false;
				}
	}
	public void UpdateShow(){
		int num=pStatus.attack + pStatus.attack_plus+EquipMentUI._instance.attack;
		attack_num.text = num.ToString();
		num=pStatus.def + pStatus.def_plus+EquipMentUI._instance.def;
		def_num.text = num.ToString();
		num=pStatus.speed + pStatus.speed_plus+EquipMentUI._instance.speed;
		speed_num.text = num.ToString();
		pointR_num.text = pStatus.point_remain.ToString();
	}
	public void OnAddAttackClick(){
		pStatus.AddAttack ();
		UpdateShow ();
	}
	public void OnAddDefClick(){
		pStatus.AddDef ();
		UpdateShow ();
	}
	public void OnAddSpeedClick(){
		pStatus.AddSpeed ();
		UpdateShow ();
	}
	public void OnBtnOKClick(){
		pStatus.SetStatus ();
		UpdateShow ();
	}
	public void OnBtnResetClick(){
		pStatus.ReSet ();
		UpdateShow ();
		}
	public void OnBtnCanclClick(){
		tween.PlayReverse ();
		isShowing = false;
	}
}
