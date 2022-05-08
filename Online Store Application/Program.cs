using Microsoft.Extensions.DependencyInjection;
using System;

namespace Online_Store_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceExtensions.BuildServices();
        }
    }
}