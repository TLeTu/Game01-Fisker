using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpear : MonoBehaviour
{
    SpearManager spearManager;
    DestinationPoint destinationPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveSpeedMultiplier;
    private void Start()
    {
        spearManager = SpearManager.Instance;
        destinationPoint = DestinationPoint.Instance;
    }

    public void Spawn(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(position.x, 7, 0);
    }
    public void Move(Transform target)
    {
        _moveSpeed = (10 + (7 - target.position.y) * 2) * _moveSpeedMultiplier;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestinationPoint"))
        {
            if (destinationPoint.fishIn && destinationPoint.CaughtFish != null)
            {
                // --- LOGIC FIRST ---
                // 1. Get data from the fish before doing anything else.
                int scoreFromFish = destinationPoint.CaughtFish.Data.ScoreValue;
                Fish caughtFishObject = destinationPoint.CaughtFish;

                // 2. Update the score.
                GameManager.Instance.Score += scoreFromFish;

                // 3. Tell the SpearManager to respawn the spear.
                spearManager.spearLanded = true;
                Debug.Log($"Caught a {caughtFishObject.Data.FishName}! Gained {scoreFromFish} points.");

                // --- DEACTIVATIONS LAST ---
                // 4. Deactivate the fish that was caught.
                caughtFishObject.gameObject.SetActive(false);

                // 5. Deactivate the destination point.
                collision.gameObject.SetActive(false);
            }
            else
            {
                // This is a miss.
                spearManager.spearLanded = true;
                collision.gameObject.SetActive(false);
                Debug.Log("Missed!");
            }

            // Deactivate the spear itself now that all logic for this frame is done.
            gameObject.SetActive(false);
        }
    }
}
