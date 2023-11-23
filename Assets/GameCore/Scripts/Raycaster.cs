using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public bool IsHitted;
    public GameObject HitObject;

    private void FixedUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        IsHitted = Physics.Raycast(ray, out var hitInfo);
        HitObject = IsHitted ? hitInfo.transform.gameObject : null;
    }
}
