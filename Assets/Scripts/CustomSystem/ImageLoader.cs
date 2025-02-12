using System.Collections;
using System.IO;
using SimpleFileBrowser;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSystem
{
    public class ImageLoader : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;
        
        public void SelectAndLoadImage()
        {
            FileBrowser
                .SetFilters(true, new FileBrowser
                    .Filter("Files", ".jpg", ".png"));
            StartCoroutine(OpenImageFile());
        }

        private IEnumerator OpenImageFile()
        {
            yield return FileBrowser.WaitForLoadDialog(
                FileBrowser.PickMode.FilesAndFolders,
                false,
                null,
                null,
                "Select Image for Puzzle", 
                "Select");

            if (FileBrowser.Success)
            {
                var rawImageTexture = System.IO.File.ReadAllBytes(FileBrowser.Result[0]);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(rawImageTexture);
                
                rawImage.texture = texture;
            }
        }
    }
}
