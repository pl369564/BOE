using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform player;
    public GameObject UIRoot;
    private Vector3 offsetPosition;
	public float distance=0;
	public float scrollSpeed=10;
	public bool isRotating=false;
	public float rotateSpeed=10;
	public bool rotating=true;
	public string tags=Tags.player;

	// Use this for initialization
	void Start () {
        UIRoot = GameObject.Find("UIRoot");
        player = GameObject.FindGameObjectWithTag(tags).transform;
		transform.LookAt(player.position);
		offsetPosition = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = offsetPosition + player.position;
		if (rotating == true) {
			RotateView ();
			}
		ScrollView ();
	}
	void ScrollView(){
		distance = offsetPosition.magnitude;
		distance-=Input.GetAxis("Mouse ScrollWheel")*scrollSpeed;
		distance = Mathf.Clamp (distance, 2, 15);
		offsetPosition = offsetPosition.normalized * distance;
	}
	void RotateView(){
		if (Input.GetMouseButtonDown (1)&& (UICamera.hoveredObject == null || UICamera.hoveredObject == UIRoot)) {
            isRotating =true;
		}
		if (Input.GetMouseButtonUp (1)) { 
			isRotating=false;
		}
		if (isRotating) {
			transform.RotateAround(player.position,Vector3.up,rotateSpeed*Input.GetAxis("Mouse X"));
			Vector3 originalPos=transform.position;
			Quaternion originalRot=transform.rotation;
		    transform.RotateAround(player.position,transform.right,-rotateSpeed*Input.GetAxis("Mouse Y"));
			float x=transform.eulerAngles.x;
			if (x < 10 || x > 80) {
				transform.position=originalPos;
				transform.rotation=originalRot;
			};
			offsetPosition = transform.position - player.position;
		}
	}
}
