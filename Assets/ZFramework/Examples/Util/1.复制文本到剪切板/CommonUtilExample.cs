
namespace ZFramework
{
    public class CommonUtilExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/1.复制文本到剪切板", false, 1)]
#endif
        static void MenuClicked()
        {
            CommonUtil.CopyText("复制的文本");
        }
    }
}