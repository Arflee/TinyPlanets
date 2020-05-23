using System;
using System.Collections.Generic;
using UnityEngine;


namespace TinyPlanets.Planets
{
    public class SearchingPlanet : CommonPlanet
    {
        [SerializeField] private Collider2D searchingArea = null;
        [SerializeField] private ContactFilter2D contactFilter = default;

        private List<Collider2D> collidedPlanets;
        private bool planetLost = false;

        public override Vector2 TargetPosition => targetPosition;

        private void Start()
        {
            collidedPlanets = new List<Collider2D>();
            FindPlanet();
        }

        protected override void Update()
        {
            base.Update();

            if ((Vector2)transform.position == targetPosition || planetLost)
                targetPosition = GetTargetPosition();
            else
                FindPlanet();
        }

        private void FindPlanet()
        {
            searchingArea.OverlapCollider(contactFilter, collidedPlanets);

            if (collidedPlanets.Count > 0)
            {
                targetPosition = collidedPlanets[0].transform.position;
                planetLost = false;
            }
        }
    }
}

