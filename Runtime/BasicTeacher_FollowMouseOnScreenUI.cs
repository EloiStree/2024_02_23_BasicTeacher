using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_FollowMouseOnScreenUI : MonoBehaviour
{
    public RectTransform panelRectTransform;

    void Reset()
    {
        panelRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Convert mouse position to local coordinates
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            Input.mousePosition,
            null,
            out Vector2 localPoint
        );

        // Update panel position
        panelRectTransform.localPosition = localPoint;
    }
}
