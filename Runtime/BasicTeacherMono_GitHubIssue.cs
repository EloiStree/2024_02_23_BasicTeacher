using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacherMono_GitHubIssue : A_FunctionScratchBlockableMono, I_TriggerByOnInspectorFocusInOut
{
    public string m_gitHubIssueUrl = "https://github.com/EloiStree/HelloRC/issues/1";
    public string m_issueIndex = "";
    public string m_accountName = "";
    public string m_projectName = "";

    private void OnValidate()
    {
        CheckFormatOfProjectId();
    }

    public void OpenGitHubIssueInInspector()
    {
        Application.OpenURL(m_gitHubIssueUrl);
    }

    private void CheckFormatOfProjectId()
    {

        string[] token = m_gitHubIssueUrl.Trim('/').Split("/");
        if (token.Length > 4 && token[token.Length - 2] == "issues")
        {
            m_issueIndex = token[token.Length - 1];
            m_projectName = token[token.Length - 3];
            m_accountName = token[token.Length - 4];
        }
        else if (token.Length > 4 )
        {
            // If you are here it means that GitHub change the issues or that you did not give the good url.
            m_issueIndex = token[token.Length - 1];
            m_projectName = token[token.Length - 3];
            m_accountName = token[token.Length - 4];
        }

    }

    public void OpenGitHubMostCommentedIssues()
    {
        string format = "https://github.com/{0}/{1}/issues?q=sort%3Acomments-desc";
       
        Application.OpenURL(string.Format(format, m_accountName, m_projectName));
    }
    public void OpenGitHubNewestIssues()
    {
        string format = "https://github.com/{0}/{1}/issues?q=sort%3Acreated-desc+";
        Application.OpenURL(string.Format(format, m_accountName, m_projectName));
    }
    public void OpenGitHubLandingIssues()
    {
        string format = "https://github.com/{0}/{1}/issues/1";
        Application.OpenURL(string.Format(format, m_accountName, m_projectName));
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        BasicTeacherHelpEditorMono.S_SetSlide(TryToFindImageInTheIssueMainPost());

        BasicTeacherHelpEditorMono.S_SetSlideRedirectionUrl(m_gitHubIssueUrl);

    }

    private string TryToFindImageInTheIssueMainPost()
    {
        return "";
    }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            DoTheScratchableStuffWithoutCoroutine();
        else BasicTeacherHelpEditorMono.OnlyAvatar();
    }

}

