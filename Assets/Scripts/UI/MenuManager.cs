using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _spawnPoint;

    public void CloseMenu()
    {
        Invoke(nameof(DeactivateMenu), 0.05f);
    }

    private void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    public void SpawnObjectFromInventory(GameObject prefabToSpawn)
    {
        _spawner.SpawnPrefab(prefabToSpawn);
    }
}
