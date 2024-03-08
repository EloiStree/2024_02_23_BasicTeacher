using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BasicTeacherMono_Chapter))]
class BasicTeacherMono_ChapterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New Chapter Children"))
        {
            GameObject newObject = new GameObject("Empty Chapter");
            MonoBehaviour script = (MonoBehaviour)target;
            newObject.transform.parent = script.transform;
            newObject.AddComponent<BasicTeacher_OnInspectorFocusInOut>();
            newObject.AddComponent<BasicTeacherMono_Chapter>();
            newObject.AddComponent<BasicTeacherMono_CommentaryNoRename>();

        }
        if (GUILayout.Button("New Chapter Following"))
        {
            GameObject newObject = new GameObject("Empty Chapter");
            MonoBehaviour script = (MonoBehaviour)target;
            newObject.transform.parent = script.transform.parent;
            newObject.AddComponent<BasicTeacher_OnInspectorFocusInOut>();
            newObject.AddComponent<BasicTeacherMono_Chapter>();
            newObject.AddComponent<BasicTeacherMono_CommentaryNoRename>();
        }
        if (GUILayout.Button("New page"))
        {
            GameObject newObject = new GameObject("Empty Page");
            MonoBehaviour script = (MonoBehaviour)target;
            newObject.transform.parent = script.transform;

            newObject.AddComponent<BasicTeacher_OnInspectorFocusInOut>();
            newObject.AddComponent<BasicTeacherMono_Page>();
            newObject.AddComponent<BasicTeacherMono_CommentaryNoRename>();
        }
        GUILayout.EndHorizontal();
    }
}


