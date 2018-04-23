using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour {
	[SerializeField]
	UISlider soundSlider;
	AudioSource Sound;
	AudioSource sound{
		get{if (Sound == null)
				Sound = GameIO._instance.audios;
			return Sound;
		}
	}
	[SerializeField]
	GameObject buttonContatin;
	[SerializeField]
	TweenAlpha ta;
	[SerializeField]
	TweenPosition tp;
	bool isTrans;
	float e=0.1f;
	public void OnSoundAddBtn(){
		soundSlider.value += e;
		sound.volume = soundSlider.value;
	}
	public void OnSoundMinBtn(){
		soundSlider.value -= e;
		sound.volume = soundSlider.value;
	}
	public void ShowMenu(){
		buttonContatin.SetActive (true);
		if (ta != null) {
			ta.enabled = false;
		}
		this.gameObject.SetActive (false);
	}
	public void UpdateSlider(){
		sound.volume = soundSlider.value;
	}
	public void Onenable(){
		if (ta != null) {
			ta.enabled = true;
		}
	}
	public void TransformState(){
		if (!isTrans) {
			if (!tp.enabled) {
				tp.enabled = true;
			}
			tp.PlayForward ();
			isTrans = true;
		} else {
			tp.PlayReverse ();
			isTrans = false;
		}
	}
}
