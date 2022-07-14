using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPatrol : MonoBehaviour
{
    public float mMovementSpeed = 3.0f;
    public bool bIsGoingRight = true;
    public float unitToMove = 10f;
    public SpriteRenderer _mSpriteRenderer;
    public Transform _localTransform;
    public float PatrolLimit;
    public float x;
    public bool debugOff = true;
    public Rigidbody2D myRigidbody;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_localTransform.position.x);
    //    _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _mSpriteRenderer.flipX = bIsGoingRight;
        //  _localTransform = gameObject.GetComponent<Transform>();
        PatrolLimit = _localTransform.position.x;
    }


    void Update()
    {
          if (debugOff)
          {
              AntDebug();
          }

         if (!debugOff)
        {
       
            Vector3 directionTranslation = (bIsGoingRight) ? transform.right : -transform.right;
            directionTranslation *= Time.deltaTime * mMovementSpeed;
            if( x == -1)
            {
                myRigidbody.transform.DOScaleX(1, .02f);
            }
            else
            {
                myRigidbody.transform.DOScaleX(-1, .02f);
            }

            transform.Translate(directionTranslation * x);
            if (_localTransform.position.x < PatrolLimit)
            {
                x = 1;
            }
            else if (_localTransform.position.x > unitToMove)
            {
                x = -1;
            }

        }
        //CheckForWalls();
    }
    public void AntDebug()
    {
        Vector3 mov = (bIsGoingRight) ? transform.right : -transform.right;
        mov *= Time.deltaTime * mMovementSpeed;
        transform.Translate(mov);
        myRigidbody.transform.DOScaleX(-1, .02f);
        Invoke(nameof(setDebugOFF), duration);
    }

    public void setDebugOFF()
    {
        debugOff = false;
    }
}
