using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class TaskManagerExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/17.协程管理工具测试", false, 17)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("TaskManagerExample").AddComponent<TaskManagerExample>();
        }

#endif

        void Start()
        {
            SomeCodeThatCouldBeAnywhereInTheUniverse();
        }
        IEnumerator MyAwesomeTask()
         {  
             while(true) {  
                 Debug.Log("Logcat iz in ur consolez, spammin u wif messagez.");  
                 yield return null;  
            }  
         }  
          
         IEnumerator TaskKiller(float delay, Task t)
         {  
             yield return new WaitForSeconds(delay);  
             t.Stop();  
         }  
          
         void SomeCodeThatCouldBeAnywhereInTheUniverse()
         {  
             Task spam = new Task(MyAwesomeTask());
            new Task(TaskKiller(5, spam)).Finished += _ =>
            {
                Debug.Log("Killed");
            };
         }  

        
    }
}