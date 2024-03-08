using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacherMono_YoutubeVideo : A_FunctionScratchBlockableMono, I_TriggerByOnInspectorFocusInOut
{
    public string m_youtubeUrl= "www.youtube.com/watch?v=dQw4w9WgXcQ";
    public string m_youtubeVideoId;
    public ThumbnailType m_thumbnailType = ThumbnailType._maxresdefault;
    public enum ThumbnailType { _maxresdefault, _sddefault, _mqdefault, _hqdefault, _default }
    string m_youtubeFormat = "https://img.youtube.com/vi/{0}/maxresdefault.jpg";
    string m_youtubeFormat_maxresdefault = "https://img.youtube.com/vi/{0}/maxresdefault.jpg";
    string m_youtubeFormat_sddefault = "https://img.youtube.com/vi/{0}/sddefault.jpg";
    string m_youtubeFormat_mqdefault = "https://img.youtube.com/vi/{0}/mqdefault.jpg";
    string m_youtubeFormat_hqdefault = "https://img.youtube.com/vi/{0}/hqdefault.jpg";
    string m_youtubeFormat_default = "https://img.youtube.com/vi/{0}/default.jpg";

    private void OnValidate()
    {
        CheckFormatOfProjectId();
    }
    private void CheckFormatOfProjectId()
    {

        //https://youtu.be/lp8iWwGGlBU
        if (m_youtubeUrl.ToLower().IndexOf("youtu.") > -1)
        {

            string[] token = m_youtubeUrl.Trim().Trim('/').Split('/');
            if (token.Length > 0)
                m_youtubeVideoId = token[token.Length - 1];
        }
        else {
            string[] token = m_youtubeUrl.Split('=');
            if (token.Length > 0)
                m_youtubeVideoId = token[token.Length - 1];
        }
        
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        BasicTeacherHelpEditorMono.S_SetSlide(string.Format(GetFormat(m_thumbnailType), m_youtubeVideoId));
        BasicTeacherHelpEditorMono.S_SetSlideRedirectionUrl( m_youtubeUrl);
    }

    private string GetFormat(ThumbnailType type)
    {
        switch (type)
        {
            case ThumbnailType._maxresdefault: return m_youtubeFormat_maxresdefault;
            case ThumbnailType._sddefault:return m_youtubeFormat_sddefault;
            case ThumbnailType._mqdefault: return m_youtubeFormat_mqdefault;
            case ThumbnailType._hqdefault: return m_youtubeFormat_hqdefault;
            case ThumbnailType._default: return m_youtubeFormat_default;
            default: return m_youtubeFormat_maxresdefault;
        }
    }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            DoTheScratchableStuffWithoutCoroutine();
        else BasicTeacherHelpEditorMono.OnlyAvatar();
    }

    public void OpenYoutubeUrl()
    {
        Application.OpenURL(m_youtubeUrl);
    }
}

