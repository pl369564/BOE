using UnityEngine;
using System.Collections;

public class pressanykey : MonoBehaviour {
    [SerializeField]
    GameObject title;
	private bool isAnyKeyDown = false;
	private GameObject buttonContainer;
	// Use this for initialization
	void Start () {
		buttonContainer = this.transform.parent.Find ("buttonContainer").gameObject;
		InvokeRepeating ("CheckAnyKey",0,0.1f);
	}

	// Update is called once per frame
	void CheckAnyKey () {
				if (isAnyKeyDown == false) {
						if (Input.anyKey) {
								ShowButton ();
				CancelInvoke ("CheckAnyKey");
						}
				}
		}
	void ShowButton(){
		buttonContainer.SetActive(true);
		this.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
         isAnyKeyDown =true;
	}
}