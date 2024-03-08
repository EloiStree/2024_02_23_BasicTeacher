using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class BasicTeacherHelpEditorMono : MonoBehaviour
{

    [Tooltip("In case by accident there are several teacher in the scene.")]
    public float m_percentOfPriorityOnOtherTeacher = 0.5f;
    private static BasicTeacherHelpEditorMono m_teacherInScene;

    public static void S_SetSlide(string slideUrl)
    {
        if (slideUrl == null)
            slideUrl = "";
        if (TeacherInScene)
            TeacherInScene.SetSlideWithUrl(slideUrl);
    }

    public static void S_SetSlideRedirectionUrl(string slideUrl)
    {
        if (slideUrl == null)
            slideUrl = "";
        if (TeacherInScene)
            TeacherInScene.SetSlideRedirectionUrl(slideUrl);
    }

    private void SetSlideRedirectionUrl(string slideUrl)
    {
        m_requestToChangeSlideRedirectionUrl.Invoke(slideUrl);
    }

    public static void S_SetSlide(Texture2D slideUrl)
    {
        if (TeacherInScene)
            TeacherInScene.SetSlide(slideUrl);
    }
    public static void S_SetBackground(string slideUrl)
    {
        if (TeacherInScene)
            TeacherInScene.SetBackgroundWithUrl(slideUrl);
    }
    public static void S_SetBackground(Texture2D slideUrl)
    {
        if (TeacherInScene)
            TeacherInScene.SetBackground(slideUrl);
    }

    public static BasicTeacherHelpEditorMono[] m_teachersInScene;

    public static BasicTeacherHelpEditorMono TeacherInScene
    {
        get {
            if (m_teacherInScene == null || !Application.isPlaying) {
                m_teachersInScene = FindActiveMonoBehaviours().ToArray();
                if (m_teachersInScene.Length > 0)
                    m_teacherInScene = m_teachersInScene[0];
            }

            return m_teacherInScene;
        
        }
        set { m_teacherInScene = value; }
    }

    // Function to find active MonoBehaviours in the scene
    public static List<BasicTeacherHelpEditorMono> FindActiveMonoBehaviours()
    {
        List<BasicTeacherHelpEditorMono> activeMonoBehaviours = new List<BasicTeacherHelpEditorMono>();

        // Iterate through all GameObjects in the scene
        foreach (var itemScript in GameObject.FindObjectsOfType<BasicTeacherHelpEditorMono>())
        {
            // Check if the GameObject is active in the scene and not a prefab

            bool isPrefab = false;

#if UNITY_EDITOR
            isPrefab =  UnityEditor.PrefabUtility.IsPartOfPrefabAsset(itemScript.gameObject);
#endif
            if (itemScript.gameObject.activeInHierarchy && !isPrefab)
            {
                // Get all MonoBehaviours attached to the GameObject
                var monoBehaviours = itemScript.GetComponents<BasicTeacherHelpEditorMono>();

                // Check each MonoBehaviour
                foreach (var scriptEnable in monoBehaviours)
                {
                    // Add active MonoBehaviours to the list
                    if (scriptEnable.enabled)
                    {
                        activeMonoBehaviours.Add(scriptEnable);
                    }
                }
            }
           
        }
        activeMonoBehaviours = activeMonoBehaviours.OrderByDescending(k=>k.m_percentOfPriorityOnOtherTeacher).ToList();
        return activeMonoBehaviours;
    }

    public static void OnlyAvatar()
    {
        if (TeacherInScene != null)
            TeacherInScene.ResetToAvatarOnly();
    }

    public void ResetToAvatarOnly()
    {
        RemoveBackground();
        RemoveSlide();
        RemoveTextInConsole();
        HideConsole();
    }

    public void HideConsole()
    {
        SetConsoleAsDisplay(false);
    }

    public void RemoveTextInConsole()
    {
        SetText("");
    }

    public UnityEvent<string> m_onTextChanged;
    public UnityEvent<string> m_onIntCmdReceived;
    public UnityEvent<Color> m_onColorTextChanged;
    public UnityEvent<Color> m_onColorConsoleChanged;
    public UnityEvent<bool> m_onRequestDisplayConsole;
    public UnityEvent<string []> m_onProposeUrlsForConsole;
    public UnityEvent<string> m_onProposeClipboardForConsole;
    public UnityEvent<bool> m_onRequestDisplayTeacher;
    public UnityEvent<Texture2D> m_onNewBackground;
    public UnityEvent<string> m_onNewBackgroundFromUrl;
    public UnityEvent<Texture2D> m_requestToDisplaySlide;
    public UnityEvent<string> m_requestToDisplaySlideFromWebUrl;
    public UnityEvent<string> m_requestToChangeSlideRedirectionUrl;
    public UnityEvent<Texture2D> m_requestToChangeAvatar;
    public UnityEvent<string> m_requestToChangeAvatarFromWebUrl;

    internal void ProposeWebsites(params string [] urls)
    {
        m_onProposeUrlsForConsole.Invoke(urls);
    }

    internal void ProposeClipboard(string textForClipboards)
    {
        m_onProposeClipboardForConsole.Invoke(textForClipboards);
        //Temporary
        if(!string.IsNullOrEmpty(textForClipboards))
            GUIUtility.systemCopyBuffer = textForClipboards;
    }




    public void SetAvatar(Texture2D image)
    {
        m_requestToChangeAvatar.Invoke(image);
    }
    public void SetAvatar(string url )
    {
        m_requestToChangeAvatarFromWebUrl.Invoke(url);
    }
    public void SetSlideWithUrl(string url)
    {
        m_requestToDisplaySlideFromWebUrl.Invoke(url);
    }
    public void SetBackgroundWithUrl(string url)
    {
        m_onNewBackgroundFromUrl.Invoke(url);
    }
    public void SetSlide(Texture2D image)
    {
        m_requestToDisplaySlide.Invoke(image);
    }
    public void SetBackground(Texture2D image)
    {
        m_testB = image;
        m_onNewBackground.Invoke(image);
    }
    public Texture2D m_testB;

    public void SetText(string text)
    {
        m_onTextChanged.Invoke(text);
    }
    public void NotifyIntCmdReceived(int intCmd)
    {
        NotifyIntCmdReceived(intCmd.ToString());
    }
    public void NotifyIntCmdReceived(string text)
    {
        m_onIntCmdReceived.Invoke(text);
    }
    public void SetColor(string text)
    {
        m_onTextChanged.Invoke(text);
    }
    public void SetColor(Texture2D textureImage)
    {
        m_onNewBackground.Invoke(textureImage);
    }
    public void SetConsoleAsDisplay(bool consoleIsDisplay)
    {
        m_onRequestDisplayConsole.Invoke(consoleIsDisplay);
    }
    public void SetTeacherAsDisplay(bool consoleIsDisplay)
    {
        m_onRequestDisplayTeacher.Invoke(consoleIsDisplay);
    }
    [ContextMenu("Remove Background")]
    public void RemoveBackground()
    {
        m_onNewBackground.Invoke(null);
    }
    [ContextMenu("Remove Slide")]
    public void RemoveSlide()
    {
        m_requestToDisplaySlide.Invoke(null);
    }

    private void OnValidate()
    {
        TeacherInScene = this;
    }
    private void Awake()
    {
        if (TeacherInScene == null)
            TeacherInScene = this;
        else if (TeacherInScene.m_percentOfPriorityOnOtherTeacher<this.m_percentOfPriorityOnOtherTeacher)
        {
            TeacherInScene = this;
        }
    }


    [ContextMenu("Push Random Value")]
    public void PushRandomValue() {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
            BasicTeacherHelpEditorMono.TeacherInScene.SetText(UnityEngine.Random.Range(0, 99999999).ToString());
        else Debug.Log("No teacher in the scene");
    }
}
