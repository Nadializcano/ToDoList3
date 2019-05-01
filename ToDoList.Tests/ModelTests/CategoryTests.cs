using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod] //test to confirm contructor can successully creat Category objects
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod] //test that a Category can successully retrieve its name.
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      string result = newCategory.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]//test we can retrieve CategoryId (integer)
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      int result = newCategory.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod] //test retrieve all Category objects to display
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()

    {
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);
      List<Category> newList = new List<Category> { newCategory1, newCategory2 };

      List<Category> result = Category.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod] //test if method Find() locates and displays specific Category Objects
    public void Find_ReturnsCorrectCategory_Category()
    {
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 =  new Category(name02);

      Category result = Category.Find(2);

      Assert.AreEqual(newCategory2, result);
    }

    [TestMethod] // we assert that calling a GetItems () method on a Category correctly returns an empty List meatn to hold Item s
    public void GetItems_ReturnsEmptyItemList_ItemList()
    {
      string name = "Work";
      Category newCategory = new Category(name);
      List<Item> newList = new List<Item> { };

      List<Item> result = newCategory.GetItems();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      string description = "Walk the dog";
      Item newItem = new Item(description);// created a new Item and added it to a List
      List<Item> newList = new List<Item> { newItem};
      string name = "Work";
      Category newCategory = new Category(name); //created a new Category and call AddItem upon it passing in our sample Item.
      newCategory.AddItem(newItem);

      List<Item> result = newCategory.GetItems();//call newCategory.GetItems( ) to return our single Item 

      CollectionAssert.AreEqual(newList, result);
    }
  }
}
