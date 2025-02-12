using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomPuzzleInfoObjectMaker : MonoBehaviour
{
    private Texture _texture;
    private int _n;

    [SerializeField] private RawImage _selectedImage;
    [SerializeField] private TMP_InputField _nInputField;
    
    public void OnClick()
    {
        if (GetTexture() && GetN())
        {
            PuzzleInfoObject puzzleInfoObject = PuzzleInfoObject.Create(_texture, _n);
            SceneChanger.ChangeScene("PuzzleScene");
        }
    }

    private bool GetTexture()
    {
        if (_selectedImage.texture == null)
        {
            Debug.LogError("No image selected");
            return false;
        }
        _texture = _selectedImage.texture;
        return true;
    }
    
    private bool GetN()
    {
        string nString = _nInputField.text.Trim();
        if (!int.TryParse(nString, out _n))
        {
            Debug.LogError("Invalid n value");
            return false;
        }
        return true;
    }
}
