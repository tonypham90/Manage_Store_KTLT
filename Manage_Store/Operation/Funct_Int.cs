using Manage_Store.Entity;

namespace Manage_Store.Operation;

public class Item
{
    public string IDitem;
    public string Name;
    public bool IsDelete;
    

    public virtual bool AddItem()
    {
        throw new NotImplementedException();
    }
    
    public void RemoveItem()
    {
        IsDelete = true;
    }

    public virtual void UpdateItem()
    {
        throw new NotImplementedException();
    }
}

public interface Ilist
{
    virtual void Removesoft(string key)
    {
        throw new NotImplementedException();
    }

    virtual void Update(string key, Sp newSP)
    {
        throw new NotImplementedException();
    }

    virtual void AddNewItem()
    {
        throw new NotImplementedException();
    }
}