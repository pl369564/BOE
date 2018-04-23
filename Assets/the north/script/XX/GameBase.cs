using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBase : MonoBehaviour {

	protected Transform myTransform;
	// Use this for initialization
	void Awake () {
		myTransform = this.transform;
	}
}
