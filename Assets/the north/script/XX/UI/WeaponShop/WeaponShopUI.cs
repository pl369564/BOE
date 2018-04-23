using UnityEngine;
using System.Collections;

public class WeaponShopUI : MonoBehaviour {
	[SerializeField]
	TweenPosition tween;
	public void ONBtnClose(){
		tween.PlayReverse();
	}
}