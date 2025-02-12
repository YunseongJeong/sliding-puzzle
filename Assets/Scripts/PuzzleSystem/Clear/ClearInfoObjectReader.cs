using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleSystem.Clear
{
    public class ClearInfoObjectReader : MonoBehaviour
    {
        private ClearInfoObject _clearInfoObject;
        private Texture _clearImage;
        private string _clearText;
        private bool _isCustomGame;

        [SerializeField]
        private TMP_Text _clearTextUI;
        [SerializeField]
        private RawImage _clearImageUI;
    
        [SerializeField]
        private GameObject _nextButton;
    
        public void Start()
        {
            if (FindPuzzleInfo())
            {
                _clearTextUI.text = _clearText;
                _clearImageUI.texture = _clearImage;
                _nextButton.SetActive(!_isCustomGame);
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
                _isCustomGame = _clearInfoObject.isCustomGame;
                Destroy(_clearInfoObject.gameObject);
                return true;
            }
        }
    }
}
