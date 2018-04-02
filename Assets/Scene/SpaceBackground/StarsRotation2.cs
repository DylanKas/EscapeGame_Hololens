using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsRotation2 : MonoBehaviour
{
    public GameObject starsToRotate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        starsToRotate.transform.Rotate(Vector3.right * -2 * Time.deltaTime);
    }
}
