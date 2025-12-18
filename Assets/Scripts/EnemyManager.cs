using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemies")]
    public GameObject triangle;
    public GameObject square;
    public GameObject circle;
    public GameObject capsule;
    public GameObject bomb;
    public GameObject hexagon;
    public float triangleSpeed = 2f;
    public float squareSpeed = 0.8f;
    public float circleSpeed = 3.1f;
    public float capsuleSpeed = 2f;
    public float bombSpeed = 2.5f;
    public float hexagonSpeed = 3f;

    [Header("Player")]
    public GameObject player;

    [Header("Boundaries")]
    public float unitsOutOfBounds = 1f;

    [Header("Spawning")]
    public float triangleSpawnInterval = 5f;
    public float squareSpawnInterval = 25f;
    public float circleSpawnInterval = 30f;
    public float capsuleSpawnInterval = 50f;
    public float bombSpawnInterval = 75f;
    public float hexagonSpawnInterval = 100f;
    private float triangleTimer;
    private float squareTimer;
    private float circleTimer;
    private float capsuleTimer;
    private float bombTimer;
    private float hexagonTimer;

    [Header("Bounds")]
    private Vector2 boundsMin = new Vector2(-10.62f, -4.97f);
    private Vector2 boundsMax = new Vector2(10.62f, 4.97f);

    [Header("Triangle")]
    public TriangleMovement triangleMovement;

    [Header("Square")]
    public SquareMovement squareMovement;

    [Header("Circle")]
    public CircleMovement circleMovement;

    [Header("Capsule")]
    public CapsuleMovement capsuleMovement;

    [Header("Bomb")]
    public BombMovement bombMovement;

    [Header("Hexagon")]
    public HexagonMovement hexagonMovement;

    [Header("Debug")]
    public bool noTriangles;
    public bool noSquares;
    public bool noCircles;
    public bool noCapsules;
    public bool noBombs;
    public bool noHexagons;
    public bool squaresMinusFiveInterval;
    public bool squareSpeedQuickIncrease;
    public bool instantCircle;
    public bool instantCapsule;
    public bool instantBomb;
    public bool instantHexagon;

    void Start() {
        if(instantCircle) {
            circleSpawnInterval = 2f;
        }
        if(instantCapsule) {
            capsuleSpawnInterval = 2f;
        }
        if(instantBomb)
        {
            bombSpawnInterval = 2f;
        }
        if(instantHexagon)
        {
            hexagonSpawnInterval = 2f;
        }
    }

    void Update()
    {
        if (!noTriangles)
        {
            triangleTimer += Time.deltaTime;
            if (triangleTimer >= triangleSpawnInterval)
            {
                // Spawn enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneTriangle = Instantiate(triangle, spawnPos, Quaternion.identity);
                cloneTriangle.tag = "Triangle";
                cloneTriangle.SetActive(true);

                if (triangleSpawnInterval > 1f)
                {
                    triangleSpawnInterval -= 0.05f;
                }
                if (triangleSpeed < 3.9f)
                {
                    triangleSpeed += 0.05f;
                    triangleMovement.speed = triangleSpeed;
                }
                triangleTimer = 0f;
            }
        }

        if (!noSquares)
        {
            squareTimer += Time.deltaTime;
            if (squareTimer >= squareSpawnInterval)
            {
                // Spawn enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneSquare = Instantiate(square, spawnPos, Quaternion.identity);
                cloneSquare.tag = "Square";
                cloneSquare.SetActive(true);

                if (squareSpawnInterval > 10f)
                {
                    if(!squaresMinusFiveInterval) {
                        squareSpawnInterval -= 0.2f;
                    } else {
                        squareSpawnInterval -= 5f;
                    }
                }
                if (squareSpeed < 1.2f)
                {
                    if(!squareSpeedQuickIncrease) {
                        squareSpeed += 0.05f;
                        squareMovement.speed = squareSpeed;
                    } else {
                        squareSpeed += 0.4f;
                        squareMovement.speed = squareSpeed;
                    }
                }
                squareTimer = 0f;
            }
        }

        if (!noCircles)
        {
            circleTimer += Time.deltaTime;
            if (circleTimer >= circleSpawnInterval)
            {
                // Spawns enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneCircle = Instantiate(circle, spawnPos, Quaternion.identity);
                cloneCircle.tag = "Circle";
                cloneCircle.SetActive(true);

                if (circleSpawnInterval == 30f)
                {
                    circleSpawnInterval = 7f;
                } else if(circleSpawnInterval > 3f) {
                    circleSpawnInterval -= 0.05f;
                }
                if (circleSpeed < 4.5f)
                {
                    circleSpeed += 0.1f;
                    circleMovement.speed = circleSpeed;
                }
                circleTimer = 0f;
            }
        }

        if (!noCapsules)
        {
            capsuleTimer += Time.deltaTime;
            if (capsuleTimer >= capsuleSpawnInterval)
            {
                // Spawns enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneCapsule = Instantiate(capsule, spawnPos, Quaternion.identity);
                cloneCapsule.tag = "Capsule";
                cloneCapsule.SetActive(true);

                if (capsuleSpawnInterval == 50f)
                {
                    capsuleSpawnInterval = 15f;
                } else if(capsuleSpawnInterval > 10f) {
                    capsuleSpawnInterval -= 0.1f;
                }
                if (capsuleSpeed < 3.2f)
                {
                    capsuleSpeed += 0.05f;
                    capsuleMovement.speed = capsuleSpeed;
                }
                capsuleTimer = 0f;
            }
        }

        if (!noBombs)
        {
            bombTimer += Time.deltaTime;
            if (bombTimer >= bombSpawnInterval)
            {
                // Spawns enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneBomb = Instantiate(bomb, spawnPos, Quaternion.identity);
                cloneBomb.tag = "Bomb";
                cloneBomb.SetActive(true);

                if (bombSpawnInterval == 75f)
                {
                    bombSpawnInterval = 50f;
                } else if(bombSpawnInterval > 35f) {
                    bombSpawnInterval -= 0.5f;
                }
                if (bombSpeed < 4f)
                {
                    bombSpeed += 0.05f;
                    bombMovement.speed = bombSpeed;
                }
                bombTimer = 0f;
            }
        }

        if (!noHexagons)
        {
            hexagonTimer += Time.deltaTime;
            if (hexagonTimer >= hexagonSpawnInterval)
            {
                // Spawns enemy on a random side
                int side = Random.Range(0, 4);
                Vector2 spawnPos;

                if (side == 0) // Top
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMax.y + unitsOutOfBounds);
                else if (side == 1) // Bottom
                    spawnPos = new Vector2(Random.Range(boundsMin.x, boundsMax.x), boundsMin.y - unitsOutOfBounds);
                else if (side == 2) // Left
                    spawnPos = new Vector2(boundsMin.x - unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));
                else // Right
                    spawnPos = new Vector2(boundsMax.x + unitsOutOfBounds, Random.Range(boundsMin.y, boundsMax.y));

                GameObject cloneHexagon = Instantiate(hexagon, spawnPos, Quaternion.identity);
                cloneHexagon.tag = "Hexagon";
                cloneHexagon.SetActive(true);

                if (hexagonSpawnInterval == 100f)
                {
                    hexagonSpawnInterval = 60f;
                } else if(hexagonSpawnInterval > 40f) {
                    hexagonSpawnInterval -= 0.5f;
                }
                
                hexagonTimer = 0f;
            }
        }
    }
}