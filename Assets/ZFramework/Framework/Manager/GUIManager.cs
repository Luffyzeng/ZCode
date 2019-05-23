
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZFramework
{
    public enum UILayer
    {
        Bg,
        Common,
        Top
    }

    public class GUIManager : MonoBehaviour
    {
        private static GameObject m_UIRoot;
        public static GameObject UIRoot
        {
            get
            {
                if (!m_UIRoot)
                {
                    var uiRootPrefab = Resources.Load<GameObject>("UIRoot");
                    m_UIRoot = Instantiate(uiRootPrefab);
                    m_UIRoot.name = "UIRoot";
                }
                return m_UIRoot;
            }
        }

        private static Dictionary<string, GameObject> mPanelsDict = new Dictionary<string, GameObject>();

        public static void SetResolution(float width,float height,float matchWidthOrHeight)
        {
            var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
        }
        
        public static GameObject LoadPanel(string panelName, UILayer layer)
        {
            var panelPrefab = Resources.Load<GameObject>(panelName);
            var panel = Instantiate(panelPrefab);
            panel.name = panelName;
            mPanelsDict.Add(panel.name, panel);

            switch (layer)
            {
                case UILayer.Bg:
                    panel.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
                case UILayer.Common:
                    panel.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panel.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
            }

            var panelRectTrans = panel.transform as RectTransform;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;
            return panel;
        }

        public static void UnLoad(string panelName)
        {
            if (mPanelsDict.ContainsKey(panelName))
            {
                Destroy(mPanelsDict[panelName]);
            }
        }

    }
}