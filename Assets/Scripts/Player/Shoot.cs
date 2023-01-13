using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerControls controls;
    public GameObject bullet;
    public Transform bulletPosition;
    public Animator animator;
    public float ShootForce = 100;
    

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();
    }
    
    void Fire()
    {
        animator.SetTrigger("Shooting");
        GameObject knife = Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        if (GetComponent<PlayerMovement>().isFacingRight)
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.right * ShootForce);
        else
        {
            knife.transform.localScale = new Vector2(-2, 3); 
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.left * ShootForce);
        }

        Destroy(knife,1.5f);
    }

    
}