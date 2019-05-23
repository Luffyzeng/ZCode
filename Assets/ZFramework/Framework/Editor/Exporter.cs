using System;
using UnityEngine;
using UnityEditor;

namespace ZFramework
{
    public class Exporter
    {
        public static string GenerateUnityPackageName()
        {
            return "ZFramework_" + DateTime.Now.ToString("yyyyMMdd_HH");
        }

        [MenuItem("ZFramework/Framework/Editor/导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            var generatedPackageName = GenerateUnityPackageName();
            EditorUtil.ExportPackage("Assets/ZFramework", generatedPackageName + ".UnityPackage");
            CommonUtil.OpenInFolder(System.IO.Path.Combine(Application.dataPath, "../"));
        }
    }

}