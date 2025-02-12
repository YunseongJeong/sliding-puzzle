using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    
#if UNITY_EDITOR
    string path = Path.Combine(Application.dataPath, "SaveData");
#else
    string path = Application.persistentDataPath;
#endif
    
    public static void SaveData<T>(T data, string fileName)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), json);
    }

    public static T LoadData<T>(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        T data = default(T);
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<T>(json);
        }

        return data;
    }
}
