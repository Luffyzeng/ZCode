using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test01 : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        //typeof(Test01).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.n)

        Dictionary<char, int> dict;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisabled()
    {
        Debug.Log("OnDisabled");
    }

}

public static class TransformExtension 
{
    public static void SetLocalPosX(this MonoBehaviour monoBehaviour,float x)
    {
        var localPos = monoBehaviour. transform.localPosition;
        localPos.x = x;
        monoBehaviour.transform.localPosition = localPos;
    }
}
