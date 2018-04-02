using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallucinationEffect : MonoBehaviour
{
    public float time = 45;
    public GameObject camera;
    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        transform.position = camera.transform.position;
        transform.rotation = camera.transform.rotation;
        transform.parent = camera.transform;
        transform.position += transform.forward * (float)1.95;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            GetComponent<Animation>().Play("colorchanging");
        }
    }
}