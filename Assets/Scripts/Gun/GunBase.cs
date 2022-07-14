using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float TimeBetweenShoot = 2f;
    public Transform playerSideReference;
    public AudioSource audioSource;
    public bool atirar = false;
    private Coroutine _currentCoroutine;
    public string keyToCheck;
    public int inicio = 5;
    public int fim = 200;
    void Update()
    {
        if (keyToCheck != "Enemy") 
        { 
            if (Input.GetKeyDown(KeyCode.G))
            {
                atirar = true;
                _currentCoroutine = StartCoroutine(StartShoot());
                audioSource.Play();
            }
            else if (Input.GetKey(KeyCode.G))
            {
                if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
            }
        }
        if(keyToCheck == "Enemy")
        {
            while(inicio < fim) { inicio++; if (inicio == fim - 1) atirar = true; }
            _currentCoroutine = StartCoroutine(StartShoot());
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while (atirar == true)
        {
            Shoot();
            atirar = false;
            yield return new WaitForSeconds(TimeBetweenShoot);
            if(keyToCheck == "Enemy")
            {
                inicio = 0;
            }
        }
    }


    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = -playerSideReference.transform.localScale.x;
        Play();

    }

    public void Play()
    {
        audioSource.Play();
    }
    public void timeToShoot()
    {
        atirar = true;
    }
    public void teste()
    {
        StopCoroutine(_currentCoroutine);
    }
}
