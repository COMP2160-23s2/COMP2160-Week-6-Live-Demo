using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement paramaters
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationRate = 90f;

    // Input
    private PlayerActions actions;
    private InputAction movementAction;

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.Gameplay.Movement;
    }

    void OnEnable()
    {
        movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    void Update()
    {
        float moveDirection = movementAction.ReadValue<Vector2>().y;
        transform.Translate(Vector2.up * movementSpeed * moveDirection * Time.deltaTime, Space.Self);

        float rotationDirection = movementAction.ReadValue<Vector2>().x;
        transform.Rotate(Vector3.back * rotationRate * rotationDirection * Time.deltaTime, Space.Self);
    }
}
