using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject borderParent;
    private GameObject[] borders;

    private void Awake()
    {
        borders = borderParent.GetChildrens();
    }

    public void SetOutline(bool isActive)
    {
        borders.Map(t => t.SetActive(isActive));
    }
}
