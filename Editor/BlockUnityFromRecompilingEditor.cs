using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BlockUnityFromRecompilingEditor : MonoBehaviour
{
    public static string m_path= "Assets/temp/BlockUnityCompiler.cs";
    [MenuItem("ꬲ🧰/C#/Block Unity Compiler %w")]  // % represents Ctrl on Windows
    private static void OpenWindow()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(m_path));
        File.WriteAllText(m_path, "public class A{Moook voyer // https://www.youtube.com/watch?v=dQw4w9WgXcQ }");
        AssetDatabase.Refresh();
    }

    [MenuItem("ꬲ🧰/C#/Unclock Unity Compiler %&w")]  // %& represents Ctrl+Alt on Windows
    private static void DoSomethingCtrlAltW()
    {

        Directory.CreateDirectory(Path.GetDirectoryName(m_path));
        if (File.Exists(m_path))
            File.WriteAllText(m_path, "//public class A{kkk}");
        AssetDatabase.Refresh();
    }
}
