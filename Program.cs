using System;
using consoleProfile.Models;
using System.Collections.Generic;
using consoleProfile.Services;

namespace consoleProfile
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      AppService appService = new AppService();
      appService.Setup();

      Console.WriteLine("Hello and Welcome to FaceSpace!");

      Console.WriteLine("What would you like to do?");
      Console.WriteLine("1 : Login");
      Console.WriteLine("2 : Register");
      string choice = Console.ReadLine();
      if (choice == "1")
      {
        //Should go to login
        appService.Login();
      }
      if (choice == "2")
      {
        //Should go to reggie
        appService.Register();
      }
      appService.viewFriends();
    }
  }
}
