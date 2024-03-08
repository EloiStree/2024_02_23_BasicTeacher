using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BasicTeacherMono_YoutubeVideo))]
class BasicTeacherMono_YoutubeVideoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("Watch the video")) {
            BasicTeacherMono_YoutubeVideo script = (BasicTeacherMono_YoutubeVideo)target;
            script.OpenYoutubeUrl();
        }
    }
}

