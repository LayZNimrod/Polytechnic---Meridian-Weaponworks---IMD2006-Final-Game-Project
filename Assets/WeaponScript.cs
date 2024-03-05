using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    PlayerControls playerCont;
    private Rigidbody2D playerPos;
    private InputAction fire;

    private bool isFire;
    private bool pushBack;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerScript>();
        playerPos = GetComponentInParent<Rigidbody2D>();
        playerCont = GetComponentInParent<PlayerControls>();
    }

    private void OnEnable()
    {
        fire = playerCont.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 weaponPos = player.weaponPos;
        transform.position = weaponPos + (Vector2)playerPos.transform.position;
        
        float rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg;
        Vector3 multVector = new Vector3(0f, 0f, rotate);
        transform.eulerAngles = multVector;

        isFire = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isFire)
        {
            pushBack = true;
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        isFire = true;
    }
}