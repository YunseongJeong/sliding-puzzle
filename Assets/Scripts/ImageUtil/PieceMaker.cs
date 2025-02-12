using PuzzleSystem.Game;
using UnityEngine;
using UnityEngine.UI;

namespace ImageUtil
{
    public class PieceMaker
    {
        private Texture _texture;
        
        public PieceMaker(Texture texture)
        {
            _texture = texture;
        }

        public GameObject[] GetPieces(int cols, int rows, Transform transform)
        {
            GameObject[] pieces = new GameObject[rows * cols];
            float w = 1f / cols;
            float h = 1f / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    pieces[i * cols + j] = MakePiece(w, h, j, i, transform);
                }
            }
            
            pieces[cols-1].SetActive(false);
            
            return pieces;
        }

        private GameObject MakePiece(float w, float h, int col, int row, Transform transform)
        {
            GameObject piece = new GameObject($"Piece{row}_{col}");
            piece.transform.SetParent(transform);
            piece.transform.localScale = Vector3.one;
            piece.transform.localPosition = Vector3.zero;
            piece.transform.localRotation = Quaternion.identity;
            piece.transform.localEulerAngles = Vector3.zero;
                    
            piece.AddComponent<CanvasRenderer>();
            Piece pieceComponent = piece.AddComponent<Piece>();
            pieceComponent.col = col;
            pieceComponent.row = row;
            RawImage rawImage = piece.AddComponent<RawImage>();
            rawImage.texture = _texture;
            rawImage.uvRect = new Rect(col * w, row * h, w, h);
            return piece;
        }
    }
}
