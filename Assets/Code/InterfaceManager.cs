using UnityEngine;
using System;
using System.Collections.Generic;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;


    public List<InterfaceElement> m_InterfaceElements; 

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void OnInterfaceOpen(string _InterfaceName)
    {
        //ChangeCurrentActionMap
        ActiveInterface(_InterfaceName);
    }

    public void OnInterfaceClose()
    {
        //ChangeCurrentActionMap
        CloseInterface();
    }

    void ActiveInterface(string _InterfaceName)
    {
        foreach(InterfaceElement element in m_InterfaceElements)
        {
            if(element.gameObject.name == _InterfaceName)
            {
                if(element.m_ActiveInterface == false)
                {
                    element.OpenInterface();
                    element.m_ActiveInterface = true;
                }
            }

        }
    }

    void CloseInterface()
    {
        foreach(InterfaceElement element in m_InterfaceElements)
        {
            if (element.m_ActiveInterface)
            {
                element.m_ActiveInterface = false;
                element.CloseInterface();
            }
        }
    }

}

public class InterfaceElement : MonoBehaviour
{
    public bool m_ActiveInterface;

    public virtual void OpenInterface()
    {

    }
    public virtual void CloseInterface()
    {
    }
}