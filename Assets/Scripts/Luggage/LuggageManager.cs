using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageManager : MonoBehaviour
{
    public const int LuggagePlaneLayer = 8;

    public static LuggageManager instance;

    public LuggageList luggageList;

    public Transform luggageSpawnPosition;

    //toss times
    public float minSpawnTime = 1;
    public float maxSpawnTime = 5;

    public float spawnSpeed;
    public float spawnSpin;

    [Space(20)]
    public GameObject luggagePopPrefab;
    public Sprite[] luggagePopSprites;
    [Range(0f, 1f)] public float luggagePopChance;
    public int luggagePopCountMax;
    public Vector2 luggagePopVelocity;

    [Space(20)]
    public GameObject fallingCatPrefab;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnLuggageOverTime());
    }

    //private void FixedUpdate()
    //{
    //    //counting up
    //    time += Time.deltaTime;

    //    //check for spawn
    //    if(time >= spawnTime)
    //    {
    //        SpawnLuggage();
    //        SetRandomTime();
    //    }
    //}

    void SpawnLuggage()
    {
        // Get a random rotation snapped to 90 degrees and apply it to our rotation
        Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)) * luggageSpawnPosition.rotation;
        GameObject luggage = Instantiate(luggageList.GetRandom(), luggageSpawnPosition.position, rotation);

        Rigidbody2D rigidbody = luggage.GetComponent<Rigidbody2D>();
        rigidbody.velocity = luggageSpawnPosition.right * spawnSpeed;
        rigidbody.angularVelocity = Random.value * spawnSpin;

        luggage.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 1f, 1f);
    }

    IEnumerator SpawnLuggageOverTime()
    {
        while (true)
        {
            // Pick random wait time
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            float time = 0f;

            // Wait
            while (time < waitTime)
            {
                time += Time.deltaTime;
                yield return null;
            }

            SpawnLuggage();
        }
    }
}