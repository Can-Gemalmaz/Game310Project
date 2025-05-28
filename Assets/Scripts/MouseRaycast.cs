using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseRaycast: MonoBehaviour
{
    PlayerAction inputActions;
    Vector2 mouseRay;
    [SerializeField] private Material colorMaterial;

    private void Awake()
    {
        inputActions = new PlayerAction();
    }

    private void Start()
    {
        
        
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Movement.performed += MouseRay;
    }

    private void MouseRay(InputAction.CallbackContext context)
    {
        
    }

    private void Update()
    {
        mouseRay = inputActions.Player.Movement.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mouseRay);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hitted Object: " + hit.collider.gameObject.name);
            hit.collider.gameObject.TryGetComponent<Renderer>(out Renderer renderer);
            renderer.material = colorMaterial;
        }
        //Debug.Log(mouseRay);
    }
}
