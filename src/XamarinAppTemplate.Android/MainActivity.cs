﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Microsoft.Extensions.DependencyInjection;
using XamarinAppTemplate.Droid.Lang;
using Plugin.CurrentActivity;

namespace XamarinAppTemplate.Droid
{
    [Activity(Label = "XamarinAppTemplate", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Startup.Services.AddTransient<ILanguageManager, LanguageManagerAndroid>();

            base.OnCreate(savedInstanceState);

            
            RegisterPlugins(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Window.DecorView.LayoutDirection = LayoutDirection.Rtl;

        }

        private void RegisterPlugins(Bundle bundle)
        {
            DependencyService.Register<ToastNotification>();

            ToastNotification.Init(this);

            CrossCurrentActivity.Current.Init(this, bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}