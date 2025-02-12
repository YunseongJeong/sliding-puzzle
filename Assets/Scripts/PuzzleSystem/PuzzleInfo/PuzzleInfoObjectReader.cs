using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInfoObjectReader : MonoBehaviour
{
    private PuzzleInfoObject _puzzleInfoObject;
    private Texture _texture;
    private int _n;
    
    
    public void Start()
    {
        if (FindPuzzleInfo())
        {
            //
        }
    }

    private bool FindPuzzleInfo()
    {
        _puzzleInfoObject = FindObjectOfType<PuzzleInfoObject>();
        if (_puzzleInfoObject == null)
        {
            Debug.LogError("PuzzleInfoObject not found");
            return false;
        }
        else
        {
            _texture = _puzzleInfoObject.texture;
            _n = _puzzleInfoObject.n;
            Destroy(_puzzleInfoObject.gameObject);
            return true;
        }
    }
}
