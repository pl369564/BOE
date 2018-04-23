using UnityEngine;
using System.Collections;

public enum EnemyStates{
	Attack,
	Def,
	Death,
	Idle,
	Walk
}

public class WolfBaby : Enemy {

	public string anima_walk;
	public string anima_idle;
	public string anima_die;
	public string anima_attack1;
	public string anima_attack2;
	public string anima_takeDamage1;
	public string anima_takeDamage2;
	public string spawnName;
	private EnemyStates enemyState;
	private MonsterMoveManager mmm;
	float time=0;
	float attackTime;
	public float timer=8;
	private CharacterController cc;
	public GameObject hudTextPrefab;
	public Spawn spawn;
	private GameObject hudTextGo;
	private GameObject hudFollow;
	private HUDText hudText;
	private UIFollowTarget followTarget;
	private PlayerStatus ps;
	private PlayerAnimationS pa;
	private bool isAttack=false;
	private bool isDie=false;
	private float damageCoe;
	private float halfHp;

	public float moveSpeed=1;
	public float hp=100;
	public float attack=5;
	public float attackTimer=0.733f;
	public float attackIdle=2f;
	public int hitStun=0;
	public int attackStun=1;
	public float def=0;
	public float CriRate=1.5f;
	public float pRange=20;
	public int exp=5;
	public bool isLowHp;
	public int questID=1;

	public float minDistance=1;
	public float maxDistance=20;
	private Transform target;
	void Awake(){
		enemyState = EnemyStates.Idle;
		cc=this.GetComponent<CharacterController>();
		hudFollow = this.transform.Find ("HUDText").gameObject;
		spawn=GameObject.Find (spawnName).GetComponent<Spawn>();
	}
	public void GetMMM(MonsterMoveManager mmm){
		this.mmm = mmm;
	}
	void Start(){
		halfHp = hp / 2;
	}
	void Update(){
		if (enemyState == EnemyStates.Death) {
				GetComponent<Animation>().CrossFade (anima_die);
				Destroy (this.gameObject, 2);
			if(isDie==false){
				spawn.number--;
				pa.attackTime=0;
				pa.attacking=false;
				QuestUI.Instance.PromoteQuest (questID);
				ps.state = PlayerState.Idle;
				ps.GetExp (exp);
				ps.GetComponent<PlayerDir> ().targetPosition = ps.transform.position;
				cc.enabled = false;
				DropItemPool.Instance.GetADropItem (transform.position,1);
				Special ();
				isDie=true;
			}
				} else {
						if (enemyState == EnemyStates.Idle || enemyState == EnemyStates.Walk) {
								time += Time.deltaTime;
								if (time > timer) {
										SwitchState ();
										if (enemyState == EnemyStates.Walk) {
												time = 0;
										} else {
												time = 4;
										}
								}
								if (enemyState == EnemyStates.Walk) {
										cc.SimpleMove (transform.forward * moveSpeed);
								}
						}
						if (enemyState == EnemyStates.Attack) {
								//transform.LookAt(target);
								Attack ();
						}
				}
		}
	protected virtual void Special(){
		
	}
	protected void SwitchState(){
		if (enemyState == EnemyStates.Walk) {
			GetComponent<Animation>().CrossFade (anima_idle);
			enemyState = EnemyStates.Idle;
				} else {
			float distance=Vector3.Distance(spawn.transform.position,this.transform.position);
			if (distance <= pRange) {
//			transform.Rotate(transform.up*Random.Range(0,360));
				transform.LookAt (mmm.ReturnPath ());
				GetComponent<Animation> ().CrossFade (anima_walk);
				enemyState = EnemyStates.Walk;
			}else{
				transform.LookAt (spawn.transform.position);
				GetComponent<Animation>().CrossFade(anima_walk);
				enemyState = EnemyStates.Walk;
			}
		}
    }
	public void TakeDamage(float damage){
		if(hp>0){
			if (ps == null) {
				ps=GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
				hudTextGo = NGUITools.AddChild (HUDTextt._instance.gameObject, hudTextPrefab);
				hudText=hudTextGo.GetComponent<HUDText>();
				followTarget=hudTextGo.GetComponent<UIFollowTarget>();
				followTarget.target = hudFollow.transform;
				followTarget.gameCamera = Camera.main;
				followTarget.uiCamera =GameObject.Find ("UIRoot/Camera").GetComponent<Camera>();
				pa=GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerAnimationS>();
			}
			if (ps.random == 0) {
				damage +=damage;
				ps.random = 1;
			}
			damageCoe = PlayerStatus.GetDamageCoe ();
			damage-=def;
			if(damage<0)
				damage=0;
			hp-=damage*damageCoe;
			enemyState=EnemyStates.Def;
			GetComponent<Animation>().CrossFade(anima_takeDamage1);
			hudText.Add("-"+damage*damageCoe,Color.red,1);
			TakeDamageAnim();
			target=ps.transform;
			enemyState=EnemyStates.Attack;
		}
		if (hp < halfHp) {
			isLowHp = true;
		} else {
			isLowHp = false;
		}
		if (hp <= 0) {
			enemyState = EnemyStates.Death;
		}
	}
	void Attack(){
		if (target != null) {
			float distance = Vector3.Distance (transform.position, target.position);
			if (distance >= maxDistance) {
				ReSet();
			}
			if (distance <= minDistance||isAttack==true) {
				attackTime += Time.deltaTime;
				transform.LookAt (target);
				if (attackTime <= attackTimer) {
					if (hp > 30 || hp < 10) {
						GetComponent<Animation>().CrossFade (anima_attack1);
						if(isAttack==false){
							ps.TakeDamage (attack);
							isAttack=true;
						}
					} else {
						GetComponent<Animation>().CrossFade (anima_attack2);
						if(isAttack==false){
							ps.TakeDamage(attack*CriRate);
							isAttack=true;
						}
					}
				}
				if(ps.state==PlayerState.Death){
					ReSet();
				}
				if(attackTime>attackTimer&&attackTime<attackIdle){
					GetComponent<Animation>().CrossFade (anima_idle);
				}
				if(attackTime>=attackIdle){
					if (hp > 30 || hp < 10){
						attackTime=0.1f;
					}else{
						attackTime=0f;
					}
					isAttack=false;
				}
			}
			if(minDistance<distance&&distance<maxDistance&&isAttack==false){
				transform.LookAt (target);
				cc.SimpleMove (transform.forward * moveSpeed);
				GetComponent<Animation>().CrossFade (anima_walk);
			}
		}
}
	void ReSet(){
		enemyState = EnemyStates.Idle;
		attackTime = 0;
		time = 0;
		target = null;
	}
	void OnDestroy(){
		GameObject.Destroy (hudTextGo);
	}
	IEnumerator TakeDamageAnim(){
		yield return new WaitForSeconds(1f);
	}
}
