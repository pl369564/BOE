using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	//Transform myTransform;
	CharacterController cc;
	Animator animator;
	public bool a=false;
	public bool w=false;
	public bool d=false;
	public bool s=false;
	public float speed=2f;
	int attack=30;

	// Use this for initialization
	void Awake() {
		cc=this.GetComponent<CharacterController>();
		animator=this.GetComponent<Animator>();
		//myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		SetAttack ();
		SetMove();
	}
	void SetAttack(){
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("0");
			if(attack>32){attack=30;}
			SetState(attack);
			attack++;
		}
		}
	void SetMove(){
		a=SetKeyDown (a,KeyCode.A);
		d=SetKeyDown (d,KeyCode.D);
		w=SetKeyDown (w,KeyCode.W);
		s=SetKeyDown (s,KeyCode.S);
		a=SetKeyUp (a,KeyCode.A);
		d=SetKeyUp (d,KeyCode.D);
		w=SetKeyUp (w,KeyCode.W);
		s=SetKeyUp (s,KeyCode.S);
		isWalk (s);
		isRun (a);
		isRun (d);
		isRun (w);
		move ();
		attack = 30;
		RollFace ();
	}
	void move(){
		if (s == true) {
			cc.SimpleMove (this.transform.forward*speed*-1f);
			if (a == true) {
				cc.SimpleMove (this.transform.right * speed*-1f);
			} else if (d == true) {
				cc.SimpleMove (this.transform.right * speed);
			}
				}else if (w == true) {
			cc.SimpleMove (this.transform.forward*speed*2f);
				}
		if (s == false) {
						if (a == true) {
								cc.SimpleMove (this.transform.forward * speed);
						} else if (d == true) {
								cc.SimpleMove (this.transform.forward * speed);
						}
				}
		}
	void RollFace(){
		if (a == true) {
			this.transform.rotation=Quaternion.Euler(0,-90,0);
		}
		if (d == true) {
			this.transform.rotation = Quaternion.Euler (0, 90, 0);
		}
		if (s == true) {
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
			return;
		}
		if (w == true) {
			this.transform.rotation=Quaternion.Euler(0,0,0);
			if(a==true){
				this.transform.rotation=Quaternion.Euler(0,-45,0);
				return;
			}else if(d==true){
				this.transform.rotation=Quaternion.Euler(0,45,0);
				return;
			}
			return;
		}
		}
	void isWalk(bool bo){
		if (bo == true) {
			SetState (20);
				} else {
			SetState(10);
				}
		}
	void isRun(bool bo){
		if (bo == true) {
			SetState (21);
				} else {
				}
	}
	void SetState(int i){
		animator.SetInteger ("state",i);
		}
	bool SetKeyDown(bool bo,KeyCode keycode){
		if (Input.GetKeyDown (keycode)) {
						return true;
				} else {
			return bo;
				}
		}
	bool SetKeyUp(bool bo,KeyCode keycode){
		if (Input.GetKeyUp (keycode)) {
						return false;
				} else {
						return bo;
				}
	}
}
