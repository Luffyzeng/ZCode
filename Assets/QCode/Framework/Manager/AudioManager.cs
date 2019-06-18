using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioListener mAudioListener;
        //与播放音效不同，背景音乐同一时间只能播放一首音乐
        private AudioSource mMusicSource = null;   

        private void CheckAudioListener()
        {
            if (!mAudioListener)
            {
                mAudioListener = gameObject.AddComponent<AudioListener>();
            }
        }
        //播放音效
        public void PlaySound(string soundName)
        {
            CheckAudioListener();
            var audioSource = gameObject.AddComponent<AudioSource>();
            var hitSound = Resources.Load<AudioClip>("soundName");
            audioSource.clip = hitSound;
            audioSource.Play();
        }

        //播放背景音乐
        public void PlayMusic(string musicName,bool loop)
        {
            CheckAudioListener();
            if (!mMusicSource)
            {
                mMusicSource = gameObject.AddComponent<AudioSource>();
            }

            var music = Resources.Load<AudioClip>(musicName);
            mMusicSource.clip = music;
            mMusicSource.loop = loop;
            mMusicSource.Play();
        }

        //停止
        public void StopMusic()
        {
            mMusicSource.Stop();
        }

        //暂停
        public void PauseMusic()
        {
            mMusicSource.Pause();
        }

        //继续播放音乐
        public void UnPauseMusic()
        {
            mMusicSource.UnPause();
        }

        //音乐静音
        public void MusicOff()
        {
            mMusicSource.Pause();
            mMusicSource.mute = true;
        }

        //音效静音
        public void SoundOff()
        {
            var audioSources = GetComponents<AudioSource>();
            foreach (var audioSource in audioSources)
            {
                if(audioSource!=mMusicSource)
                {
                    audioSource.Pause();
                    audioSource.mute = true;
                }
            }
        }

        public void MusicOn()
        {
            mMusicSource.UnPause();
            mMusicSource.mute = false;
        }

        public void SoundOn()
        {
            var audioSources = GetComponents<AudioSource>();
            foreach (var audioSource in audioSources)
            {
                if (audioSource != mMusicSource)
                {
                    audioSource.UnPause();
                    audioSource.mute = false;
                }
            }
        }
    }
}