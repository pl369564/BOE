using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_MoveToStart : MonoBehaviour {

    public Animation myAnimation;
    public Animator myAnimator;
    public float moveSpeed;
    public bool isStart = false;
    public Transform myTrs;
    bool ismove = false;
    public float time = 5f;
    float timer = 0f;

    public void TurnOn() {
        isStart = true;
        timer = 0f;
        //myAnimator.SetTrigger("go");
        //Invoke("Walk", time);
    }
    //private void Walk()
    //{
    //    Debug.Log("Walk");
       
    //    //Vector3 z= myTrs.position;
    //    //z.z -= 0.45f;
    //    //myTrs.position = z;
    //}
    //private void LateUpdate()
    //{
    //    if (!isStart)
    //        return;
    //    myTrs.Translate(myTrs.forward * moveSpeed);
    //}
    private void FixedUpdate()
    {
        if (!isStart)
            return;
        timer += Time.deltaTime;
        if (timer < 3.5f)
        {
            myAnimation.Play("StandUp");
        }
        else
        {
            if (!ismove)
            {
                ismove = !ismove;
                Vector3 z = myTrs.position;
                z.z -= 0.45f;
                myTrs.position = z;
            }
            myAnimation["walking"].speed = 0.75f;
            myAnimation.Play("walking");
            myTrs.Translate(myTrs.forward * moveSpeed);
        }

    }
}
