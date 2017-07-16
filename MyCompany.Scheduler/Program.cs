// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler
{
    using System;

    using Microsoft.Owin.Hosting;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:7777/";

            using (WebApp.Start<Configurator>(baseAddress)) 
            { 
                Console.WriteLine("Scheduler REST service started on: {0}", baseAddress); 
                Console.ReadLine(); 
            } 
        }
    }
}
