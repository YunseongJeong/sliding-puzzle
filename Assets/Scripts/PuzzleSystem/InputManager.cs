using System.Collections.Generic;
using PuzzleSystem.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PuzzleSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster _raycaster;
        private EventSystem _eventSystem;
        private MonoBehaviour _context;

        public void Start()
        {
            _eventSystem = EventSystem.current;
        }

        public Piece GetHoveredPiece()
        {
            PointerEventData pointerData = new PointerEventData(_eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            _raycaster.Raycast(pointerData, results);

            foreach (var result in results)
            {
                Piece piece = result.gameObject.GetComponent<Piece>();
                if (piece != null)
                    return piece;
            }

            return null;
        }
        
    }
}