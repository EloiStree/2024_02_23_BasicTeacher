using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacherMono_OpenUrl : MonoBehaviour
{
    public string m_url;

    public void SetUrl(string url) { m_url = url; }
    public void OpenUrl(string url) { Application.OpenURL(url); }
    [ContextMenu("Open Url")]
    public void OpenUrlInInspector() { Application.OpenURL(m_url); }
}
