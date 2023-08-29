using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonVision : MonoBehaviour
{
    //Sight
    [SerializeField] private Transform target;
    [SerializeField] private float sightLength = 3f;
    [SerializeField] private LayerMask layerMask;

    //Sprite
    private SpriteRenderer sprite;
    [SerializeField] private Color alertColor;
    [SerializeField] private Color calmColor;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        LookForPlayer();
    }

    void LookForPlayer()
    {
        Vector2 direction = target.position - transform.position; // Get the vector between the target and self.
        direction.Normalize(); // Normalize this vector, turing it into a direction.
        Debug.DrawRay(transform.position, direction * sightLength, Color.red); // Draw a ray for debugging.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, sightLength, layerMask); // Cast actual ray.
        if (hit.transform == target)
        {
            SeesTarget();
        }
        else
        {
            CantSeeTarget();
        }
    }

    void SeesTarget()
    {
        sprite.color = alertColor;
    }

    void CantSeeTarget()
    {
        sprite.color = calmColor;
    }
}
