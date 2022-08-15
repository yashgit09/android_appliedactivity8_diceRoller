﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {

            return ConfigureApp
            .Android
            .InstalledApp("com.companyname.diceroller")
            .StartApp();

        }
    }
}
