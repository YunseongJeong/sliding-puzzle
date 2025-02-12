using System.Collections.Generic;
using UnityEngine;

namespace PuzzleSystem.Stage
{
    [System.Serializable]
    public class StageData
    {
        [SerializeField] public string stageName;
        [SerializeField] public string stageImagePath;
        [SerializeField] public int n;
        [SerializeField] public string clearText;
        [SerializeField] public string clearImagePath;
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "StageDataList", menuName = "StageDataList")]
    public class StageDataList : ScriptableObject
    {
        public List<StageData> stageDataList;
    }
}