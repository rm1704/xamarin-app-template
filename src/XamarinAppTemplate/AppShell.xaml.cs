﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinAppTemplate.Helpers;

namespace XamarinAppTemplate
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();

        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("test", new TestRoute());

        }
    }
}
