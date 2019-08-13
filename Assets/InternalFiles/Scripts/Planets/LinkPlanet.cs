using System.Linq;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class LinkPlanet : CommonPlanet
{
    private List<GameObject> otherPlanets;
    private LineRenderer planetLine;
    private GameObject chosenPlanet;



    private void Awake()
    {
        FindPlanets();

        planetLine = GetComponent<LineRenderer>();
        planetLine.positionCount = 2;
    }

    protected override void Start()
    {
        FindGameMaster();
        ChooseRandomPlanet();
    }

    protected override void Update()
    {
        targetPosition = chosenPlanet.transform.position;
        DrawLine();

        base.Update();
    }



    private void DrawLine()
    {
        planetLine.SetPosition(0, this.gameObject.transform.position);
        planetLine.SetPosition(1, chosenPlanet.transform.position);
    }

    private void ChooseRandomPlanet()
    {
        int randomIndex = Random.Range(0, otherPlanets.Count);
        chosenPlanet = otherPlanets[randomIndex];
        targetPosition = chosenPlanet.transform.position;
    }

    private void FindPlanets()
    {
        otherPlanets = GameObject.FindGameObjectsWithTag("LinkPlanet").ToList();
        GameObject planetItself = otherPlanets.Find((o) => { return gameObject == o; });
        otherPlanets.Remove(planetItself);
    }
}
