using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonContainer : MonoBehaviour
{
    [SerializeField]
    GameObject settingUI;
    [SerializeField]
    GameObject buttonContain;
    [SerializeField]
    Camera mainCamera;
    Transform c_tsf;
    [SerializeField]
    Transform c_rp;
    [SerializeField]
    MS_MoveToStart mts;
    public TweenAlpha ta;
    float rotateTime = 1f;
    int i;
    Quaternion qua;
    public void OnNewGame()
    {
        c_tsf = mainCamera.transform;
        //Invoke("Talk", 0.5f);
        //Invoke("Talk", 3f);
        //Invoke("Talk", 5.5f);
        //Invoke("Talk", 8f);
        mts.TurnOn();
        InvokeRepeating("mainCameraLooking", 0, Time.deltaTime);
    }
    public void OnLoadGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);
    }
    public void OnSetting()
    {
        buttonContain.SetActive(false);
        Invoke("Setting", 0.2f);
    }
    void Setting()
    {
        settingUI.SetActive(true);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    void mainCameraLooking()
    {
        //if (Quaternion.Dot (c_tsf.rotation, c_rp.rotation) < 0.99f) {
        //	qua = Quaternion.LookRotation (c_rp.forward, c_tsf.up);
        //	c_tsf.rotation = Quaternion.Lerp (c_tsf.rotation, qua, rotateTime * Time.deltaTime);
        //} else {
        buttonContain.gameObject.SetActive(false);
        ta.PlayReverse();
        Invoke("LoadNewGame", 9f);
        CancelInvoke("mainCameraLooking");
        //}
    }
    void Talk()
    {
        switch (i)
        {
            case 0:
                LabelControl.Instance.Talk(StoryTxt.C0S1P1);
                break;
            case 1:
                LabelControl.Instance.Talk(StoryTxt.C0S1P2);
                break;
            case 2:
                LabelControl.Instance.Talk(StoryTxt.C0S1P3);
                GameIO._instance.StopBgm();
                break;
            case 3:
                LabelControl.Instance.Talk(StoryTxt.C0S1P4);
                break;
        }
        i++;
    }
    void LoadNewGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 0);
        SceneManager.LoadScene(1);
        //Application.LoadLevel(1);
    }
}