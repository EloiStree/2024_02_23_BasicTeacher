using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicTeacherMono_Book : MonoBehaviour
{
    public string m_bookName;   
    public int m_currentPageIndex;
    public List<BasicTeacher_OnInspectorFocusInOut> m_pages;
    public BasicTeacher_OnInspectorFocusInOut m_previousPage;
    public BasicTeacher_OnInspectorFocusInOut m_currentPage;
    public bool m_loop;
    public bool m_refreshBookAtAwake=true;
    public void GoAtPageIndex(int pageIndex)
    {
        if (m_pages.Count<1)
            return;
        if (m_loop)
            pageIndex = Mathf.Clamp(pageIndex, 0, m_pages.Count - 1);
        else
        {
            if (pageIndex < 0)
                pageIndex = m_pages.Count - 1;
            if (pageIndex >= m_pages.Count)
                pageIndex = 0;
        }
        m_currentPageIndex = pageIndex;
        m_currentPage = m_pages[pageIndex];
        m_previousPage = m_currentPage;
        if(m_previousPage)
            m_previousPage.NotifyAsFocus(false);
        if (m_currentPage)
            m_currentPage.NotifyAsFocus(true);
    }

    public int GetPageCount()
    {
        return m_pages.Count;
    }

    private void OnValidate()
    {
        gameObject.name = "Book: " + m_bookName;
    }
    public void GoAtPageIndexInInspector()
    {
        GoAtPageIndex(m_currentPageIndex);

    }
    [ContextMenu("Next Page")]
    public void NextPage()
    {
        m_currentPageIndex++;
        GoAtPageIndexInInspector();
    }

    [ContextMenu("Previous Page")]
    public void PreviousPage()
    {
        m_currentPageIndex--;
        GoAtPageIndexInInspector();

    }
    private void Awake()
    {
        if (m_refreshBookAtAwake)
            RefreshPagesInBook();
    }

    [ContextMenu("Refresh Page")]
    public void RefreshPagesInBook() {
        GetComponentsInChildren(m_pages);
        m_pages= m_pages.Where(k => k.gameObject != this.gameObject).ToList();
    }
}


