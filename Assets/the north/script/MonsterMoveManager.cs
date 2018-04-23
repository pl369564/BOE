using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveManager : MonoBehaviour {
	[SerializeField]
	Transform[] pathList;
	int count{
		get{return pathList.Length; }
	}
	public Vector3 ReturnPath(){
		int random = Random.Range (0,count);
		return pathList [random].position;
	}
}