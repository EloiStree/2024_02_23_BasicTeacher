using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacherMono_SetSlideUrlRedirection :  A_FunctionScratchBlockableMono, I_TriggerByOnInspectorFocusInOut
{
    public string m_slideUrl;

    public void SetAsFocused(bool isFocused)
    {
        if (isFocused)
            DoTheScratchableStuffWithoutCoroutine();
        else BasicTeacherHelpEditorMono.OnlyAvatar();
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        BasicTeacherHelpEditorMono.S_SetSlideRedirectionUrl(m_slideUrl);
    }
}
