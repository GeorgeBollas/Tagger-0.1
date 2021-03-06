﻿using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Tagger.Data;
using Tagger.Data.Sql;
using Tagger.Services;
using Tagger.Views;

namespace Tagger.ViewModels
{
    public class ViewModelLocator
    {
        //todo fix this hack
        static bool isInitialized = false;
        public ViewModelLocator()
        {
            if (isInitialized) return;

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ITaggerDataContext, TaggerDataContext>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<ITagsService, TagsService>();


            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();

            Register<MainViewModel, MainPage>();
            Register<TagManagerViewModel, TagManagerPage>();
            Register<SearchViewModel, SearchPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<UriSchemeExampleViewModel, UriSchemeExamplePage>();

            Register<EditTagTypeViewModel,EditTagTypePage>();
            isInitialized = true;
        }

        public EditTagTypeViewModel EditTagTypeViewModel => ServiceLocator.Current.GetInstance<EditTagTypeViewModel>();

        public UriSchemeExampleViewModel UriSchemeExampleViewModel => ServiceLocator.Current.GetInstance<UriSchemeExampleViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public SearchViewModel SearchViewModel => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public TagManagerViewModel TagManagerViewModel => ServiceLocator.Current.GetInstance<TagManagerViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
