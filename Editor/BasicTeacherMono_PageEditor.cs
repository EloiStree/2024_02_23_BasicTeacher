using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BasicTeacherMono_Page))]
class BasicTeacherMono_PageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("New commentary"))
        {
            GameObject newObject = new GameObject("New Commentary");
            MonoBehaviour script = (MonoBehaviour)target;
            newObject.transform.parent = script.transform;
            newObject.AddComponent<BasicTeacher_OnInspectorFocusInOut>();
            newObject.AddComponent<BasicTeacherMono_Commentary>();
        }

    }
}


