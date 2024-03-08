using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacher_OnEventMono : MonoBehaviour
{

    public UnityEvent m_onAwake;
    private void Awake()
    {
        m_onAwake.Invoke();

    }

    public UnityEvent m_onStart;
    void Start()
    {
        m_onStart.Invoke();

    }

    public UnityEvent m_onEnable;
    public void OnEnable()
    {
        m_onEnable.Invoke();
    }
    public UnityEvent m_onDisable;
    public void OnDisable()
    {
        m_onDisable.Invoke();

    }
    public UnityEvent m_onDestroy;
    public void OnDestroy()
    {

        m_onDestroy.Invoke();

    }
    
}
