using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [Header("Data")]
    public FishData Data;
    [Header("Dependencies")]
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private Transform _lastMovePoint;

    private void Awake()
    {
        if (_lastMovePoint == null)
        {
            Debug.LogError( transform.name + "Move point is null", gameObject);
        }   
    }

    // This method will be called by the spawner right after the fish is created
    public void Setup(FishData data, FishSpawner fishSpawner)
    {
        Data = data;
        _fishSpawner = fishSpawner;

        // Get the data from the SO
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && Data.Sprite != null)
        {
            spriteRenderer.sprite = Data.Sprite;
        }

    }

    private void Update()
    {
        if (Data == null || _lastMovePoint == null) return;
        Move();
        if (transform.position == _lastMovePoint.position)
        {
            _fishSpawner.ReturnFishToPool(this);
        }
    }


    private void Move()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        Vector3 point = Vector3.MoveTowards(transform.position, _lastMovePoint.position, Data.MoveSpeed * Time.deltaTime);
        LookAtMovePoint(point);
        transform.position = point;
    }
    private void LookAtMovePoint(Vector3 point){
        Vector3 diff = transform.position - point;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    public void SetMovePoint(Transform movePoint)
    {
        _lastMovePoint = movePoint;

        if (_lastMovePoint != null)
        {
            LookAtMovePoint(_lastMovePoint.position);
        }
    }
    
}