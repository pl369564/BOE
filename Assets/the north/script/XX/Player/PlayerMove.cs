using UnityEngine;
using System.Collections;
public enum PlayerState{
	Moving,
	Idle,
	Attack,
	Def,
	Death,
	Follow
}

public class PlayerMove : MonoBehaviour {
	public int speed=4;
	private PlayerDir dir;
	private CharacterController controller;
	public bool isMoving=false;
	private PlayerStatus ps;

	// Use this for initialization
	void Start () {
		dir = this.GetComponent<PlayerDir> ();
		controller = this.GetComponent<CharacterController> ();
		ps = this.GetComponent<PlayerStatus> ();
	}
    
    // Update is called once per frame
    void FixedUpdate() {
		if (ps.state == PlayerState.Death) {
			return;}
		if (EquipMentUI._instance != null) {
			speed = this.GetComponent<PlayerStatus> ().speed + EquipMentUI._instance.speed;
		} else {
			speed = this.GetComponent<PlayerStatus> ().speed;
		}
		speed = speed / 5;
		float distance = Vector3.Distance (dir.targetPosition, transform.position);
		if (distance > 0.1f&&ps.state!=PlayerState.Follow&&ps.state!=PlayerState.Attack) {
			isMoving=true;
						ps.state = PlayerState.Moving;
						controller.SimpleMove (transform.forward * speed);
		} else if(ps.state!=PlayerState.Follow&&ps.state!=PlayerState.Attack){
			isMoving=false;
			ps.state=PlayerState.Idle;}
	}
	public void SimpleMove(Vector3 targetPo){
		transform.LookAt (targetPo);
		controller.SimpleMove (transform.forward * speed);
	}
}
