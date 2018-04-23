using UnityEngine;
using System.Collections;

public class MiniMapUI : MonoBehaviour {

	private Camera minimapCamera;
	void Start()
	{
		minimapCamera = GameObject.FindGameObjectWithTag (Tags.minimapCamera).GetComponent<Camera> ();
	}
	public void OnMapZoomin(){ 
		minimapCamera.orthographicSize--;
	}
	public void OnMapZoomOut(){
		minimapCamera.orthographicSize++;
	}
}
