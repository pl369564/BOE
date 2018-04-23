using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {



	
	// Update is called once per frame
	void Update () {
		this.transform.rotation=Quaternion.LookRotation(Vector3.zero);
	}
}
