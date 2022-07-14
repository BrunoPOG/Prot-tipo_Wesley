using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10;
    public float _currentBar = 1;
    public bool destroyOnkill = false;
    public Image healthBar;
    public float duration;
    public Ease ease = Ease.OutBack;
    public string CharacterHealthBar;
    public Animator animator;
    public float durationDeath;
    public AudioSource audioSource;

    [SerializeField] private float _currentLife;
    private bool _isDead = false;


    [SerializeField] private FlashColor _flashColor;

    private void OnValidate()
    {
        if(healthBar == null)
        {
            healthBar = GameObject.Find(CharacterHealthBar).GetComponent<Image>();  
        }
    }

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;


        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            animator.SetTrigger("Death");
            audioSource.Play();
            Invoke(nameof(Kill), durationDeath);
        }

        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
        if(healthBar != null)
        {
            _currentBar = _currentLife / startLife;
            UpdateUI();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnkill)
        {
            Destroy(gameObject);
        }
    }
    private void UpdateUI()
    {
        healthBar.DOFillAmount( _currentBar, duration).SetEase(ease);
   //     _currTween = uiImage.DOFillAmount(1 - (current / max), duration).SetEase(ease);
    }
}


//