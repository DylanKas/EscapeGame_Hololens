using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule.Tests
{
    public class cactusHandler : MonoBehaviour
    {
        private string[] m_AnimNames;
        int dialogue = 100000;
        int rand;
        int cptPlouf = 0;
        int cptFly = 0;
        // Use this for initialization
        void Start()
        {
            PlayerPrefs.SetInt("healthPoints", 150);
            m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
            Debug.Log(m_AnimNames.Length);
            int index = 0;
            foreach (AnimationState anim in GetComponent<Animation>())
            {
                m_AnimNames[index] = anim.name;
                Debug.Log(anim.name);
                index++;
            }
            GetComponent<Animation>()[m_AnimNames[1]].speed = 0.4f;
        }
        // Update is called once per frame
        void Update()
        {
            Debug.Log("move:" + PlayerPrefs.GetInt("move"));
            if (PlayerPrefs.GetInt("move")==1)
            {
                if (dialogue > 0)
                {
                    GetComponent<Animation>().Play(m_AnimNames[1]);
                    Debug.Log("ok dial");
                    dialogue--;
                }     
            }
            if (PlayerPrefs.GetInt("move") == 0)
            {
                
                rand = Random.Range(0, 50000);
                if (rand == 39456)
                {
                    GetComponent<Animation>().Play(m_AnimNames[2]);
                    cptFly++;
                }
                else if (rand == 14232)
                {
                    GetComponent<Animation>().Play(m_AnimNames[3]);
                    cptPlouf++;
                }
                else
                {
                    if (!GetComponent<Animation>().IsPlaying(m_AnimNames[2]) && !GetComponent<Animation>().IsPlaying(m_AnimNames[3]))
                        GetComponent<Animation>().Play(m_AnimNames[0]);
                }
            }

        }

    }
}
