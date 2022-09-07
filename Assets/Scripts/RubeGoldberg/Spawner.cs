using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointObject;
    public InputActionReference placeSpawnedItemButton;

    private GameObject _objectToPlace;
    private bool _objectReadyToPlace = false;
    
    // Start is called before the first frame update
    void Start()
    {
        placeSpawnedItemButton.action.started += PlaceSpawnedItem;
    }

    private void PlaceSpawnedItem(InputAction.CallbackContext obj)
    {
        if (_objectReadyToPlace)
        {
            List<Rigidbody> rigidbodiesInObjectToPlace = new List<Rigidbody>();

            if (!_objectToPlace.GetComponent<KinematicSpawnable>())
            {
                if (_objectToPlace.TryGetComponent(out Rigidbody objectToPlaceRigidbody))
                {
                    rigidbodiesInObjectToPlace.Add(objectToPlaceRigidbody);
                }

                List<Rigidbody> rigidbodiesInChildren = _objectToPlace.GetComponentsInChildren<Rigidbody>().ToList();
            
                rigidbodiesInObjectToPlace.AddRange(rigidbodiesInChildren);

                foreach (Rigidbody rigidbodyToChange in rigidbodiesInObjectToPlace)
                {
                    rigidbodyToChange.useGravity = true;
                    rigidbodyToChange.isKinematic = false;
                }
            }
            
            _objectToPlace.transform.parent = null;
            _objectReadyToPlace = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPrefab(GameObject prefabToSpawn)
    {
        if (!_objectReadyToPlace)
        {
            // Spawn the prefab and parent it to the Spawn Point
            _objectToPlace = Instantiate(prefabToSpawn, _spawnPointObject.transform);
            _objectToPlace.transform.position = _spawnPointObject.transform.position;

            _objectReadyToPlace = true;
        }
    }
}
