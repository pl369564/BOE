using UnityEngine;
using System.Collections;

public class CharacterLoader : MonoBehaviour {
	public GameObject magicianPrefab;
	public GameObject swordmanPrefab;
	void Awake(){
		int selectindex=PlayerPrefs.GetInt("SelectedCharacterIndex");
		string name=PlayerPrefs.GetString("name");
        GameObject role = null;
        if (selectindex == 1)
        {
            role = GameObject.Instantiate(magicianPrefab);
        }
        else if (selectindex == 0)
        {
            role = GameObject.Instantiate(swordmanPrefab);
        }

        
       // DontDestroyOnLoad(role);
      //  DontDestroyOnLoad(Camera.main.gameObject);
       // DontDestroyOnLoad(GameObject.Find("UIRoot"));
	}
}
