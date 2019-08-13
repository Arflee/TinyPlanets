using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class DragAndDrop : MonoBehaviour
{
    private Collider2D planetCollider;
    private bool moveAllowed = false;



    void Start()
    {
        planetCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (planetCollider == touchedCollider)
                    {
                        moveAllowed = true;
                    }
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