using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerControls playerCont;

    public int moveSpeed;

    private InputAction movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerCont = new PlayerControls();
    }

    private void OnEnable()
    {
        movement = playerCont.Player.Move;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = movement.ReadValue<Vector2>();
        Vector3 playermove = new Vector3(moveVector.x,moveVector.y, 0); 
        GetComponent<Rigidbody2D>().velocity = playermove * moveSpeed;
    }
}
