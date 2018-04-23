using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    public UISlider slider;
    public UILabel label;

    public static Loading inst;

    private void Awake()
    {
        inst = this;
        inst.gameObject.SetActive(false);
    }

    public void ShowLoding(string txt) {
        inst.gameObject.SetActive(true);
        slider.value = 0;
        label.text = txt;
        StartCoroutine("Coro_ShowLoding_fark");
    }

    IEnumerator Coro_ShowLoding_fark()
    {
        float time = 0;
        while (time < 2f)
        {
            time += time >= 1f ? 0.2f : 0.1f;
            slider.value = time / 2f;
            yield return new WaitForSeconds(0.2f);
        }
        inst.gameObject.SetActive(false);
    }
}
