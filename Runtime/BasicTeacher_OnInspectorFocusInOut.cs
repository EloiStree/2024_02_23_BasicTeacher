using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public interface I_TriggerByOnInspectorFocusInOut {
    public void SetAsFocused(bool isFocused);
}


public class BasicTeacher_OnInspectorFocusInOut : MonoBehaviour
{

    public Toggle m_toggle= new Toggle();
    [System.Serializable]
    public class Toggle {
        public UnityEvent m_onFocusEnter;
        public UnityEvent m_onFocusLost;
        public List<A_ScratchBlockableMono> m_onFocusEnterBlock;
        public A_ScratchBlockableMono[] m_onFocusLostBlock;
        public bool m_forceCoroutineUse = false;
    }

    public void NotifyAsFocus(bool value) {
        if (value) NotifyFocusEnter();
        else NotifyFocusExit();

        
    }


    private void Reset()
    {
        RefreshListOfCurrentComponentAsActionEnter();
    }

    [ContextMenu("Set Focus Ener with near scratch blocks")]
    private void RefreshListOfCurrentComponentAsActionEnter()
    {
        if(m_toggle!=null)
        GetComponents<A_ScratchBlockableMono>(m_toggle.m_onFocusEnterBlock);
    }

    public void NotifyFocusEnter()
    {

        m_toggle.m_onFocusEnter.Invoke();
        ExecuteGivenBlock(m_toggle.m_onFocusEnterBlock);
        NotifyToNearScriptInterfaceTheFocusState(true);

    }
    public void NotifyToNearScriptInterfaceTheFocusState(bool isFocus) {
        foreach (var item in GetComponents<I_TriggerByOnInspectorFocusInOut>())
        {
            if (item != null)
                item.SetAsFocused(isFocus);
        }
    }

    public void NotifyFocusExit()
    {

        m_toggle.m_onFocusLost.Invoke();
        ExecuteGivenBlock(m_toggle.m_onFocusLostBlock);
        NotifyToNearScriptInterfaceTheFocusState(false);
    }
    public void Log(string message) { Debug.Log(message); }

    private void ExecuteGivenBlock(IEnumerable <A_ScratchBlockableMono > blocks)
    {
        if (blocks != null) { 
            foreach (var item in blocks)
            {
                if (m_toggle.m_forceCoroutineUse)
                {
                    StartCoroutine(item.DoTheScratchableStuff());
                }
                else
                {
                    item.ExecuteBlockAsDependingOfPlayMode();
                }
            }
        }
    }
}
