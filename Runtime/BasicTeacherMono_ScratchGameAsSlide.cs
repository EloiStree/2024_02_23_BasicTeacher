using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicTeacherMono_ScratchGameAsSlide : A_FunctionScratchBlockableMono, I_TriggerByOnInspectorFocusInOut
{
    public string m_projectUrl = "https://scratch.mit.edu/projects/960534356/";
    public string m_projectId = "";
    private string m_scratchFormat = "http://cdn.scratch.mit.edu/get_image/project/{0}_480x360.png ";
    private string m_scratchFormatEditorFormat = "https://scratch.mit.edu/projects/{0}/editor/";

    private void OnValidate()
    {
        CheckFormatOfProjectId();
    }

    public void OpenGameUrl()
    {
        Application.OpenURL(m_projectUrl);
    }

    private void CheckFormatOfProjectId()
    {
        
            string[] token = m_projectUrl.Trim('/').Split("/");
        if (token.Length > 0)
            m_projectId = token[token.Length - 1];
        if(m_projectId =="editor" && token.Length > 1)
            m_projectId = token[token.Length - 2];

        else m_projectId = "";
        
    }

    public void OpenGameInEditorUrl()
    {
        Application.OpenURL(string.Format(m_scratchFormatEditorFormat, m_projectId));
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        BasicTeacherHelpEditorMono.S_SetSlide(string.Format(m_scratchFormat, m_projectId));
        BasicTeacherHelpEditorMono.S_SetSlideRedirectionUrl(m_projectUrl);

    }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            DoTheScratchableStuffWithoutCoroutine();
        else BasicTeacherHelpEditorMono.OnlyAvatar();
    }

}
