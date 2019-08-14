using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlanet : CommonPlanet
{
    [Header("Teleport settings")]
    [SerializeField] private float coolDown = 5f;
    [SerializeField] private GameObject teleportSign = null;

    private GameObject signObj;
    private float teleportTime;



    protected override void Start()
    {
        base.Start();

        Destroy(signObj);
        ResetCoolDown();
        targetPosition = GetRandomPosition();
    }

    protected override void Update()
    {
        if (teleportTime <= 0f)
        {
            Destroy(signObj);

            transform.position = targetPosition;
            targetPosition = GetRandomPosition();
            ResetCoolDown();
        }
        else
        {
            teleportTime -= Time.deltaTime;
        }
    }



    private void ResetCoolDown()
    {
        teleportTime = coolDown;
    }

    private void ShowTeleportSign(Vector2 pos)
    {
        signObj = Instantiate(teleportSign, pos, Quaternion.identity);
    }

    protected override Vector2 GetRandomPosition()
    {
        Vector2 output = base.GetRandomPosition();
        ShowTeleportSign(output);

        return output;
    }
}
