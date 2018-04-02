using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animation))]

public class InteractivePuzzle : InteractiveObject
{
    public int valCube;

    public enum eInteractiveState
    {
        SelectO,
        SelectN
    }

    public eInteractiveState m_State;
    private string[] m_AnimNames;


    public override void Start()
    {
        string selected = "selected";
        PlayerPrefs.SetInt(selected, 0);

        string ok = "ok";
        PlayerPrefs.SetInt(ok, 0);

        m_State = eInteractiveState.SelectN;
        Debug.Log(GetComponent<Animation>().GetClipCount());
        m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
        int index = 0;
        foreach (AnimationState anim in GetComponent<Animation>())
        {
            m_AnimNames[index] = anim.name;
            index++;
        }
    }
    public void Update()
    {
        string pX2 = "positionX2";
        string pY2 = "positionY2";
        string pZ2 = "positionZ2";
        string ok = "ok";
        string valeurCube = "valCube";
        string s = "selected";
        if (PlayerPrefs.GetInt(ok) == 1 && valCube== PlayerPrefs.GetInt(valeurCube) && PlayerPrefs.GetInt(s) == 1)
        {
            Vector3 temp = new Vector3(PlayerPrefs.GetFloat(pX2), PlayerPrefs.GetFloat(pY2), PlayerPrefs.GetFloat(pZ2));
            transform.position = temp;
            string positionX = "positionX";
            string positionY = "positionY";
            string positionZ = "positionZ";
            PlayerPrefs.SetFloat(positionX, transform.position.x);
            PlayerPrefs.SetFloat(positionY, transform.position.y);
            PlayerPrefs.SetFloat(positionZ, transform.position.z);
            GetComponent<Animation>().Play(m_AnimNames[1]);
            string selected = "selected";
            PlayerPrefs.SetInt(ok, 0);
            PlayerPrefs.SetInt(selected, 0);
            PlayerPrefs.SetInt(valeurCube, -1);
            m_State = eInteractiveState.SelectN;

        }
        
    }

    //ici le code à executer quand on interagit avec l'objet
    public override void TriggerInteraction()
    {
        //si aucune animation n'est en execution
        if (!GetComponent<Animation>().isPlaying)
        {
            //on choisit quelle animation executer
            switch (m_State)
            {
                case eInteractiveState.SelectN:
                    
                    string selected = "selected";
                    if (PlayerPrefs.GetInt(selected) == 0)
                    {
                        PlayerPrefs.SetInt(selected, 1);
                        string positionX = "positionX";
                        string positionY = "positionY";
                        string positionZ = "positionZ";
                        string valeurCube = "valCube";
                        PlayerPrefs.SetFloat(positionX, transform.position.x);
                        PlayerPrefs.SetFloat(positionY, transform.position.y);
                        PlayerPrefs.SetFloat(positionZ, transform.position.z);
                        PlayerPrefs.SetInt(valeurCube, valCube);
                        m_State = eInteractiveState.SelectO;
                        GetComponent<Animation>().Play(m_AnimNames[0]);
                    }
                    else
                    {       
                            string positionX = "positionX";
                            string positionY = "positionY";
                            string positionZ = "positionZ";
                            string positionX2 = "positionX2";
                            string positionY2 = "positionY2";
                            string positionZ2 = "positionZ2";
                            string ok = "ok";
                            PlayerPrefs.SetInt(ok, 1);
                            PlayerPrefs.SetFloat(positionX2, transform.position.x);
                            PlayerPrefs.SetFloat(positionY2, transform.position.y);
                            PlayerPrefs.SetFloat(positionZ2, transform.position.z);
                            Vector3 temp = new Vector3(PlayerPrefs.GetFloat(positionX), PlayerPrefs.GetFloat(positionY), PlayerPrefs.GetFloat(positionZ));
                            transform.position = temp;
                            
                    }
                    break;
                case eInteractiveState.SelectO:
                    GetComponent<Animation>().Play(m_AnimNames[1]);
                    m_State = eInteractiveState.SelectN;
                    break;
                default:
                    break;
            }
        }
    }
}
