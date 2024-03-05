using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    private Rigidbody2D playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerScript>();
        playerPos = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 weaponPos = player.weaponPos;
        transform.position = weaponPos + (Vector2)playerPos.transform.position;
        
        float rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg;
        Vector3 multVector = new Vector3(0f, 0f, rotate);
        transform.eulerAngles = multVector;
        Debug.Log(transform.eulerAngles);
    }
}