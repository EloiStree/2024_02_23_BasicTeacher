using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_SetImageMono : MonoBehaviour
{

    public Texture2D m_lastReceived;
    public GameObject m_toSetActive;
    public UnityEngine.UI.AspectRatioFitter m_ratio;
    public UnityEngine.UI.RawImage m_rawImage;
    public Texture2D m_defaultTextureIfEmpty;
    
    public void SetWithTexture(Texture2D texture) {
        m_lastReceived = texture;
        if (m_toSetActive)
        m_toSetActive.SetActive(texture!=null);

        if (texture)
        {
            if (m_ratio)
                m_ratio.aspectRatio = texture.width / (float)texture.height;


            if (m_rawImage)
                m_rawImage.texture = texture;
        }
       else
        {
            if (m_ratio)
                m_ratio.aspectRatio = 1;


            if (m_rawImage)
                m_rawImage.texture = m_defaultTextureIfEmpty;
        }
    }
}
