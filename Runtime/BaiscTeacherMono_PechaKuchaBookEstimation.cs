using UnityEngine;

[RequireComponent(typeof(BasicTeacher_OnInspectorFocusInOut))]
public class BaiscTeacherMono_PechaKuchaBookEstimation : MonoBehaviour, I_TriggerByOnInspectorFocusInOut
{
    public BasicTeacherMono_Book m_source;
    public float m_timePerSlide = 20;
    public string m_duration;
    public float m_durationInSeconds;
    public int m_slideToPlay;

    public void Reset()
    {
        m_source = GetComponent<BasicTeacherMono_Book>();
        RefreshFromSource();
    }
    private void OnValidate()
    {
        RefreshFromSource();
    }

    private void RefreshFromSource()
    {
        if (m_source == null)
        {
            return;
        }
        m_source.RefreshPagesInBook();
        m_slideToPlay = m_source.GetPageCount();
        m_durationInSeconds = m_slideToPlay * m_timePerSlide;
        int seconds = (int)(m_durationInSeconds % 60f);
        int minute = (int)(m_durationInSeconds / 60f);
        if (minute > 0) m_duration = $"{minute}M {seconds} ";
        else m_duration = $"{seconds} Seconds";
    }

    public void SetPechaKuchaTimingToDefault() { m_timePerSlide = 20; }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            RefreshFromSource();
    }
}

