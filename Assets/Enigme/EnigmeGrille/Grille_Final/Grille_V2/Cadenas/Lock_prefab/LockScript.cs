using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour, IInputClickHandler
{
    bool done;
    public GameObject origine, ouvert;
        public AudioSource soundopen,soundclosed;
    // Use this for initialization
    void Start () {
        done = false;
        int unlocked = 0;
        PlayerPrefs.SetInt("bombUnlocked", unlocked);
    }

    // Update is called once per frame
    public void OnInputClicked(InputClickedEventData eventData)
    {
        /*if ()
        {*/            
                Debug.Log("Cadenas touché");
                if (!done && PlayerPrefs.GetInt("bombUnlocked")==1)
                {
                    done = true;
                     soundopen.Play();
                    PlayerPrefs.SetInt("tab7", 1);
                    origine.SetActive(false);
                    done = true;
                    ouvert.SetActive(true);
                    int unlocked = 1;
                    PlayerPrefs.SetInt("bombUnlocked", unlocked);
                    eventData.Use();
            Collider m_Collider = GetComponent<Collider>();
            m_Collider.enabled = false;
        }
        else
        {
            soundclosed.Play();
        }
            
        //}

    }
}
