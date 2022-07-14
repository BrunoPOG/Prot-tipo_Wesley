using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    public float timeToDestroy = 2f;

    public float side = 1;

    public int damageAmount = 1;
    private void Awake()
    {
         Destroy(gameObject, timeToDestroy); 
    }


    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * -side);
   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Enemy = collision.transform.GetComponent<EnemyScript>();
        if(Enemy != null)
        {
            Enemy.Damage(damageAmount);

            Invoke(nameof(DestroyBullet), .07f);
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
//