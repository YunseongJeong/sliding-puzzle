using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PuzzleSystem
{
    public class PiecesSwaper : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Piece piece = _inputManager.GetHoveredPiece();
                if (piece != null)
                {
                    Piece emptyPiece = _gridLayoutGroup.GetEmptyPiece(piece);
                    if (emptyPiece != null)
                    {
                        _gridLayoutGroup.SwapPieces(piece.gameObject, emptyPiece.gameObject);
                    }
                }
            }
                
        }
    }
}