using System;
using UnityEngine;
using UnityEditor;

namespace QCode
{
    public class Exporter
    {
        public static string GenerateUnityPackageName()
        {
            return "QCode_" + DateTime.Now.ToString("yyyyMMdd_HH");
        }

        [MenuItem("QCode/Framework/Editor/导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            var generatedPackageName = GenerateUnityPackageName();
            EditorUtil.ExportPackage("Assets/QCode", generatedPackageName + ".UnityPackage");
            CommonUtil.OpenInFolder(System.IO.Path.Combine(Application.dataPath, "../"));
        }
    }

}