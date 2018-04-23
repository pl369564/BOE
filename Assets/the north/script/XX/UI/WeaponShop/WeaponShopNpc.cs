﻿using UnityEngine;
using System.Collections;

public class WeaponShopNpc : Npc {

	public TweenPosition shopDrug;
	
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			shopDrug.PlayForward();
		}
	}
    public void ShowShopDrug() {
        shopDrug.PlayForward();
    }
}
