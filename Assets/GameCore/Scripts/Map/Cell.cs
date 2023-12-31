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
    private Chunk chunkParent;
     
    private void Awake()
    {
        borders = borderParent.GetChildrens();
        chunkParent = GetComponentInParent<Chunk>();
    }

    public void SetOutline(bool isActive)
    {
        borders.Map(t => t.SetActive(isActive));
    }

    public void SetOutlineChunk(bool isActive)
    {
        chunkParent.SetOutline(isActive);
    }
}
