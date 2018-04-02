using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVManager : MonoBehaviour
{
    public GameObject tv;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("allumerTV", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("allumertv : " + PlayerPrefs.GetInt("allumerTV"));
        if (PlayerPrefs.GetInt("allumerTV") >=1 )
        {
            tv.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("allumerTV") == 0)
        {
            tv.SetActive(false);
        }
    }
}
