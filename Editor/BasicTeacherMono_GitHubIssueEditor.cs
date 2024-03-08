using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BasicTeacherMono_GitHubIssue))]
class BasicTeacherMono_GitHubIssueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("Read more about it"))
        {
            BasicTeacherMono_GitHubIssue script = (BasicTeacherMono_GitHubIssue)target;
            script.OpenGitHubIssueInInspector();
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Landing"))
        {
            BasicTeacherMono_GitHubIssue script = (BasicTeacherMono_GitHubIssue)target;
            script.OpenGitHubLandingIssues();
        }
        if (GUILayout.Button("Commented +"))
        {
            BasicTeacherMono_GitHubIssue script = (BasicTeacherMono_GitHubIssue)target;
            script.OpenGitHubMostCommentedIssues();
        }
        if (GUILayout.Button("Newest"))
        {
            BasicTeacherMono_GitHubIssue script = (BasicTeacherMono_GitHubIssue)target;
            script.OpenGitHubNewestIssues();
        }
        GUILayout.EndHorizontal();
    }
}

