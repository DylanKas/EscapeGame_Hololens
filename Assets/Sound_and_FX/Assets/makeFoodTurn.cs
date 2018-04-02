using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeFoodTurn : MonoBehaviour {
    public GameObject foodsToRotate;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foodsToRotate.transform.Rotate(Vector3.up *1.75f * Time.deltaTime);
    }
}
