using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSecondVideoTutorial : MonoBehaviour
{
    public GameObject video1;
    public GameObject video2;
    // Use this for initialization
    void Start()
    {
        video1.SetActive(false);
        video2.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

       
    }
}
