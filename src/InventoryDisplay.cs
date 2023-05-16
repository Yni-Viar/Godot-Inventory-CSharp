using Godot;
using System;

public partial class InventoryDisplay : GridContainer
{
    Inventory inventory = new Inventory();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        inventory = GetParent().GetParent().GetNode<Inventory>("Inventory");
        inventory.ItemsChanged += OnItemsChanged;
        GD.Print(inventory.items);
        UpdateInventoryDisplay();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    void UpdateInventoryDisplay()
    {
        for (int itemIndex = 0; itemIndex < inventory.items.Count; itemIndex++)
        {
            UpdateInventorySlotDisplay(itemIndex);
        }
    }

    void UpdateInventorySlotDisplay(int itemIndex)
    {
        InventorySlotDisplay inventorySlotDisplay = GetChild<InventorySlotDisplay>(itemIndex);
        Resource item = inventory.items[itemIndex];
        inventorySlotDisplay.DisplayItem(item);
    }

    void OnItemsChanged(Godot.Collections.Array indexes)
    {
        foreach (int itemIndex in indexes)
        {
            UpdateInventorySlotDisplay(itemIndex);
        }
    }
}
