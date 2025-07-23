using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private List<FishData> _fishTypes;
    [SerializeField] private Transform _fishHolder;
    [Header("Pool")]
    [SerializeField] private List<Fish> _pool;

    private void Start()
    {
        if (_pool == null)
        {
        _pool = new List<Fish>();
        }
    }

    public Fish SpawnFish(Transform spawnPoint, Transform movePoint)
    {
        if (_fishTypes.Count == 0)
        {
            Debug.LogError("No FishData", this);
            return null;
        }
        FishData selectedData = _fishTypes[Random.Range(0, _fishTypes.Count)];
        Fish fish = GetFishFromPool();
        if (fish == null)
        {
            Fish fishPrefab = selectedData.FishPrefab;
            if (fishPrefab == null)
            {
                Debug.LogError("FishPrefab is null", this);
                return null;
            }
            fish = Instantiate(fishPrefab, spawnPoint.position, Quaternion.identity, _fishHolder);
            _pool.Add(fish);
        }
        fish.gameObject.name = selectedData.FishName;
        fish.transform.position = spawnPoint.position;
        fish.Setup(selectedData, this);
        fish.SetMovePoint(movePoint);
        fish.gameObject.SetActive(true);
        return fish;
    }

    private Fish GetFishFromPool()
    {
        foreach (var fish in _pool)
        {
            if (!fish.gameObject.activeInHierarchy )
            {
                return fish;
            }
        }
        return null;
    }

    public void ReturnFishToPool(Fish fish)
    {
        fish.gameObject.SetActive(false);
    }

    public void ReturnAllFishToPool()
    {
        foreach (var fish in _pool)
        {
            if (fish != null && fish.gameObject != null)
            {
                fish.gameObject.SetActive(false);
            }
        }

    }
}
