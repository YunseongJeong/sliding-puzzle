using UnityEngine;

namespace PuzzleSystem.Clear
{
    public class ClearInfoObject : MonoBehaviour
    {
        public string clearText;
        public Texture clearImage;
        public bool isCustomGame;
        private void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static ClearInfoObject Create(Texture clearImage, string clearText = "congratulations!", bool isCustomGame = false)
        {
            GameObject clearInfoObject = new GameObject("ClearInfoObject");
            ClearInfoObject clearInfo = clearInfoObject.AddComponent<ClearInfoObject>();
            clearInfo.clearImage = clearImage;
            clearInfo.clearText = clearText;
            clearInfo.isCustomGame = isCustomGame;
            return clearInfo;
        }
    }
}
