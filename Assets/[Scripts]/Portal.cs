using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //[SerializeField]
    public string targetScene = "";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Portal Triggered with: " + collision.gameObject.name;
        Traveller traveller = collision.GetComponent<Traveller>();

        if (traveller != null)
        {
            Debug.Log("Portal Warping: " + traveller.gameObject.name);
            traveller.SetSpawn(targetScene);
            traveller.OnTransportToNewScene.Invoke(SceneManager.GetSceneByName(tag));
            SceneManager.LoadScene(tag, LoadSceneMode.Single);
        }
    }
}
