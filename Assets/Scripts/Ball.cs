using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 initialDirection = Vector2.up;
    [SerializeField]
    float speed;
    [SerializeField]
    float radius = 0.3f;
    [SerializeField]
    GameObject spark;
    Vector2 direction;
    new Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        direction = initialDirection;
        renderer = GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hits = Physics2D.Raycast(transform.position, direction, radius);
        if (hits)
        {
            direction = Vector2.Reflect(direction, hits.normal).normalized;
            var block = hits.collider.GetComponent<Block>();
            if (block)
                block.StartBust();
            else
            {
                GameObject newSpark = Instantiate(spark, hits.point, Quaternion.identity);
                ParticleSystem.ShapeModule shape = newSpark.GetComponent<ParticleSystem>().shape;
                shape.rotation = new Vector3(0, Vector2.SignedAngle(Vector2.down, hits.normal), 0);
            }
            Handheld.Vibrate();
            transform.position = hits.point;
            transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
        }
        else
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
        }
    }

    private void Update()
    {
        if (!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
