using UnityEngine;

namespace PuzzleSystem.PuzzleInfo
{
    public class PuzzleInfoObject : MonoBehaviour
    {
        public Texture texture;
        public int n;
        private void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static PuzzleInfoObject Create(Texture texture, int n)
        {
            GameObject puzzleInfoObject = new GameObject("PuzzleInfoObject");
            PuzzleInfoObject puzzleInfo = puzzleInfoObject.AddComponent<PuzzleInfoObject>();
            puzzleInfo.texture = texture;
            puzzleInfo.n = n;

            return puzzleInfo;
        }
    }
}
