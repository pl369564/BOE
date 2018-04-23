using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public ApplicationType apType;
	public Vector3 resetPosition;
	public int level = 1; 
	public string name = "默认名称";
	public float hp = 100;
	public int mp = 100;
	public float hp_remain = 100;
	public float mp_remain = 100;
	public float exp = 0;
	public int attack = 10;
	public int attack_plus = 0;
	public int attack_extra=0;
	public int def = 0;
	public int def_plus = 0;
	public int def_extra=0;
	public int speed = 4;
	public int speed_plus = 0;
	public int speed_extra=0;
	public int point_remain = 6;
	public int coin=0;
	public float maxExp=10;
	public int hitStun=10;
	public int attackStun=10;
	public PlayerState state=PlayerState.Idle;
	public float attackRange=0.7f;
	public float attackSpeed=1f;
	public bool isGetSkill1;
	public bool isGetSkill2;
	public bool isGetSkill3;
	public bool isGetSkill4;

	public int random=1;
	private static float damageCoe=1f;
	public static float GetDamageCoe(){
		return damageCoe;
	}
	public static void SetDamageCoe(float f){
		damageCoe = f;
	}
	public void GetCoin(int count){
		coin = coin + count;
	}
	public void AddAttack(){
		if (point_remain > 0) {
			attack_plus+=1;
			point_remain-=1;
		}
	}
	public void AddDef(){
		if (point_remain > 0) {
		    def_plus += 1;
			point_remain -= 1;
				}
	}
	public void AddSpeed(){
		if (point_remain > 0) {
			speed_plus += 1;
			point_remain -= 1;
		}
	}
	public void ReSet(){
		point_remain = point_remain + speed_plus + def_plus + attack_plus;
		speed_plus = 0;
		attack_plus = 0;
		def_plus = 0;
	}
	public void SetStatus(){
		attack = attack + attack_plus;
		attack_plus = 0;
		def = def + def_plus;
		def_plus = 0;
		speed = speed + speed_plus;
		speed_plus = 0;
		}
	public bool isBuy(int count){
		if (count <= coin) {
			return true;
				} else {
			return false;}
	}
	public bool dealMp(int mpcost){
		if (mp_remain < mpcost) {
			return false;
				} else {
			mp_remain-=mpcost;
			return true;
				}
		}
	public void Pay(int count){
		coin -= count;
		}
	public void UseDrug(int hp,int mp){
		hp_remain += hp;
		if (hp_remain > this.hp) {
			hp_remain=this.hp;	
		}
		mp_remain += mp;
		if (mp_remain > this.mp) {
			mp_remain=this.mp;	
		}
	}
	public void GetExp(int exp){
		this.exp += exp;
		while (this.exp>=maxExp) {
            WinMessage.Instance.ShowWinMessage("升级了,获得了5点属性点.");
			level+=1;
			this.exp-=maxExp;
			maxExp=2*maxExp+10;
			point_remain+=5;
			hp_remain=hp;
			mp_remain=mp;
		}
		HeadStatusUI._instance.OnUpdateShow();
	}
	public void TakeDamage(float damage){
		if (isGetSkill4 == true) {
			random = Random.Range (0,2);
			if (random == 0) {
				return;
			}
		}
		int tDef = def + EquipMentUI._instance.def+def_extra;
		damage -= tDef;
		if (damage < 0) {
			damage=0;
		}
		hp_remain -= damage;
		HeadStatusUI._instance.OnUpdateShow ();
		if (hp_remain <= 0) {
			UIDiedWindow._instance.OnYouDied ();
			state=PlayerState.Death;
				}
	}
	public void ReStart(){
		this.GetComponent<PlayerDir> ().targetPosition = resetPosition;
		hp_remain = hp;
		mp_remain = mp;
		exp=exp*0.5f;
		state = PlayerState.Idle;
		transform.position=resetPosition;
		HeadStatusUI._instance.OnUpdateShow ();
	}
    public void ResetPosition(Vector3 pos) {
        this.GetComponent<PlayerDir>().targetPosition = pos;
        state = PlayerState.Idle;
        transform.position = pos;
    }
}
