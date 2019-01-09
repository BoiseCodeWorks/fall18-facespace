
using System;
using System.Collections.Generic;
using consoleProfile.Models;

namespace consoleProfile.Services
{
  class AppService
  {
    public User ActiveUser { get; private set; }
    private List<User> Users { get; set; }


    public void Setup()
    {
      User jim = new User("Jim", "123");
      User jill = new User("Jill", "123");
      User tim = new User("Tim", "123");
      User kim = new User("Kim", "123");
      User clyde = new User("Clyde", "123");

      jim.Friends.Add("wife", jill);

      jill.Friends.Add("stalker", jim);
      jill.Friends.Add("kim", kim);
      jill.Friends.Add("timmy", tim);


      clyde.Friends.Add("bro", jim);
      kim.Friends.Add("guy", clyde);

      Users.Add(jim);
      Users.Add(jill);
      Users.Add(kim);
      Users.Add(tim);
      Users.Add(clyde);


    }

    public User Login()
    {
      bool loggedIn = false;

      while (!loggedIn)
      {
        System.Console.Write("enter username:");
        string username = Console.ReadLine();
        System.Console.Write("enter password:");
        string userPass = Console.ReadLine();
        ActiveUser = Users.Find(u =>
        {
          return u.Username == username;
        });

        if (ActiveUser == null)
        {
          System.Console.WriteLine("Invalid username/password");
          continue;
        }
        if (ActiveUser.ValidatePassword(userPass))
        {
          System.Console.WriteLine("Successfully Logged in");
          loggedIn = true;
          break;
        }
        else
        {
          System.Console.WriteLine("Invalid username/password");
        }
      }

      return ActiveUser;
    }

    public User Register()
    {
      System.Console.Write("enter username:");
      string username = Console.ReadLine();
      System.Console.Write("enter password:");
      string userPass = Console.ReadLine();

      User newUser = new User(username, userPass);
      Users.Add(newUser);
      ActiveUser = newUser;
      return ActiveUser;

    }

    public void viewFriends()
    {
      Console.Clear();
      System.Console.WriteLine($"Currently Viewing {ActiveUser.Username}");
      System.Console.WriteLine($"{ ActiveUser.Username } has {ActiveUser.Friends.Count} friends");
      System.Console.WriteLine("Select the friend by typing in their nickname name");
      foreach (var friend in ActiveUser.Friends)
      {
        Console.WriteLine($"nickname: {friend.Key} - Username: ${friend.Value.Username}");
      }
      var userInput = Console.ReadLine();

      if (ActiveUser.Friends.ContainsKey(userInput))
      {
        ActiveUser = ActiveUser.Friends[userInput];
      }
      viewFriends();
    }

    public AppService()
    {
      Users = new List<User>();
    }
  }
}