using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Code : MonoBehaviour {
    public int[] correctCode;
    public GameObject Keypad;
    public GameObject num0;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;
    public GameObject retour;
    public GameObject valider;

    public AudioClip numAudio;

    public GameObject text;

    public string espText;
    public string errorText;
    public string acceptText;

    List<int> cod = new List<int>();
    int index = 0;

    private void Start()
    {
        text.GetComponent<Text>().text = espText;
    }

    public void recevoirSignal(GameObject go)
    {
        if (go == num0)
        {
            augmenterCode(0);
        }
        if (go == num1)
        {
            augmenterCode(1);
        }
        if (go == num2)
        {
            augmenterCode(2);
        }
        if (go == num3)
        {
            augmenterCode(3);
        }
        if (go == num4)
        {
            augmenterCode(4);
        }
        if (go == num5)
        {
            augmenterCode(5);
        }
        if (go == num6)
        {
            augmenterCode(6);
        }
        if (go == num7)
        {
            augmenterCode(7);
        }
        if (go == num8)
        {
            augmenterCode(8);
        }
        if (go == num9)
        {
            augmenterCode(9);
        }
        if (go == retour)
        {
            cancel();
        }
        if (go == valider)
        {
            tentative();
        }
    }

    void tentative()
    {
        if(index == correctCode.Length)
        {
            bool vrai = true;
            for(int i=0; i < correctCode.Length; i++)
            {
                if(cod[i] != correctCode[i])
                {
                    vrai = false;
                    break;
                }
            }
            if (vrai)
            {
                text.GetComponent<Text>().text = acceptText;
                playSound(numAudio);
                string v = "codeBon";
                PlayerPrefs.SetInt(v, 1);
                Keypad.SetActive(false);               
            }
            else
            {
                text.GetComponent<Text>().text = errorText;
                playSound(numAudio);
            }
        }
        else
        {
            text.GetComponent<Text>().text = errorText;
            modifText();
            playSound(numAudio);
        }
    }

    void modifText()
    {
        cod.Clear();
        index = 0;
    }

    void cancel()
    {
        cod.Clear();
        index = 0;
        text.GetComponent<Text>().text = espText;
        playSound(numAudio);
    }

    public void augmenterCode(int num)
    {
        cod.Add(num);
        index++;
        text.GetComponent<Text>().text = "";

        playSound(numAudio);

        for(int i=0; i<index; i++)
        {
            text.GetComponent<Text>().text += "*";
        }
    }

    void playSound(AudioClip sound)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
