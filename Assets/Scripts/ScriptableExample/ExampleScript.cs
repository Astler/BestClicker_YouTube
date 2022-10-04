using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField] private SpawnManagerScriptableObject spawnManagerScriptableObject;

    private void Start()
    {
        Debug.Log("spawnManagerScriptableObject prefab name: " + spawnManagerScriptableObject.prefabName);

        foreach (Vector3 spawnPoint in spawnManagerScriptableObject.spawnPoints)
        {
            Debug.Log("spawn point position: " + spawnPoint);
        }
    }
}