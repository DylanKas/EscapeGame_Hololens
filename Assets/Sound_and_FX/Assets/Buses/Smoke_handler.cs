using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_handler : MonoBehaviour {
    GameObject playerHead;
    int children;
	// Use this for initialization
	void Start () {
        playerHead = GameObject.FindGameObjectWithTag("MainCamera");
        float smokeY=(float)(playerHead.transform.position.y+3);
        transform.position=new Vector3(0, smokeY, 0);
        children = transform.childCount;
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("launchSmoke") == 1)
        {
            for (int i = 0; i < children; ++i)
                transform.GetChild(i).gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("stopSmoke") == 1)
        {
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            this.enabled = false;
        }
	}
}
