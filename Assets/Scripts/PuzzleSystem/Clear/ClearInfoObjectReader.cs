using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClearInfoObjectReader : MonoBehaviour
{
    private ClearInfoObject _clearInfoObject;
    private Texture _clearImage;
    private string _clearText;

    [SerializeField]
    private TMP_Text _clearTextUI;
    [SerializeField]
    private RawImage _clearImageUI;
    
    public void Start()
    {
        if (FindPuzzleInfo())
        {
            _clearTextUI.text = _clearText;
            _clearImageUI.texture = _clearImage;
        }
    }

    private bool FindPuzzleInfo()
    {
        _clearInfoObject = FindObjectOfType<ClearInfoObject>();
        if (_clearInfoObject == null)
        {
            Debug.LogError("ClearInfoObject not found");
            return false;
        }
        else
        {
            _clearImage = _clearInfoObject.clearImage;
            _clearText = _clearInfoObject.clearText;
            Destroy(_clearInfoObject.gameObject);
            return true;
        }
    }
}
