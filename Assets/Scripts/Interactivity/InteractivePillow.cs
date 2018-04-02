using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePillow : MonoBehaviour
{
    private string[] m_AnimNames;
    public enum eInteractiveState
    {
        Corner,
        Center
    }

    public eInteractiveState m_State;
    // Use this for initialization
    void Start()
    {
        m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
        int index = 0;
        foreach (AnimationState anim in GetComponent<Animation>())
        {
            m_AnimNames[index] = anim.name;
            index++;
        }

    }
    void OnMouseDown()
    {
        Debug.Log("mouse down");
    }

    //ici le code à executer quand on interagit avec l'objet
    void OnSelect()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            //on choisit quelle animation executer
            switch (m_State)
            {
                case eInteractiveState.Corner:
                    GetComponent<Animation>().Play(m_AnimNames[0]);
                    m_State = eInteractiveState.Center;
                    break;
                case eInteractiveState.Center:
                    GetComponent<Animation>().Play(m_AnimNames[1]);
                    m_State = eInteractiveState.Corner;
                    break;

            }

        }

    }
}