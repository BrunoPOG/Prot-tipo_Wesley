using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Prototype Valor Config")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedRun;
    public float speed;
    public float forceJump;
    public float _currentSpeed;


    [Header("Animation Setup")]
    public float JumpScaleY = 1.1f;
    public float JumpScaleX = 0.9f;
    public float AnimationDuration = 0.2f;
    public Ease ease = Ease.OutBack;


    [Header("Animation Player")]
    public string BoolRun = "Run";
    public string triggerDeath = "Death";
}
