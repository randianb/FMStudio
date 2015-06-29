﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FMStudio.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private void HandleException(Exception exception)
        {
            if (exception != null)
                MessageBox.Show("I'm sorry, the app crashed because of this: " + Environment.NewLine + Environment.NewLine + UnwrapException(exception));
            else
                MessageBox.Show("I'm sorry, the app crashed and I don't know why :'(");
        }

        private string UnwrapException(Exception exception)
        {
            var message = exception.GetType().ToString() + Environment.NewLine + exception.Message;

            if(exception.InnerException != null)
                return message + Environment.NewLine + Environment.NewLine + UnwrapException(exception.InnerException);

            return message;
        }
    }
}