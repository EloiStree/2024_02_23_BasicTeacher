using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_ChangeAvatarMono : A_FunctionScratchBlockableMono
{
    public Texture2D m_avatarTexture;
 

    [ContextMenu("Push")]
    public void Push() {

        BasicTeacherHelpEditorMono  teacher = BasicTeacherHelpEditorMono.TeacherInScene;
        if (teacher)
        {
                teacher.SetAvatar(m_avatarTexture);
        }
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        Push();
    }
   
}
