using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	private PlayerStatus ps;
	private float attackTime;
	private float attackTimer;
	// Use this for initialization
	void Start () {
		ps = this.GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void LateUpdate() {
		if (ps.state == PlayerState.Moving) {
			PlayAnim ("Sword-Run");
		}  
		if (ps.state == PlayerState.Idle) {
			PlayAnim ("Sword-Idle");
		}
		if (ps.state == PlayerState.Attack) {
			attackTime+=Time.deltaTime;
			if(attackTime<attackTimer){
				int random=Random.Range(0,2);
				if(random==0){
					PlayAnim("Sword-Attack1");
				}else{
					PlayAnim("Sword-Attack2");
				}
			}else{
				attackTime=0;
			}
		}
	}
	void PlayAnim(string animName){
		GetComponent<Animation>().CrossFade (animName);
	}
}
