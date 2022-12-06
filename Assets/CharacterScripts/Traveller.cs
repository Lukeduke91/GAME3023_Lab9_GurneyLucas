using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Traveller : MonoBehaviour
{
    public UnityEvent<Scene> OnTransportToNewScene;

    private string lastSpawn = "";
    public void SetSpawn(string spawn)
    {
        lastSpawn = spawn;
    }
    
    private void Start()
    {
#if UNITY_EDITOR //This is a convenience function only to be used while we keep player characters in all the scenes.
        EditorKillClones();
#endif
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoadedAction;
    }

    void OnSceneLoadedAction(Scene scene, LoadSceneMode loadMode)
    {
        if(lastSpawn != "")
        {
            bool transportSuccessful = false;

            PlayerSpawn[] spawnPoints = FindObjectsOfType<PlayerSpawn>();
            foreach(PlayerSpawn spawn in spawnPoints)
            {
                if (spawn.name == lastSpawn)
                {
                    transform.position = spawn.transform.position;
                    transportSuccessful = true;
                    break;
                }
            }
            if(!transportSuccessful)
            {
                throw new System.Exception("Could not find spawn point: " + lastSpawn);
            }
        }
    }

    private void EditorKillClones()
    {
        if(PlayerSpawn.Player != GetComponent<PlayerCharacterMovement>())
        {
            Destroy(this);
        }
    }
}
