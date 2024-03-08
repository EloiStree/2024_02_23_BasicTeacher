using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacherMono_Chapter : MonoBehaviour
{
    public string m_title;

    public Events m_events;
    [System.Serializable]
    public class Events
    {

        public UnityEvent<bool> m_onFocus;
        public UnityEvent m_onFocusEnter;
        public UnityEvent m_onFocusExit;
    }
    [ContextMenu("Notify as focused")]
    public void SetAsFocusedTrue() => SetAsFocused(true);
    [ContextMenu("Notify as not focused")]
    public void SetAsFocusedFalse() => SetAsFocused(false);
    public void SetAsFocused(bool isPageFocus)
    {
        m_events.m_onFocus.Invoke(isPageFocus);
        m_events.m_onFocusEnter.Invoke();
        m_events.m_onFocusExit.Invoke();
    }
    private void OnValidate()
    {
        gameObject.name = "Chapter: " + m_title;
    }
}
