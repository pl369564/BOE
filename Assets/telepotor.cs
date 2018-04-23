using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class telepotor : MonoBehaviour {

    [SerializeField]
    private int tpPoint = 2;
    [SerializeField]
    private UILabel label;

    public GameObject Scene1;
    public GameObject Scene2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {

            if (tpPoint == 2){
                Scene1.SetActive(true);
                other.transform.GetComponent<PlayerStatus>().ResetPosition(new Vector3(162f, 45.7f, 290f));//other.transform.position = new Vector3(162f,46f,290f);
                Loading.inst.ShowLoding("正在进入 小镇 ");
            }
            else if (tpPoint == 1)
            {
                Scene1.SetActive(false);
                other.transform.GetComponent<PlayerStatus>().ResetPosition(new Vector3(173f, 45.7f, 375f));//other.transform.position = new Vector3(162f, 46f, 350f);
                Loading.inst.ShowLoding("正在进入 公墓 ");
            }

        }
        
    }

}
