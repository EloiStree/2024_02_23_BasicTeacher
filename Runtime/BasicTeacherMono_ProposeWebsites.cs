using System.Collections;
using UnityEngine;

public class BasicTeacherMono_ProposeWebsites : A_CoroutineScratchBlockableMono
{

    public string[] m_proposedUrls;

    private void Reset()
    {
        m_proposedUrls = new string[4];
    }

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.ProposeWebsites(m_proposedUrls);
        }
    }

    [ContextMenu("Open the links")]
    public void OpenUrl() {
        foreach (var item in m_proposedUrls)
        {
            if(!string.IsNullOrWhiteSpace(item))
                Application.OpenURL(item);
        }
    }
}
