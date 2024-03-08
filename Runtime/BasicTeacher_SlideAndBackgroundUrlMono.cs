using UnityEngine;

public class BasicTeacher_SlideAndBackgroundUrlMono : A_FunctionScratchBlockableMono, I_TriggerByOnInspectorFocusInOut
{
    public string m_textureToShowUrl;
    public DisplayType m_displayType;

    public enum DisplayType
    {
        Slide, Background
    }



    [ContextMenu("Push")]
    public void Push()
    {

        BasicTeacherHelpEditorMono teacher = BasicTeacherHelpEditorMono.TeacherInScene;
        if (teacher)
        {
            if (m_displayType == DisplayType.Background)
                teacher.SetBackgroundWithUrl(m_textureToShowUrl);

            else if (m_displayType == DisplayType.Slide)
                teacher.SetSlideWithUrl(m_textureToShowUrl);
        }
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        Push();
    }

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            Push();
        else BasicTeacherHelpEditorMono.OnlyAvatar();
    }
}
