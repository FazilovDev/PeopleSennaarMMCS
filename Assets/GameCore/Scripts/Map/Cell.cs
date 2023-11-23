using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Desert = 0,
}

public class Cell : MonoBehaviour
{
    public CellType Type;

    [SerializeField] private GameObject borderParent;
    private GameObject[] borders;

    private void Awake()
    {
        
    }
}
