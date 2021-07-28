using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    [SerializeField]
    float collisionPredictionMaximum = 3;
    Vector2 startPoint = Vector2.zero;
    new LineRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            renderer.enabled = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            renderer.enabled = false;
            Vector2 endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newBall = Instantiate(ball, endPoint, Quaternion.identity);
            newBall.GetComponent<Ball>().initialDirection = (startPoint - endPoint).normalized;
        }
        else if (Input.GetMouseButton(0))
        {
            renderer.enabled = true;
            renderer.positionCount = 1;
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            renderer.SetPosition(0, point);
            Vector2 direction = (startPoint - point).normalized;
            int pointsNum = 1;
            Collider2D pastCollider = null;
            for (int i = 0; i < collisionPredictionMaximum; ++i)
            {
                renderer.positionCount = ++pointsNum;
                RaycastHit2D[] hit = Physics2D.RaycastAll(point, direction);
                renderer.SetPosition(pointsNum - 1, point + direction * 10000);
                for (int j = 0; j < hit.Length; ++j)
                {
                    if (pastCollider == hit[j].collider)
                        continue;
                    renderer.SetPosition(pointsNum - 1, hit[j].point);
                    direction = Vector2.Reflect(hit[j].point - point, hit[j].normal);
                    point = hit[j].point;
                    pastCollider = hit[j].collider;
                    break;
                }
            }
        }
        else
        {
            renderer.enabled = false;
        }
    }
}
