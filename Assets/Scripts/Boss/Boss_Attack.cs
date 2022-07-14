using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public Animator animator;
    public Transform positionToShoot1;
    public Transform positionToShoot2;
    public Transform positionToShoot3;
    public Transform positionToShoot4;
    public Transform positionToShoot5;
    public Transform positionToShoot6;
    public GameObject prefabProjectile;
    public ProjectileBase prefabProjectile2;
    public int VariationOfShoot;
    public int VariationOfAttack;
    public int FirstAttackBoss = 0;
    public int FinishFirstAttack = 10;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Attack", false);

       
          StartCoroutine(StartAttack(1));
      


       

    }

    private void resetAttack()
    {
        FirstAttackBoss = 0;
    }
   
    IEnumerator StartAttack(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Attack", true);
        audioSource.Play();
        var projectile = Instantiate(prefabProjectile);
        VariationOfShoot = Random.Range(0, 6);
        if (VariationOfShoot == 1)
        {
            projectile.transform.position = positionToShoot1.position;
        }
        else if (VariationOfShoot == 2)
        {
            projectile.transform.position = positionToShoot2.position;
        }
        else if (VariationOfShoot == 3)
        {
            projectile.transform.position = positionToShoot3.position;
        }
        else if (VariationOfShoot == 4)
        {
            projectile.transform.position = positionToShoot4.position;
        }
        else if (VariationOfShoot == 5)
        {
            projectile.transform.position = positionToShoot5.position;
        }
        else if (VariationOfShoot == 6)
        {
            projectile.transform.position = positionToShoot6.position;
        }
    
       
    }
}