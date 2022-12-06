using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    public Item inSlot = null;
    public Image iconInSlot;

    public Image iconOutSlot;
    public TMPro.TextMeshProUGUI countText;

    public int count = 0;
    public int Count
    {
        get { return count; }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
