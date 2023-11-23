using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Transform[] GetChildrens(this Transform transform)
    {
        var childrens = new Transform[transform.childCount];
        for(var i = 0; i < transform.childCount; i++)
        {
            childrens[i] = transform.GetChild(i);
        }
        return childrens;
    }

    public static GameObject[] GetChildrens(this GameObject gameObject)
    {
        var transform = gameObject.transform;
        var childrens = new GameObject[transform.childCount];
        for (var i = 0; i < transform.childCount; i++)
        {
            childrens[i] = transform.GetChild(i).gameObject;
        }
        return childrens;
    }

    public static void Map(this GameObject[] gameObjects, System.Action<GameObject> f)
    {
        for(var i = 0; i < gameObjects.Length; i++)
        {
            f(gameObjects[i]);
        }
    }
}
