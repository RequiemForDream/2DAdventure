using System;
using UnityEngine;

public class GameObjectOfTypeAttribute : PropertyAttribute
{
    public Type type { get; }
    public bool allowSceneObjects { get; }

    public GameObjectOfTypeAttribute(Type requiredType, bool allowSceneObjects = true)
    {
        this.type = requiredType;
        this.allowSceneObjects = allowSceneObjects;
    }
}
