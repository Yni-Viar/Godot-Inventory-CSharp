using Godot;
using System;

public partial class Item : Resource
{
    [Export]
    public string name { get; set; }

    [Export]
    public Texture2D texture { get; set; }

    public Item() : this(null, null) {}
    public Item(string _name, Texture2D _texture)
    {
        name = _name;
        texture = _texture;
    }
}
