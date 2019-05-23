using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZCode
{
    public interface IRefCounter
    {
        int RefCount { get; }
        void Retain(Object refOwner = null);
        void Release(Object refOwner = null);
    }
    public class SimpleRC : IRefCounter
    {
        public int RefCount { get; private set; }

        public void Release(Object refOwner = null)
        {
            RefCount--;
            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        public void Retain(Object refOwner = null)
        {
            RefCount++;
        }

        protected virtual void OnZeroRef()
        {

        }
    }
}