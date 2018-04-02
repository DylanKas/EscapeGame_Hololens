using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutCable : MonoBehaviour, IInputClickHandler {
    bool done;
	public GameObject origine, casse, winText,spaceBG;
    public AudioSource sound;
	public string objectName;
	public string code="3124";
    // Use this for initialization
    void Start()
    {
        Debug.Log("je suis dans cutCable");
        done = false;
        winText.SetActive(false);
        PlayerPrefs.SetInt("nbOfCutCables", 0);
		PlayerPrefs.SetInt("cable_Bleu",0);
		PlayerPrefs.SetInt("cable_Jaune",0);
		PlayerPrefs.SetInt("cable_Rouge",0);
		PlayerPrefs.SetInt("cable_Vert",0);
        PlayerPrefs.SetInt("grilleReset", 0);
        PlayerPrefs.SetInt("countReset", 0);
		objectName = "cable_" + objectName;

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("grilleReset")==1&&PlayerPrefs.GetInt(objectName)!=2)
        {
            origine.SetActive(true);
            casse.SetActive(false);
            PlayerPrefs.SetInt(objectName, 2);
            int cnt = PlayerPrefs.GetInt("countReset");
            cnt++;
            PlayerPrefs.SetInt("countReset", cnt);
            if (PlayerPrefs.GetInt("countReset")==4)
            {
                PlayerPrefs.SetInt("cable_Bleu", 0);
                PlayerPrefs.SetInt("cable_Jaune", 0);
                PlayerPrefs.SetInt("cable_Rouge", 0);
                PlayerPrefs.SetInt("cable_Vert", 0);
                PlayerPrefs.SetInt("nbOfCutCables", 0);
                PlayerPrefs.SetInt("countReset", 0);
                PlayerPrefs.SetInt("grilleReset", 0);
            }
            done = false;
        }
    }
    // Update is called once per frame
    
        public void OnInputClicked(InputClickedEventData eventData)
        {
        int nbCut = PlayerPrefs.GetInt("nbOfCutCables");
        if (nbCut == 3)
        {
            nbCut++;
            PlayerPrefs.SetInt("nbOfCutCables", nbCut);
            Debug.Log("Cut Cable");
            Debug.Log(objectName);
            PlayerPrefs.SetInt(objectName, nbCut);
            origine.SetActive(false);
            done = true;
            casse.SetActive(true);
            eventData.Use();
            Debug.Log("GetCode: " + getCode() + "  code: " + code);
            if (getCode() == code)
            {
                winText.SetActive(true);
                spaceBG.SetActive(true);
                
                PlayerPrefs.SetInt("youWin", 1);
                Debug.Log("Victory");
            }
            else
            {
                int newhp = PlayerPrefs.GetInt("healthPoints") - 10;
                PlayerPrefs.SetInt("healthPoints", newhp);
                Debug.Log("You Lost");
                reset();
            }
        }
        else
        {
            //si aucune animation n'est en execution
            if (!done)
            {
                sound.Play();
                nbCut++;
                PlayerPrefs.SetInt("nbOfCutCables", nbCut);
                Debug.Log("Cut Cable");
                Debug.Log(objectName);
                PlayerPrefs.SetInt(objectName, nbCut);
                origine.SetActive(false);
                done = true;
                casse.SetActive(true);
                eventData.Use();
                getCode();
            }

        }
        }
	public string getCode(){
		string codeToGet = PlayerPrefs.GetInt ("cable_Jaune").ToString() + PlayerPrefs.GetInt ("cable_Rouge").ToString() + PlayerPrefs.GetInt ("cable_Vert").ToString() + PlayerPrefs.GetInt ("cable_Bleu").ToString();
		Debug.Log (codeToGet);
		return codeToGet;
	}

	public void reset(){
		done = false;
		PlayerPrefs.SetInt("cable_Bleu",0);
		PlayerPrefs.SetInt("cable_Jaune",0);
		PlayerPrefs.SetInt("cable_Rouge",0);
		PlayerPrefs.SetInt("cable_Vert",0);
        PlayerPrefs.SetInt("grilleReset",1);
	}
    
}
