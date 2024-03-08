using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTeacherMono_BookBuilder : MonoBehaviour
{

    [TextArea(0,20)]
    public string m_textForGeneration;
    public string [] m_linePerLine;
    public GameObject m_pagePrefab;
    public Transform m_whereToBuild;

   
    public void Build() { 
    
    }

    private void OnValidate()
    {
        if(m_textForGeneration!=null)
        m_linePerLine = m_textForGeneration.Split("\n");
    }
}
