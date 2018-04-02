using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorHandler : MonoBehaviour {
    public GameObject TV1, TV2, TV3, TV4;
	// Use this for initialization
	void Start () {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("allumerTV") == 1)
            StartCoroutine(WaitTV1(11));
        else if (PlayerPrefs.GetInt("allumerTV") == 2)
            StartCoroutine(WaitTV2(11));
    }
    public IEnumerator WaitTV1(int sec)
    {
        TV1.SetActive(true);
        yield return new WaitForSeconds(sec);
        PlayerPrefs.SetInt("allumerTV", 0);
        TV1.SetActive(false);

    }
    public IEnumerator WaitTV2(int sec)
    {
        TV2.SetActive(true);
        yield return new WaitForSeconds(sec);
        PlayerPrefs.SetInt("allumerTV", 0);
        TV2.SetActive(false);

    }
}
