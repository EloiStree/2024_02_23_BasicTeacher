using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacher_ActionOnFocus : A_ScratchBlockableMono
{

    public string m_context;
    public bool m_isActive;
    public GameObject m_highlighTargetObject;
    public UnityEvent m_relayActions;
 
    public override IEnumerator DoTheScratchableStuff()
    {


        DoTheScratchableStuffWithoutCoroutine();
         yield return null;
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        if (m_isActive)
        {
            if (m_highlighTargetObject)
            {
                Debug.Log("More information on this object:" + m_highlighTargetObject.name, m_highlighTargetObject);

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(m_highlighTargetObject.transform.position, m_highlighTargetObject.transform.localScale);
            }
        }
    }
}