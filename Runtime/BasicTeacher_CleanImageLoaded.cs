using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_CleanToAvatarOnly:A_FunctionScratchBlockableMono
{

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        BasicTeacherHelpEditorMono.TeacherInScene.ResetToAvatarOnly();
    }
}
