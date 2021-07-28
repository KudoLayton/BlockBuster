using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColliderNormal: MonoBehaviour
{
    public abstract Vector2 GetNormalOnPoint(Vector2 startPoint, Vector2 collidePoint);
}
