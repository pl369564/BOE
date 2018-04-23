using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIO : MonoBehaviour {
//	FounctionBar fb;
	[SerializeField]
	AudioClip[] musicList;
	public AudioSource audios;
	int levelIndex=0;
	public static GameIO _instance;
	float time;
	PlayerStatus ps;
	public PlayerStatus PS{
		get{
			if (ps == null)
				ps = GameObject.FindWithTag (Tags.player).GetComponent<PlayerStatus> ();
			return ps;
		}
	}

	void Awake(){
		_instance = this;
	}
	public void StopBgm (){
		audios.Pause ();
	}
	public void PlayerBgm(int i,float sec=0){
		audios.clip=musicList[i];
		audios.PlayDelayed(sec);
	}
	void Start(){
		audios = this.GetComponent<AudioSource> ();
		DontDestroyOnLoad (this.gameObject);
		//SceneManager.sceneLoaded += Onlevelload;
	}
	//void Onlevelload(Scene scene,LoadSceneMode lsm){
	//	levelIndex = scene.buildIndex;
	//	switch (levelIndex) {
	//	case 0:
	//		CancelInvoke ();
	//		break;
	//	case 1:
	//		CancelInvoke ();
	//		break;
	//	case 2:
	//		CancelInvoke ();
	//		break;
	//	}
	//}
}
