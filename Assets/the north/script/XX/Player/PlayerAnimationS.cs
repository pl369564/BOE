
using UnityEngine;
using System.Collections;

public class PlayerAnimationS : MonoBehaviour {
	public string anima_Death="Sword-Death";
	public string anima_Run="Sword-Run";
	public string anima_Idle="Sword-Idle";
	public string anima_Attack1="Sword-Attack1";
	public string anima_Attack2="Sword-Attack2";
	private PlayerStatus ps;
	public float attackTime;
	public bool isHalfHP;
	private static float attackTimer;
	public static void SetAttackTimer(float f){
		attackTimer = f;
	}
	int random=1;
	public bool attacking=false;
	private PlayerDir dir;
	private bool dealDamage=true;
	// Use this for initialization
	void Start () {
		ps = this.GetComponent<PlayerStatus> ();
		attackTimer = ps.attackSpeed;
		dir = this.GetComponent<PlayerDir> ();
	}
	
	// Update is called once per frame
	void LateUpdate() {
		if (ps.state == PlayerState.Death) {
			PlayAnim(anima_Death);
			return;
		}
		if (ps.state == PlayerState.Moving||ps.state==PlayerState.Follow) {
			PlayAnim (anima_Run);
		}  
		if (ps.state == PlayerState.Idle) {
			PlayAnim (anima_Idle);
		}
		if (ps.state == PlayerState.Attack) {
			if(ps.isGetSkill2){
                if (isHalfHP)
                {
                    random = Random.Range(0, 4);
                    isHalfHP = false;
                }
                else {
                    random = 0;
                }
			}
			attackTime+=Time.deltaTime;
			if(attackTime<1f){
				attacking=true;
				dealDamage=true;
				if(random==0){
					PlayAnim(anima_Attack2);
				}else{
					PlayAnim(anima_Attack1);
				}
			}else if(attackTime<attackTimer){
				PlayAnim (anima_Idle);
				if(dealDamage==true){
					dir.DealDamage(ps.attack+EquipMentUI._instance.attack+ps.attack_extra,random);
					dealDamage=false;
				}
			}
			if(attackTime>=attackTimer){
				attackTime=0f;
				attacking=false;
			}
		}
	}
	void PlayAnim(string animName){
		GetComponent<Animation>().CrossFade (animName);
	}
}
