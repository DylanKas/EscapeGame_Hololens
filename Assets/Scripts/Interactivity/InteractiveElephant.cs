using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElephant : InteractiveObject
{

    // Use this for initialization
    public override void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void TriggerInteraction()
    {
        string v = "feedGorille";
        if (PlayerPrefs.GetInt(v) == 1)
        {
            gameObject.SetActive(true);
        }
    }
}
