using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimiento : MonoBehaviour
{
    public float speedx;
    public float speedz;
    public float verticalforce;
    [SerializeField] private float rayDistance = 1f;

    private Rigidbody _compRigidbody;
    private bool jump;
    private bool canjump;
    private bool hasdoublejump;
    private float horizontalMovenent;
    public float moveSpeed = 5f;
    private float verticalMovement;

    private void Start()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }
    public void ReadDirection(InputAction.CallbackContext context)
    {
        horizontalMovenent = context.ReadValue<float>();
    }
    public void MoveVertically(InputAction.CallbackContext movement)
    {
        Vector3 mover = new Vector3(0, 0,verticalMovement) * moveSpeed * Time.deltaTime;
        transform.position += mover;
        verticalMovement = movement.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(speedx * horizontalMovenent, _compRigidbody.velocity.y, speedz * verticalMovement);

        CheckRaycast();

        if (jump)
        {
            if (canjump)
            {
                _compRigidbody.AddForce(Vector3.up * verticalforce, ForceMode.Impulse);
                jump = false;
            }
            else if (hasdoublejump)
            {
                _compRigidbody.AddForce(Vector3.up * verticalforce, ForceMode.Impulse);
                hasdoublejump = false;
                jump = false;
            }
        }
    }

    private void CheckRaycast()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector3.down, rayDistance);

        Debug.DrawRay(rayOrigin, Vector3.down * rayDistance, Color.red);

        if (hit.collider != null)
        {
            canjump = true;
            hasdoublejump = true;
        }
        else
        {
            canjump = false;
        }
    }

    /*private void OnCollisionEnter(Collision collision){

        if(Collision.gameobject.tag== "enemigo") { 
        
        }
    }*/
}
