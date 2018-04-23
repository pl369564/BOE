using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject enemy;
	public int maxNumber=5;
	public float createRate=10f;
	private float time=0f;
	public int number=1;
	[SerializeField]
	MonsterMoveManager mmm;

	void Update(){
		if (number < maxNumber) {
			time+=Time.deltaTime;
			while(time>createRate){
				Vector3 pos=this.transform.position;
				GameObject.Instantiate(enemy,pos,Quaternion.identity).GetComponent<WolfBaby>().GetMMM(mmm);
				time=0f;
				number++;
			}
		}
	}
//	void QuestCompelete(){
//		Destroy (this.gameObject);
//	}
}
