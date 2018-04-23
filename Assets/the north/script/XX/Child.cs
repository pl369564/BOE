using UnityEngine;
using System.Collections;

public class Child : MonoBehaviour {

	public Transform[] positions;

	void Awake () {
		positions = new Transform[transform.childCount];
		for (int i = 0; i<transform.childCount; i++) {
			positions [i]=transform.GetChild(i);
				}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
