using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animation))]

public class InteractivePistons : InteractiveObject
{
    public int valCube;
    private int[] bonneCouleur=new int[6];

    public enum eInteractiveState
    {
        Blanc,
        Rouge,     
        Violet,
        Jaune,
        Bleu,
        Vert,
        Orange     
    }

    public eInteractiveState m_State;
    private string[] m_AnimNames;

    
    public override void Start()
    {
        string v = "";
        for (int i = 0; i < 6; i++)
        {
            v = "valeurCube" + i;
            PlayerPrefs.SetInt(v, 0);
            Debug.Log(PlayerPrefs.GetInt(v));
        }
        m_State = eInteractiveState.Blanc;
        Debug.Log(GetComponent<Animation>().GetClipCount());
        m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
        Debug.Log(m_AnimNames.Length);
        int index = 0;
        foreach (AnimationState anim in GetComponent<Animation>())
        {
            m_AnimNames[index] = anim.name;
            Debug.Log(anim.name);
            index++;
        }
        for(int i = 0; i < 6; i++)
        {
            bonneCouleur[i] = 0;
        }
    }
    public bool gagne()
    {
        for (int i = 0; i < 6; i++)
        {
            if (bonneCouleur[i] == 0)
                return false;
        }
        return true;
    }
    //ici le code à executer quand on interagit avec l'objet
    public override void TriggerInteraction()
    {
        int value;
        string v = "";
        for (int ii = 0; ii < 6; ii++)
        {
            v = "valeurCube" + ii;
            bonneCouleur[ii]=PlayerPrefs.GetInt(v);
           //Debug.Log(v + " " + bonneCouleur[ii]);
        }
        if (gagne())
        {
            Debug.Log("GAGNE");
        }
        else
        {
            //si aucune animation n'est en execution
            if (!GetComponent<Animation>().isPlaying)
            {
                //on choisit quelle animation executer
                switch (m_State)
                {
                    case eInteractiveState.Blanc:
                        if (valCube == 5)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[0]);
                        m_State = eInteractiveState.Rouge;
                        break;
                    case eInteractiveState.Rouge:
                        if (valCube == 0)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        if (valCube == 5)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[1]);
                        m_State = eInteractiveState.Violet;
                        break;
                    case eInteractiveState.Violet:
                        if (valCube == 0)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        if (valCube == 3)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[2]);
                        m_State = eInteractiveState.Jaune;
                        break;
                    case eInteractiveState.Jaune:
                        if (valCube == 1)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        if (valCube == 3)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[3]);
                        m_State = eInteractiveState.Bleu;
                        break;
                    case eInteractiveState.Bleu:
                        if (valCube == 1)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        if (valCube == 2)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[4]);
                        m_State = eInteractiveState.Vert;
                        break;
                    case eInteractiveState.Vert:
                        if (valCube == 2)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        if (valCube == 4)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[5]);
                        m_State = eInteractiveState.Orange;
                        break;
                    case eInteractiveState.Orange:
                        if (valCube == 4)
                        {
                            bonneCouleur[valCube] = 0;
                        }
                        if (valCube == 5)
                        {
                            bonneCouleur[valCube] = 1;
                        }
                        GetComponent<Animation>().Play(m_AnimNames[6]);
                        m_State = eInteractiveState.Rouge;
                        break;
                    default:
                        break;
                }
               
                for (int i = 0; i < 6; i++)
                {
                    v = "valeurCube" + i;
                    PlayerPrefs.SetInt(v, bonneCouleur[i]);
                }
            }
        }
    }
}
