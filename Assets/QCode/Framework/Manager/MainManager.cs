using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCode
{
//1. 	开发阶段：不不断地编码->验证结果->编码->验证结果->…….
//2. 	出包/真机阶段：这个阶段主要是跑完整流程，在真机上跑跑，给 QA 测测。
//3. 	发布阶段：上线
    public enum EnvironmentMode
    {
        Developing,
        Test,
        Production
    }

    public abstract class MainManager : MonoBehaviour
    {
        public EnvironmentMode Mode;

        private static EnvironmentMode mSharedMode;
        private static bool mModeSetted=false;

        void Start()
        {
            if (!mModeSetted)
            {
                mSharedMode = Mode;
                mModeSetted = true;
            }
            Mode = mSharedMode;
            switch (mSharedMode)
            {
                case EnvironmentMode.Developing:
                    LaunchInDevelopingMode();
                    break;
                case EnvironmentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnvironmentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
        
    }
}