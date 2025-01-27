using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class GridLayoutGroup : MonoBehaviour
    {
        [SerializeField] private int _cols;
        [SerializeField] private int _rows;
        
        [SerializeField] private RectTransform _puzzleRect;

        private float w, h, baseX, baseY;
        
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
            
            w = rectTransform.rect.width / _cols;
            h = rectTransform.rect.height / _rows;
                        
            baseX = rectTransform.localPosition.x - _puzzleRect.rect.width / 2 + w / 2;
            baseY = rectTransform.localPosition.y - _puzzleRect.rect.height / 2 + h / 2;
            
            PositionPieces();
        }

        
        public GameObject GetPiece(int index)
        {
            return _pieces[index];
        }
        
        public GameObject GetPiece(int col, int row)
        {
            return _pieces[row * _cols + col];
        }
        
        public int GetIndex(int col, int row)
        {
            return row * _cols + col;
        }
        
        public void SwapPieces(GameObject piece1, GameObject piece2)
        {
            int index1 = Array.IndexOf(_pieces, piece1);
            int index2 = Array.IndexOf(_pieces, piece2);
            
            _pieces[index1] = piece2;
            _pieces[index2] = piece1;
            
            PositionPieces();
        }

        private void PositionPieces()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _pieces[i * _cols + j].GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
                    _pieces[i * _cols + j].GetComponent<RectTransform>().localPosition = new Vector3(baseX + j * w, baseY + i * h, 0);
                }
            }
        }

        public Piece GetEmptyPiece(Piece piece)
        {
            int index = Array.IndexOf(_pieces, piece.gameObject);
            int col = index % _cols;
            int row = index / _cols;
            
            if (col > 0 && !_pieces[index - 1].activeSelf)
            {
                return _pieces[index - 1].GetComponent<Piece>();
            }
            if (col < _cols - 1 && !_pieces[index + 1].activeSelf)
            {
                return _pieces[index + 1].GetComponent<Piece>();
            }
            if (row > 0 && !_pieces[index - _cols].activeSelf)
            {
                return _pieces[index - _cols].GetComponent<Piece>();
            }
            if (row < _rows - 1 && !_pieces[index + _cols].activeSelf)
            {
                return _pieces[index + _cols].GetComponent<Piece>();
            }

            return null;
        }
    }
}