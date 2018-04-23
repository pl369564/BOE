using UnityEngine;
using System.Collections;

public class HeadStatusUI : MonoBehaviour {
	public static HeadStatusUI _instance;
	private PlayerStatus ps;

	private UILabel name;
	private UISlider hp;
	private UISlider mp;
	private UISlider exp;
	private UILabel hpLabel;
	private UILabel mpLabel;
	private UILabel expLabel;

	void Awake(){
		_instance = this;
		name = this.transform.Find ("name").GetComponent<UILabel> ();
		hp= this.transform.Find ("HPControlBar").GetComponent<UISlider>();
		mp = this.transform.Find ("MPControlBar").GetComponent<UISlider> ();
		exp = this.transform.Find ("EXPControlBar").GetComponent<UISlider> ();
		hpLabel = this.transform.Find ("HPControlBar/Thumb/Label").GetComponent<UILabel> ();
		mpLabel= this.transform.Find ("MPControlBar/Thumb/Label").GetComponent<UILabel> ();
		expLabel= this.transform.Find ("EXPControlBar/Thumb/Label").GetComponent<UILabel> ();
	}
	void Start(){
		ps = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
		OnUpdateShow ();

	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			int exp=100;
			ps.GetExp(exp);
		}
	}
	public void OnUpdateShow(){
		name.text = ps.level+"";
		hp.value = ps.hp_remain / ps.hp;
		mp.value = ps.mp_remain / ps.mp;
		exp.value = ps.exp / ps.maxExp;
		hpLabel.text =ps.hp_remain+"/"+ps.hp;
		mpLabel.text = ps.mp_remain+"/"+ps.mp;
		expLabel.text = ps.exp+"/"+ps.maxExp;
	}
}
