using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(BasicTeacher_OnInspectorFocusInOut))]
public class BasicTeacherMono_Commentary : A_CoroutineScratchBlockableMono,I_TriggerByOnInspectorFocusInOut
{

    public string m_keywords;
    [TextArea(0, 8)]
    public string m_commentary;
    public MoreAboutIt m_moreAboutit;

    [System.Serializable]
    public class MoreAboutIt
    {
        [TextArea(0, 20)]
        public string m_quickText;
        public TextAsset m_permanentFile;
        public string m_asMarkdownOnTheWeb;
    }
    public bool m_editObjectName=true;

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {

            BasicTeacherHelpEditorMono.TeacherInScene.SetConsoleAsDisplay(true);
            BasicTeacherHelpEditorMono.TeacherInScene.SetText(m_commentary);
        }
    }
    public void RemoveCommentary() {
        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.SetConsoleAsDisplay(false);
            BasicTeacherHelpEditorMono.TeacherInScene.SetText("");
        }
    }
    public void OnValidate()
    {
        if (m_editObjectName &&  !string.IsNullOrEmpty(m_keywords))
            gameObject.name = "Commentary: " + m_keywords;
        if (GetComponent<BasicTeacher_OnInspectorFocusInOut>() == null)
            this.gameObject.AddComponent<BasicTeacher_OnInspectorFocusInOut>();
    }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            PushCommentary();
        else RemoveCommentary();
    }
}

public class BasicTeacherMono_ProposeSetupClipboard : A_CoroutineScratchBlockableMono
{

    public string m_proposeClipboard;

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.ProposeClipboard(m_proposeClipboard);
        }
    }
}
