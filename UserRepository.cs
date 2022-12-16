using FlightBackend.Models;
using FlightBackend.Repository;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : IDataRepository<User>
{
    RegisterDBEntities _userdbcontext;
    public UserRepository(RegisterDBEntities userdbcontext)
    {
        _userdbcontext = userdbcontext;
    }
    public void Add(User newuser)
    {
        _userdbcontext.Users.Add(newuser);
        _userdbcontext.SaveChanges();
    }
    public IEnumerable<User> GetAll()
    {
        return _userdbcontext.Users.ToList();
    }
}