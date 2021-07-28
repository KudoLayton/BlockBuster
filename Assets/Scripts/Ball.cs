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
            Destroy(hits.collider.gameObject);
            Handheld.Vibrate();
            transform.position = hits.point;
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
