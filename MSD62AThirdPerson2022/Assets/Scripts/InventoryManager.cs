using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    [Tooltip("Number of items in inventory")]
    public int numberOfItems = 5;

    [Tooltip("Items Selection Panel")]
    public GameObject itemsSelectionPanel;

    [Tooltip("List of items")]
    public List<ItemScriptableObject> itemsAvailable;

    private List<InventoryItem> itemsForPlayer; //the items visible to the player during the game

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();
        PopulateInventorySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This method will generate the inventory items for the player to use
    /// during the game. The total number of inventory items cannot exceed
    /// the number set in the variable numberOfItems.
    /// </summary>
    private void PopulateInventorySpawn()
    {
        for(int i=0; i < numberOfItems; i++)
        {
            //pick random object from list itemsAvailable
            ItemScriptableObject objItem = itemsAvailable[Random.Range(0, itemsAvailable.Count)];

            //check whether objItem exits in itemsForPlayer. So basically we need to count how
            //many times an item appears. i.e the number of objItems inside itemsForPlayer
            int countItems = itemsForPlayer.Where(x => x.item == objItem).ToList().Count;

            itemsForPlayer.Add(new InventoryItem() { item = objItem, quantity = 1 });

            //->this code is like the above line
                //InventoryItem inventoryItem = new InventoryItem();
                //inventoryItem.item = objItem;
                //inventoryItem.quantity = 1;
                //itemsForPlayer.Add(inventoryItem);

        }

        print("Number of Inventory Items for Player:"+ itemsForPlayer.Count);

    }

    public class InventoryItem
    {
        public ItemScriptableObject item { get; set; }
        public int quantity { get; set; }
    }
}
