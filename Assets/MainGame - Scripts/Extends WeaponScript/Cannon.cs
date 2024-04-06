using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : WeaponScript
{
    public CannonProj proj;
    [SerializeField] public int cannonPushback = 0;
    public AudioSource attackSoundSource;
    public AudioClip attackSound;
    public AudioSource reloadSoundSource;
    public AudioClip ReloadSound;
    public float volume;

    public Animator anim;
    private void OnAwake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    protected override void Attack()// remember to add player stun and 
    {
        if (weaponTimer == 0)
        {
            anim.SetTrigger("Active");
            attackSoundSource.PlayOneShot(attackSound, volume);

            Vector3 SpawnerPos = new Vector3(transform.position.x, transform.position.y, 0f);
            var projNew = Instantiate(proj, SpawnerPos, Quaternion.identity);
            projNew.OnSpawn(weaponPos, rotate +90);

            Vector2 pushVector = new Vector2(-PlayerScript.Instance.weaponPos.x, -PlayerScript.Instance.weaponPos.y) * cannonPushback;
            playerRB.velocity = new Vector2(playerRB.velocity.x,0);
            playerRB.AddForce(pushVector, ForceMode2D.Force);
            
            anim.SetTrigger("Inactive");
            reloadSoundSource.PlayDelayed(1);
        }
    }
}