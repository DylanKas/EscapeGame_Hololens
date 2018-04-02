using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule.Tests
{
    public class voiceHandler : MonoBehaviour, IInputClickHandler
    {
        public GameObject zero, un,deux,trois,quatre,cinq,six,sept,huit,neuf,dix,onze,douze,treize,quatorze;
        int TV=0;
        bool finDuJeuPerdu = false;
        bool finDuJeuGagne = false;
        void Start()
        {
            PlayerPrefs.SetInt("youWin", 0);
            PlayerPrefs.SetInt("youLose", 0);
            PlayerPrefs.GetInt("talking", 0);
            
            PlayerPrefs.SetInt("gameProgress", -2);
            string v;
            for (int i = 0; i <= 8; i++)
            {
                v = "tab" + i;
                Debug.Log("V " + i + " :" + v);
                PlayerPrefs.SetInt(v, 0);
            }
        }
        // Update is called once per frame
        void Update()
        {
            Debug.Log("avancement " + PlayerPrefs.GetInt("gameProgress"));
            Debug.Log("talking: " + PlayerPrefs.GetInt("talking"));
            if (PlayerPrefs.GetInt("gameProgress") == -2)
            {
                StartCoroutine(Begin());
            }
            if (PlayerPrefs.GetInt("gameProgress") == 0 && PlayerPrefs.GetInt("talking") == 0)
            {
                PlayerPrefs.SetInt("gameProgress", -1);
                StartCoroutine(BeginningVoice());
            }
            else if (PlayerPrefs.GetInt("gameProgress") == 2)
                StartCoroutine(DoctorTalk(trois, 11, 3));
            else if (PlayerPrefs.GetInt("gameProgress") == 3 && PlayerPrefs.GetInt("talking") == 0)
            {
                StartCoroutine(CactusTalk(quatre, 3, 4));
            }
            if(PlayerPrefs.GetInt("youWin") == 1)
                StartCoroutine(DoctorTalk(douze, 7, 5));
            if (PlayerPrefs.GetInt("youLose") == 1)
                StartCoroutine(DoctorTalk(treize, 9, 5));
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            int curHp = PlayerPrefs.GetInt("healthPoints");
            curHp -= 5;
            PlayerPrefs.SetInt("healthPoints", curHp);
            if (PlayerPrefs.GetInt("gameProgress") == -1 && PlayerPrefs.GetInt("talking") == 0)
            {
                StartCoroutine(CactusTalk(deux, 24, 2));
            }

            else if (PlayerPrefs.GetInt("gameProgress") == 4)
            {
                string v;
                bool[] enigmes=new bool[8];
                int enigme=-1;
                for (int i = 0; i < 8; i++)
                {
                    v = "tab" + i;
                    enigmes[i]=PlayerPrefs.GetInt(v)!=0;
                }
                bool find = false;
                for (int i = 0; i < 8; i++)
                {
                    if (enigmes[i] == false && find==false)
                    {
                        enigme = i;
                        find = true;
                    }
                }
                if (enigme == 0)
                    StartCoroutine(CactusTalk(cinq, 6, 4));
                else if (enigme == 1)
                    StartCoroutine(CactusTalk(six, 3, 4));
                else if (enigme == 2)
                    StartCoroutine(CactusTalk(sept, 3, 6));
                else if (enigme == 3)
                    StartCoroutine(CactusTalk(huit, 6, 4));
                else if (enigme == 4)
                    StartCoroutine(CactusTalk(neuf, 8, 4));
                else if (enigme == 5)
                    StartCoroutine(CactusTalk(dix, 5, 4));
                else if (enigme == 6)
                    StartCoroutine(CactusTalk(onze, 5, 4));
                else if (enigme == 7)
                    StartCoroutine(CactusTalk(douze, 5, 4));
            }
            eventData.Use();
        }
        public IEnumerator Begin()
        {
            PlayerPrefs.SetInt("move", -10);
            PlayerPrefs.SetInt("gameProgress", -10);
            yield return new WaitForSeconds(5);
            PlayerPrefs.SetInt("allumerTV", 1);
            TV = 1;
            zero.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(17);
            PlayerPrefs.SetInt("gameProgress", 0);
            PlayerPrefs.SetInt("talking", 0);
        }
        public IEnumerator Wait(int sec)
        {
            yield return new WaitForSeconds(sec);
        }
            public IEnumerator WaitB(int sec)
        {
            yield return new WaitForSeconds(sec);
            PlayerPrefs.SetInt("gameProgress", 0);
        }
        public IEnumerator DoctorTalk(GameObject go, int sec, int avancement)
        {
            PlayerPrefs.SetInt("gameProgress", -10);
            PlayerPrefs.SetInt("talking", 1);
            go.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("allumerTV", TV+1);
            TV++;
            PlayerPrefs.SetInt("gameProgress", -1);
            yield return new WaitForSeconds(sec);
                PlayerPrefs.SetInt("gameProgress", avancement);
            PlayerPrefs.SetInt("talking", 0);
        }
        public IEnumerator CactusTalk(GameObject go, int sec,int avancement)
        {
            PlayerPrefs.SetInt("gameProgress", -10);
            go.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("talking", 1);
            PlayerPrefs.SetInt("move", 1);
            yield return new WaitForSeconds(sec);
            PlayerPrefs.SetInt("move", 0);
            PlayerPrefs.SetInt("talking", 0);
            PlayerPrefs.SetInt("gameProgress", avancement);
        }
        public IEnumerator BeginningVoice()
        {
            un.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("move", 1);
            PlayerPrefs.SetInt("talking", 1);
            PlayerPrefs.SetInt("gameProgress", -1);
            yield return new WaitForSeconds(7);
            PlayerPrefs.SetInt("move", 0);
            PlayerPrefs.SetInt("talking", 0);
            yield return new WaitForSeconds(9);
            if(PlayerPrefs.GetInt("gameProgress") == -1)
                PlayerPrefs.SetInt("gameProgress", 0);
        }
    }
}
