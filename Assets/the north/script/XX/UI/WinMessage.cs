using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMessage : MonoBehaviour {
	public static WinMessage Instance;
	[SerializeField]
	UILabel winMessage;
	float time;
	float timer=1f;
    bool isShowing;
	void Awake(){
		Instance = this;
	}
	public void ShowWinMessage(string message){
		winMessage.text = message;
        time = 0;
        if (!isShowing)
        {
            isShowing = true;
        }
           
	}
    private void Update()
    {
        if (isShowing)
        {
            time += Time.deltaTime;
            if (time > timer)
            {
                winMessage.text = "";
                isShowing = false;
            }
               
        }

       
    }
}
