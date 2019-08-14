using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class DragAndDrop : MonoBehaviour
{
    private Collider2D planetCollider;
    private bool moveAllowed = false;



    private void Start()
    {
        planetCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    moveAllowed = planetCollider == touchedCollider;
                    
                    break;

                case TouchPhase.Moved:
                    if (moveAllowed)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }

                    break;

                case TouchPhase.Ended:
                    moveAllowed = false;

                    break;
            }
        }
    }
}