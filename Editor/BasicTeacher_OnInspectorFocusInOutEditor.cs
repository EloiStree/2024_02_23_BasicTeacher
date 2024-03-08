using System.Diagnostics;
using UnityEditor;

[CustomEditor(typeof(BasicTeacher_OnInspectorFocusInOut))]
public class BasicTeacher_OnInspectorFocusInOutEditor : Editor
{
    BasicTeacher_OnInspectorFocusInOut script;

    void OnEnable()
    {
        script = (BasicTeacher_OnInspectorFocusInOut)target;
        EditorApplication.update += UpdateStatus;
       
    }

    void OnDisable()
    {
        EditorApplication.update -= UpdateStatus;
    }


    public static bool m_currentFocus;
    public static bool m_previousFocus;
    public static BasicTeacher_OnInspectorFocusInOut m_currentFocusScript;
    public static BasicTeacher_OnInspectorFocusInOut m_previousFocusScript;
    public override void OnInspectorGUI()
    {
        UpdateStatus();
        base.OnInspectorGUI();
    }

    private void UpdateStatus()
    {
        script = (BasicTeacher_OnInspectorFocusInOut)target;
       
        m_currentFocus = Selection.activeObject == script.gameObject;
        if (m_previousFocus!=m_currentFocus)
        {
            m_previousFocusScript = m_currentFocusScript ;
            m_currentFocusScript = script;
            if (m_previousFocus)
                script.NotifyFocusExit();

            if (m_currentFocus)
                script.NotifyFocusEnter();
            m_previousFocus = m_currentFocus;
        }
    }
}