using System.Collections.Generic;
using UnityEngine;



public class SearchingPlanet : CommonPlanet
{
    [SerializeField] private ContactFilter2D searchingFilter = default;
    [SerializeField] private CircleCollider2D searchingArea = null;
    [SerializeField] private float areaSize = 1.5f;

    private Collider2D[] foundColls;



    private void Awake()
    {
        foundColls = new Collider2D[1];

        if (searchingArea != null)
        {
            searchingArea.radius = areaSize;
        }
    }

    protected override void Update()
    {
        if (FoundPlanet())
        {
            targetPosition = foundColls[0].gameObject.transform.position;
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
