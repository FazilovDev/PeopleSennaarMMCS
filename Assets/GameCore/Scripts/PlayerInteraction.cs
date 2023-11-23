using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    CellInteraction = 0,
    ChunkInteraction = 1
}

public class PlayerInteraction : MonoBehaviour
{
    private Raycaster raycaster;

    private Cell currentCell;
    [SerializeField] private InteractionType currentInteraction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentInteraction = (InteractionType)(((int)currentInteraction + 1) % 2);
        }
        SelectUpdate();
    }

    private void SelectUpdate()
    {
        if (raycaster == null)
        {
            raycaster = GetComponent<Raycaster>();
            return;
        }

        if (raycaster.IsHitted)
        {
            if (raycaster.HitObject.CompareTag("Cell"))
            {
                var cell = raycaster.HitObject.GetComponent<Cell>();

                if (cell != currentCell && currentCell != null)
                {
                    SetOutlineCurrentCell(false);
                }
                currentCell = cell;
                SetOutlineCurrentCell(true);
            }
        }
        else
        {
            if (currentCell != null)
            {
                SetOutlineCurrentCell(false);
            }
            currentCell = null;
        }
    }
     
    private void SetOutlineCurrentCell(bool isActive)
    {
        if (currentCell != null)
        {
            if (currentInteraction == InteractionType.CellInteraction)
            {
                currentCell.SetOutline(isActive);
            }
            else
            {
                currentCell.SetOutlineChunk(isActive);
            }
        }
    }
}
