﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;

namespace Linq2Acad
{
  public abstract class DBDictionaryEnumerable<T> : NameBasedEnumerableBase<T> where T : DBObject
  {
    protected DBDictionaryEnumerable(Database database, Transaction transaction, ObjectId containerID)
      : base(database, transaction, containerID, i => ((DBDictionaryEntry)i).Value)
    {
    }

    public override sealed bool Contains(ObjectId id)
    {
      return ((DBDictionary)transaction.GetObject(ID, OpenMode.ForRead)).Contains(id);
    }

    public override sealed bool Contains(string name)
    {
      return ((DBDictionary)transaction.GetObject(ID, OpenMode.ForRead)).Contains(name);
    }

    public override sealed T Element(string name)
    {
      var dict = (DBDictionary)transaction.GetObject(ID, OpenMode.ForRead);

      try
      {
        return (T)transaction.GetObject(dict.GetAt(name), OpenMode.ForRead);
      }
      catch
      {
        throw Error.KeyNotFound("No element with key " + name + " found");
      }
    }

    public override sealed int Count()
    {
      return ((DBDictionary)transaction.GetObject(ID, OpenMode.ForRead)).Count;
    }

    public void Add(string name, T item)
    {
      if (!AcadDatabase.IsNameValid(name))
      {
        throw Error.InvalidName(name);
      }

      var dict = (DBDictionary)transaction.GetObject(ID, OpenMode.ForWrite);

      if (dict.Contains(name))
      {
        throw Error.Generic(typeof(T).Name + " " + name + " already exists");
      }

      var id = dict.SetAt(name, item);
      transaction.AddNewlyCreatedDBObject(item, true);
    }

    protected abstract T CreateNew();

    public T Create(string name)
    {
      if (!AcadDatabase.IsNameValid(name))
      {
        throw Error.InvalidName(name);
      }

      var item = CreateNew();
      Add(name, item);
      return item;
    }
  }
}
