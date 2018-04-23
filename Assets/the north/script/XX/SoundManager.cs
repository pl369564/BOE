using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	[SerializeField]
	AudioSource audioSource;
	[SerializeField]
	UISlider uiSlider;
	public void SetSoundValue(){
		audioSource.volume = uiSlider.value;
	}
}
