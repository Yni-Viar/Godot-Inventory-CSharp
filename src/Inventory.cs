using Godot;
using System;

public partial class Inventory : Node
{
    internal Godot.Collections.Dictionary dragData;

    [Signal]
    public delegate void ItemsChangedEventHandler(Godot.Collections.Array indexes);

    [Export]
    internal Godot.Collections.Array<Resource> items = new Godot.Collections.Array<Resource>{
        null, null, null, null, null, null, null, null, null, null
    };
    internal Resource SetItem(int itemIndex, Resource item)
    {
        Resource previousItem = items[itemIndex];
        items[itemIndex] = item;
        EmitSignal(SignalName.ItemsChanged, new Godot.Collections.Array{itemIndex});
        return previousItem;
    }

    internal void SwapItems(int itemIndex, int targetItemIndex)
    {
        Resource targetItem = items[targetItemIndex];
        Resource item = items[itemIndex];
        items[targetItemIndex] = item;
        items[itemIndex] = targetItem;
        EmitSignal(SignalName.ItemsChanged, new Godot.Collections.Array{itemIndex, targetItemIndex});
    }

    internal Resource RemoveItem(int itemIndex)
    {
        Resource previousItem = items[itemIndex];
        items[itemIndex] = null;
        EmitSignal(SignalName.ItemsChanged, new Godot.Collections.Array{itemIndex});
        return previousItem;
    }
}
