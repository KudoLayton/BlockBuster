using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        var wallViewportPointList = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };
        var wallScreenPointList = (new List<Vector2>(wallViewportPointList)).Select(
            point => (Vector2)Camera.main.ViewportToWorldPoint(point)).ToList();
        GetComponent<EdgeCollider2D>().SetPoints(wallScreenPointList);
    }
}
