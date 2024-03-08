using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_Log : MonoBehaviour
{


    public void Log(string messsage)
    {

        Debug.Log(messsage);
    }
    public void LogWarning(string messsage)
    {

        Debug.LogWarning(messsage);
    }
    public void LogError(string messsage)
    {

        Debug.LogError(messsage);
    }
}
