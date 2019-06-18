
namespace QCode
{
    public class EditorUtilExample 
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QCode/Examples/2.MenuItem 复用", false, 2)]
        private static void MenuClicked()
        {
            EditorUtil.CallMenuItem("QCode/2.复制文本到剪切板");
        }
#endif

    }
}