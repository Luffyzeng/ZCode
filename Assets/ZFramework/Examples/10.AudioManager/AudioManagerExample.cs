using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public class AudioManagerExample : MonoBehaviourSimplify
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZFramework/Examples/10.AudioManager", false, 10)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("AudioManagerExample").AddComponent<AudioManagerExample>();
        }

        
#endif
        // Use this for initialization
        void Start()
        {
            AudioManager.Instance.PlaySound("hit");
            AudioManager.Instance.PlaySound("hit");

            Delay(1.0f, () => {
                AudioManager.Instance.PlayMusic("bgm", true);
            });
            Delay(3.0f, () => { AudioManager.Instance.PauseMusic(); });
            Delay(5.0f, () => { AudioManager.Instance.UnPauseMusic(); });
            Delay(7.0f, () => { AudioManager.Instance.StopMusic(); });
            Delay(9.0f, () => {
                AudioManager.Instance.PlayMusic("home", true);
            });
            Delay(11.0f, () => { AudioManager.Instance.MusicOff(); });
            Delay(13.0f, () => { AudioManager.Instance.MusicOn(); });
        }

        protected override void OnBeforeDestory()
        {

        }
    }
}