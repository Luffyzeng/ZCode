
namespace ZCode
{
    public class EditorUtilExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/2.MenuItem 复用", false, 2)]
        private static void MenuClicked()
        {
            EditorUtil.CallMenuItem("ZFramework/2.复制文本到剪切板");
        }
#endif

    }
}