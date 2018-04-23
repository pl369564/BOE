using UnityEngine;
using System.Collections;

public class Creation : MonoBehaviour {
	public GameObject[] characterPrefabs;
	public UIInput nameInput;
	private GameObject[] characterGameObjects;
	public int selectedIndex=0;
	public int length;

	// Use this for initialization
	void Start () {
		length = characterPrefabs.Length;
		characterGameObjects=new GameObject[length];
		for (int i=0; i<length; i++) {
			characterGameObjects[i]=GameObject.Instantiate(characterPrefabs[i],transform.position,transform.rotation) as GameObject;	
		}
		UpdateCharacterShow ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void UpdateCharacterShow(){
		characterGameObjects [selectedIndex].SetActive (true);
		for(int i=0;i<length;i++){
			if(i!=selectedIndex)
				characterGameObjects[i].SetActive(false);
		}
	}
	public void onNextButtonClick(){
		selectedIndex++;
		selectedIndex %= length;
		UpdateCharacterShow ();
	}
	public void onPrevButtonClick(){
		selectedIndex--;
		if(selectedIndex==-1){
			selectedIndex=length-1;
			}
		UpdateCharacterShow();
	}
	public void OnOKButtonClick(){
		PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
		PlayerPrefs.SetString("name",nameInput.value);
		Application.LoadLevel (2);

	}
}
