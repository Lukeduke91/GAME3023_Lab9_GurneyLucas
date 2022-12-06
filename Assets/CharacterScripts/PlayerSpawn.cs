using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private static PlayerCharacterMovement player = null;
    public static PlayerCharacterMovement Player
    {
        get { return player;
        }
        private set {}
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(player == null)
        {
            GameObject gameObject = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player = gameObject.GetComponent<PlayerCharacterMovement>();
        }
    }
}
