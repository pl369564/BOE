using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {
	public GameObject[] efxArray;
	private Dictionary<string,GameObject> efxDict = new Dictionary<string,GameObject> ();

	private PlayerStatus ps;
	private Transform target;
	private PlayerMove pm;
	private PlayerDir dir;
	private PlayerAnimationS pa;
	void Awake(){
		ps = this.GetComponent<PlayerStatus> ();
		pm = this.GetComponent<PlayerMove> ();
		dir=this.GetComponent<PlayerDir>();
		pa = this.GetComponent<PlayerAnimationS> ();
	}
	void Update(){
		if (ps.state == PlayerState.Death) {
			return;}
		if(dir.targetPosition!=Vector3.zero){
		if (ps.state == PlayerState.Follow||ps.state==PlayerState.Attack) {
			float distance=Vector3.Distance(transform.position,dir.targetPosition);
			if(distance>ps.attackRange&&pa.attacking==false){
				pm.SimpleMove(dir.targetPosition);
				ps.state=PlayerState.Follow;
			}else{
				Attack (dir.targetPosition);
			}
		}
	}
	}
	public void Attack(Vector3 target){
		transform.LookAt (target);
		ps.state = PlayerState.Attack;
	}
}
