using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterUP : MonoBehaviour {

    Vector3 wantedPosition;
    Vector3 pos1;
    public float speed = 10f;
    public GameObject collider;
    private bool done;

    // Use this for initialization
    void Start () {
        //wantedPosition = transform.position + Vector3.up;
        pos1.y = transform.position.y + 2.3f;
        PlayerPrefs.SetInt("waterUP", 0);
        done = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("waterUP") == 1)
        {
            if (!done)
            {
                done = true;
                AudioSource sonEau = GetComponent<AudioSource>();
                if(sonEau!=null)
                    sonEau.Play();
            }
            if (transform.position.y < pos1.y)
            {
                wantedPosition = transform.position;
                wantedPosition.y += 0.005f;
                transform.position = wantedPosition;
            }
            else
            {
                collider.SetActive(false);
            }
        }
    }
}

