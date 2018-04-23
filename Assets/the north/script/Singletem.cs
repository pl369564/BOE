using System;
using UnityEngine;

public class Singletem<T>:MonoBehaviour
	where T:MonoBehaviour{
	static T _instance;
	public static T Instance{
		get{return _instance; }
	}
	void Awake(){
		_instance = this as T;
	}
}

