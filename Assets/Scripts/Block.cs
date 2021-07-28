using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block :ColliderNormal
{
    Vector2 min;
    Vector2 max;
    new BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        min = collider.bounds.min;
        max = collider.bounds.max;
    }

    static bool isCrossed(
        Vector2 l1p1,
        Vector2 l1p2,
        Vector2 l2p1,
        Vector2 l2p2
        )
    {
        return false;
    }

    public override Vector2 GetNormalOnPoint(Vector2 startPoint, Vector2 collidePoint)
    {
        Debug.Log(collider.bounds.Contains(collidePoint));
        Vector2 point = collider.bounds.ClosestPoint(collidePoint);
        bool minX = min.x == point.x;
        bool maxX = max.x == point.x;
        bool minY = min.y == point.y;
        bool maxY = max.y == point.y;
        if ((minX || maxX) && (minY || maxY))
            return new Vector2(0, 0);
        else if (minX)
            return new Vector2(-1, 0);
        else if (maxX)
            return new Vector2(1, 0);
        else if (minY)
            return new Vector2(0, -1);
        else
            return new Vector2(1, 0);
    }
}
