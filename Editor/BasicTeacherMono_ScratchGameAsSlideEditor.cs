using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BasicTeacherMono_ScratchGameAsSlide))]
class BasicTeacherMono_ScratchGameAsSlideEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("Play the game"))
        {
            BasicTeacherMono_ScratchGameAsSlide script = (BasicTeacherMono_ScratchGameAsSlide)target;
            script.OpenGameUrl();
        }
        if (GUILayout.Button("Edit the game"))
        {
            BasicTeacherMono_ScratchGameAsSlide script = (BasicTeacherMono_ScratchGameAsSlide)target;
            script.OpenGameInEditorUrl();
        }
    }
}
