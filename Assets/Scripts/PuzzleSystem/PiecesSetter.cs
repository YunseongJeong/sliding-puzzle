using ImageUtil;
using UnityEngine;

namespace PuzzleSystem
{
    public class PiecesSetter : MonoBehaviour
    {
        private PieceMaker _pieceMaker;
        [SerializeField] private Texture _texture;
        
        [SerializeField] private int _cols;
        [SerializeField] private int _rows;
        
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        
        private GameObject[] _pieces;
        
        
        private void Start()
        {
            _pieceMaker = new PieceMaker(_texture);
            
            SetPieces();
        }

        public void SetPieces()
        {
            _pieces = _pieceMaker.GetPieces(_cols, _rows, _gridLayoutGroup.transform);
            _gridLayoutGroup.SetLayout(_cols, _rows);
            _gridLayoutGroup.SetPieces(_pieces);
        }
    }
}