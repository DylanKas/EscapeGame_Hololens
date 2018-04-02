using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveGlass : MonoBehaviour
{

    public GameObject miroir, miroirHS;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void OnSelect () {
        miroir.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        miroirHS.SetActive(true);
    }
}
