using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBoss : WolfBaby {
	
	protected override void Special(){
		EndPoint.Instance.killboss ();	
	}

}
