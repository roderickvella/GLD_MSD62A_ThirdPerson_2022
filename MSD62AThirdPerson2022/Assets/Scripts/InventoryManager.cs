using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Tooltip("Number of items in inventory")]
    public int numberOfItems = 5;

    [Tooltip("Items Selection Panel")]
    public GameObject itemsSelectionPanel;

    [Tooltip("List of items")]
    public List<ItemScriptableObject> itemsAvailable;

    [Tooltip("Selected Item Colour")]
    public Color selectedColour;

    [Tooltip("Not Selected Item Colour")]
    public Color notSelectedColour;

    private List<InventoryItem> itemsForPlayer; //the items visible to the player during the game

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();
        PopulateInventorySpawn();
        RefreshInventoryGUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            ChangeSelection();
    }

    private void ChangeSelection()
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

            if(countItems == 0)
            {
                //add objItem with quantity of 1 because it is the first type inside itemsForPlayer
                itemsForPlayer.Add(new InventoryItem() { item = objItem, quantity = 1 });
            }
            else
            {
                //search for the element of the same type inside itemsForPlayer
                var item = itemsForPlayer.First(x => x.item == objItem);
                //increase the quantity by 1
                item.quantity += 1;
            }


        }

        print("Number of Inventory Items for Player:"+ itemsForPlayer.Count);

    }

    private void RefreshInventoryGUI(){
        int buttonId = 0;

        foreach(InventoryItem i in itemsForPlayer)
        {
            //load the button
            GameObject button = itemsSelectionPanel.transform.Find("Button" + buttonId).gameObject;

            //search for the child image and change its sprite
            button.transform.Find("Image").GetComponent<Image>().sprite = i.item.icon;

            //change the quantity
            button.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = "x" + i.quantity;

            buttonId += 1;

        }

        //set active false redundant buttons
        for(int i=buttonId; i<3; i++)
        {
            itemsSelectionPanel.transform.Find("Button" + i).gameObject.SetActive(false);
        }

    }

    public class InventoryItem
    {
        public ItemScriptableObject item { get; set; }
        public int quantity { get; set; }
    }
}
