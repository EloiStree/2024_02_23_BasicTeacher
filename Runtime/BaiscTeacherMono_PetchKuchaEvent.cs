using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaiscTeacherMono_PetchKuchaEvent : MonoBehaviour
{

}
public class BaiscTeacherMono_PechaKuchaBookSlideExporter : MonoBehaviour
{

}

public class BaiscTeacherMono_PechaKuchaBookAudioClip : MonoBehaviour
{
    public AudioSource m_player;
    public AudioToPlay m_languageType;
    public AudioClip m_defaultAudio;
    
    public enum AudioToPlay { Default, English, French, Chinese, Spanish, Portuguese, Russian, Japonese}

    public OtherLanguage m_languages;
    [System.Serializable]
    public class OtherLanguage { 
        public AudioClip m_english;
        public AudioClip m_french;
        public AudioClip m_chinese;
        public AudioClip m_spanish;
        public AudioClip m_portuguese;
        public AudioClip m_russian;
        public AudioClip m_japonese;
    }

    private void Reset()
    {
        m_player = GetComponent<AudioSource>();
        if (m_player == null)
        {
           m_player= this.gameObject.AddComponent<AudioSource>();
        }    
    }
    [ContextMenu("Play audio")]
    public void PlayAudio()
    {
        m_player.clip = GetClip();
        m_player.Play();
    }

    private AudioClip GetClip()
    {
        switch (m_languageType)
        {
            case AudioToPlay.English:
                return m_languages.m_english;
            case AudioToPlay.French:
                return m_languages.m_french;
            case AudioToPlay.Chinese:
                return m_languages.m_chinese;
            case AudioToPlay.Spanish:
                return m_languages.m_spanish;
            case AudioToPlay.Portuguese:
                return m_languages.m_portuguese;
            case AudioToPlay.Russian:
                return m_languages.m_russian;
            case AudioToPlay.Japonese:
                return m_languages.m_japonese;
            default:
                return m_defaultAudio;
        }
    }

    [ContextMenu("Play stop")]
    public void PlayStop()
    {
        m_player.Stop();
    }

}

/// <summary>
/// Will play the PechaKucha in play mode and take a screenshot for each slide
/// </summary>
public class BaiscTeacherMono_PechaKuchaBookSlideScreenshotExporter : MonoBehaviour
{

}

