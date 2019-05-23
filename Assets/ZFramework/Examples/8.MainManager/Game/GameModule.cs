
using UnityEngine;
using UnityEngine.SceneManagement;
using ZFramework;

//在某个游戏里实现的
namespace Game
{
    //游戏模块的入口
    public class GameModule : MainManager
    {
        public static void LoadModule()
        {
            SceneManager.LoadScene("Game");
        }

        protected override void LaunchInDevelopingMode()
        {
            //开发逻辑
            Debug.Log("开发逻辑");
        }

        protected override void LaunchInProductionMode()
        {
            //生产逻辑
            Debug.Log("生产逻辑");
        }

        protected override void LaunchInTestMode()
        {
            //测试逻辑
            Debug.Log("测试逻辑");
        }

    }
}

