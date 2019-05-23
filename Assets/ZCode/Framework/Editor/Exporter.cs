using System;
using UnityEngine;
using UnityEditor;

namespace ZCode
{
    public class Exporter
    {
        public static string GenerateUnityPackageName()
        {
            return "ZCode_" + DateTime.Now.ToString("yyyyMMdd_HH");
        }

        [MenuItem("ZCode/Framework/Editor/导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            var generatedPackageName = GenerateUnityPackageName();
            EditorUtil.ExportPackage("Assets/ZCode", generatedPackageName + ".UnityPackage");
            CommonUtil.OpenInFolder(System.IO.Path.Combine(Application.dataPath, "../"));
        }
    }

}