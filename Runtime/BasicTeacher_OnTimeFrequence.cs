using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacher_OnTimeFrequence : MonoBehaviour
{
    public UnityEvent OnTick1Second;
    public UnityEvent OnTick5Seconds;
    public UnityEvent OnTick10Seconds;
    public UnityEvent OnTick30Seconds;
    public UnityEvent OnTick60Seconds;

    
    private void Start()
    {
        InvokeRepeating(nameof(TriggerTick1Second), 0f, 1f);
        InvokeRepeating(nameof(TriggerTick5Seconds), 0f, 5f);
        InvokeRepeating(nameof(TriggerTick10Seconds), 0f, 10f);
        InvokeRepeating(nameof(TriggerTick30Seconds), 0f, 30f);
        InvokeRepeating(nameof(TriggerTick60Seconds), 0f, 60f);
    }

    private void TriggerTick1Second()
    {
        OnTick1Second?.Invoke();
    }

    private void TriggerTick5Seconds()
    {
        OnTick5Seconds?.Invoke();
    }

    private void TriggerTick10Seconds()
    {
        OnTick10Seconds?.Invoke();
    }

    private void TriggerTick30Seconds()
    {
        OnTick30Seconds?.Invoke();
    }

    private void TriggerTick60Seconds()
    {
        OnTick60Seconds?.Invoke();
    }
}