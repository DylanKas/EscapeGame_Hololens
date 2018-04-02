using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time;
    public GameObject text;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("youLose", 0);
        PlayerPrefs.SetInt("youWin", 0);
        StartCoroutine(timer());
        time += 1;
    }

    IEnumerator timer()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
            GetComponent<Text>().text = string.Format("{0:0}:{1:0}", Mathf.Floor(time / 60), time % 60);
        }

        if (time == 0)
        {
            PlayerPrefs.SetInt("youLose", 1);
            Debug.Log("Partie terminée !");
        }
    }
}
