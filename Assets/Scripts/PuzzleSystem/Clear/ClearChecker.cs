using UnityEngine;

namespace PuzzleSystem
{
    public class ClearChecker : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        
        public void OnClick()
        {
            if (CheckClear())
            {
                SceneChanger.ChangeScene("ClearScene");
            }
            else
            {
                Debug.Log("Puzzle is not clear");
            }
        }
        
        private bool CheckClear()
        {
            for (int c = 0; c < _gridLayoutGroup.cols; c++)
            {
                for (int r = 0; r < _gridLayoutGroup.rows; r++)
                {
                    Piece piece = _gridLayoutGroup.GetPiece(c, r);

                    if (piece.col != c || piece.row != r)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}