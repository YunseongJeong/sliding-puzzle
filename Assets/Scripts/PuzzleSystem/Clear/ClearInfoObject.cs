using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearInfoObject : MonoBehaviour
{
    public string clearText;
    public Texture clearImage;
    
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static ClearInfoObject Create(Texture clearImage, string clearText = "congratulations!")
    {
        GameObject clearInfoObject = new GameObject("ClearInfoObject");
        ClearInfoObject clearInfo = clearInfoObject.AddComponent<ClearInfoObject>();
        clearInfo.clearImage = clearImage;
        clearInfo.clearText = clearText;
        return clearInfo;
    }
}
