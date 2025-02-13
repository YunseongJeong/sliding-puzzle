using System;
using UnityEngine;

namespace PuzzleSystem.Game
{
    public class GridLayoutGroup : MonoBehaviour
    {
        [SerializeField] public int cols;
        [SerializeField] public int rows;
        
        [SerializeField] private RectTransform _puzzleRect;

        private float w, h, baseX, baseY;
        
        private GameObject[] _pieces;
        
        public void SetLayout(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
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
            
            w = rectTransform.rect.width / cols;
            h = rectTransform.rect.height / rows;
                        
            baseX = rectTransform.localPosition.x - _puzzleRect.rect.width / 2 + w / 2;
            baseY = rectTransform.localPosition.y - _puzzleRect.rect.height / 2 + h / 2;
            
            PositionPieces();
        }
        
        public GameObject GetPiece(int index)
        {
            return _pieces[index];
        }
        
        public Piece GetPiece(int col, int row)
        {
            return _pieces[row * cols + col].GetComponent<Piece>();
        }
        
        public int GetIndex(int col, int row)
        {
            return row * cols + col;
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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _pieces[i * cols + j].GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
                    _pieces[i * cols + j].GetComponent<RectTransform>().localPosition = new Vector3(baseX + j * w, baseY + i * h, 0);
                }
            }
        }

        public Piece GetEmptyPiece(Piece piece)
        {
            int index = Array.IndexOf(_pieces, piece.gameObject);
            int col = index % cols;
            int row = index / cols;
            
            if (col > 0 && !_pieces[index - 1].activeSelf)
            {
                return _pieces[index - 1].GetComponent<Piece>();
            }
            if (col < cols - 1 && !_pieces[index + 1].activeSelf)
            {
                return _pieces[index + 1].GetComponent<Piece>();
            }
            if (row > 0 && !_pieces[index - cols].activeSelf)
            {
                return _pieces[index - cols].GetComponent<Piece>();
            }
            if (row < rows - 1 && !_pieces[index + cols].activeSelf)
            {
                return _pieces[index + cols].GetComponent<Piece>();
            }

            return null;
        }
    }
}