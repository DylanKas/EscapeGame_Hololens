using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Buse_launcher : MonoBehaviour
{
    int children;
    public GameObject aliments;
    bool done;
    private int onlyLooseHpOnce = 1;
    // Use this for initialization
    void Start()
    {
        done = false;
        children = transform.childCount;
        int value = 0;

        PlayerPrefs.SetInt("isButtonDown", value);
        PlayerPrefs.SetInt("stopBuses", value);
        PlayerPrefs.SetInt("stopSmoke", value);
        PlayerPrefs.SetInt("launchSmoke", value);
        PlayerPrefs.SetInt("foods", 0);
        aliments.SetActive(false);

        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("foods") == 1)
        {
            Debug.Log("Active food");
            aliments.SetActive(true);
        }
        else
        {
            aliments.SetActive(false);
        }
        if (PlayerPrefs.GetInt("isButtonDown") == 1)
        {
            done = true;
            PlayerPrefs.SetInt("isButtonDown", 0);
            StartCoroutine(looseHp());
            for (int i = 0; i < children; ++i)
                transform.GetChild(i).gameObject.SetActive(true);
        }
        if (done && PlayerPrefs.GetInt("stopBuses") == 1)
        {
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            //this.enabled = false;
        }

    }
    public IEnumerator looseHp()
    {
        int hp = PlayerPrefs.GetInt("healthPoints");
        for (int i = 0; i < 26; i++)
        {
            hp--;
            PlayerPrefs.SetInt("healthPoints", hp);
            yield return new WaitForSeconds(1f);
        }


    }
}
