using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;



public class SearchingPlanet : CommonPlanet
{
    [SerializeField] private ContactFilter2D searchingFilter = default;
    [SerializeField] private CircleCollider2D searchingArea = null;
    [SerializeField] private float areaSize = 1.5f;

    private Collider2D[] foundColls;
    private Collider2D previousColl = null;



    private void Awake()
    {
        int amount = FindObjectsOfType<CommonPlanet>().Length;
        foundColls = new Collider2D[amount - 1];

        if (searchingArea != null)
        {
            searchingArea.radius = areaSize;
        }
    }

    protected override void Update()
    {
        if (FoundPlanet())
        {
            if (foundColls.Contains(previousColl) && previousColl != null)
            {
                targetPosition = previousColl.gameObject.transform.position;
            }
            else
            {
                targetPosition = foundColls[0].gameObject.transform.position;
                previousColl = foundColls[0];
            }
        }
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision) { return; }



    private bool FoundPlanet()
    {
        searchingArea.OverlapCollider(searchingFilter, foundColls);
        return searchingArea.IsTouching(foundColls[0]);
    }
}
