﻿using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";

            Server.Start(4, 26955); //Server Port

            Console.ReadKey();
        }
    }
}
