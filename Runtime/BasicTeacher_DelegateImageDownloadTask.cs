using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacher_DelegateImageDownloadTask : MonoBehaviour
{
    public string m_lastUrl;
    public Texture2D m_lastTextureSubmit;
    public UnityEvent<string> m_receivedImageToDownload;
    public UnityEvent<Texture2D> m_onDownloadedImageProposed;


    [ContextMenu("Re push previous")]
    public void PushImageToDownload()
    {

        PushImageToDownload(m_lastUrl);
    }
    public void PushImageToDownload(string pathOrUrl)
    {
        m_lastUrl = pathOrUrl;
        m_receivedImageToDownload.Invoke(pathOrUrl);
    }

    public void SubmitImageFound(Texture2D image) {
        m_lastTextureSubmit = image;
        m_onDownloadedImageProposed.Invoke(image);
    }
}
