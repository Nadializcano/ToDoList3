using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Item> _items;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count; //assing an _id number equal to the number of Gategory s in _instances
      _items = new List<Item>{}; //_items property is an empty list to eventually contain Item objects that belong to this Category
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Category> GetAll()
    {
      return _instances;
    }

    public static Category Find(int searchId) // it accepts an ID as an argument, then locates the Category in the static _instances array that matches
    {
      return _instances[searchId-1];
    }

    public List<Item> GetItems()
    {
      return _items;
    }

    public void AddItem(Item item) // will accept a Item object and then use the built-in List Add() method to save that into _items property of a specific Category
    {
      _items.Add(item);
    }
  }
}
