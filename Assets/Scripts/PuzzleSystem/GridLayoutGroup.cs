using UnityEngine;

namespace PuzzleSystem
{
    public class GridLayoutGroup : MonoBehaviour
    {
        [SerializeField] private int _cols;
        [SerializeField] private int _rows;
        
        [SerializeField] private RectTransform _puzzleRect;
        
        private GameObject[] _pieces;
        
        public void SetLayout(int cols, int rows)
        {
            _cols = cols;
            _rows = rows;
        }

        public void Clear()
        {
            foreach (var piece in _pieces)
            {
                Destroy(piece);
            }
            _pieces = null;
        }
        
        public void SetPieces(GameObject[] pieces)
        {
            _pieces = pieces;
            RectTransform rectTransform = GetComponent<RectTransform>();
            
            float w = rectTransform.rect.width / _cols;
            float h = rectTransform.rect.height / _rows;
                        
            float baseX = rectTransform.localPosition.x - _puzzleRect.rect.width / 2 + w / 2;
            float baseY = rectTransform.localPosition.y - _puzzleRect.rect.height / 2 + h / 2;
            
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _pieces[i * _cols + j].GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
                    _pieces[i * _cols + j].GetComponent<RectTransform>().localPosition = new Vector3(baseX + j * w, baseY + i * h, 0);
                }
            }
        }
    }
}