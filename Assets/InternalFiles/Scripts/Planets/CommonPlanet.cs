using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(DragAndDrop))]
public class CommonPlanet : MonoBehaviour
{
    [Header("Outer position values")]
    [SerializeField] private float minX = -8.2f;
    [SerializeField] private float minY = -4.2f;
    [SerializeField] private float maxX = 8.2f;
    [SerializeField] private float maxY = 4.2f;

    [Header("Difficulty settings")]
    [SerializeField] protected float secondsToMaxDifficulty = 60f;
    [SerializeField] protected float minSpeed = 0.5f;
    [SerializeField] protected float maxSpeed = 1.5f;

    protected float speed = 5f;
    protected Vector2 targetPosition;
    private GameMaster gameMaster;


    protected virtual void Start()
    {
        targetPosition = GetRandomPosition();
        FindGameMaster();
    }

    protected virtual void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = 
                Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CommonPlanet>() != null)
        {
            gameMaster.ShowRestartPanel();
        }
    }



    protected Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    protected float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

    protected void FindGameMaster()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
    }
}
