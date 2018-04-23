using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIDiedWindow : MonoBehaviour {
	public static UIDiedWindow _instance;
	private PlayerStatus ps;
	private TweenAlpha ta;

	void Awake(){
		_instance = this;
		ta = this.GetComponent<TweenAlpha> ();
      
    }
	void Start(){
		_instance.gameObject.SetActive (false);
		ps = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
	}
	public void OnYouDied(){
		_instance.gameObject.SetActive (true);
		ta.PlayForward ();
		}
	public void OnBtnOK(){
        //ps.ReStart();
		ta.PlayReverse ();
        SceneManager.LoadScene(0);
    }
}
