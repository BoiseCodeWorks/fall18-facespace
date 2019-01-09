using System.Collections.Generic;

namespace consoleProfile.Models
{
  class User
  {
    public string Username { get; private set; }
    private string Password { get; set; }

    public Dictionary<string, User> Friends { get; set; }


    public User(string username, string pass)
    {
      Username = username;
      Password = pass;
      Friends = new Dictionary<string, User>();
    }
    public bool ValidatePassword(string pass)
    {
      return pass == Password;
    }
  }
}