﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Libraries;
using ProgrammingParadigms;

namespace DomainAbstractions
{
    /// <summary>
    /// This is the main window of the application. The output IUI in it takes the responsibility of getting the WPF UIElements 
    /// in a hierarchical calling order as it goes deeper in the abstractions wired to it. The output IEvent starts to execute once 
    /// the app starts running, which informs the abstraction who implements it to do the things it wants.
    /// ------------------------------------------------------------------------------------------------------------------
    /// Ports:
    /// 1. IEvent shutdown: input for close the window (exits the application)
    /// 2. IDataFlow&lt;bool&gt; visible: to enable(true) or disable(false, grey out) the UI
    /// 3. IDataFlow&lt;string&gt; title: the title of the window
    /// 4. IUI iuiStructure: all the IUI contained within the MainWindow
    /// 5. IEvent appStart: IEvent that is pushed out once window has been loaded
    /// </summary>

    public class MainWindow : IEvent, IDataFlow<bool>, IDataFlow<string> // shutdown, visible, title
    {
        // Properties -----------------------------------------------------------------
        public string InstanceName { get; set; } = "Default";

        // Private fields -----------------------------------------------------------------
        private Window window;

        // Ports -----------------------------------------------------------------
        private IUI iuiStructure;
        private IEvent appStart;
        private List<IEventHandler> eventHandlers = new List<IEventHandler>();

        /// <summary>
        /// Generates the main UI window of the application and emits a signal that the Application starts running.
        /// </summary>
        /// <param name="title">title of the window</param>
        public MainWindow(string title = "", double width = -1, double height = -1)
        {
            if (width < 0) width = SystemParameters.PrimaryScreenWidth * 0.6;
            if (height < 0) height = SystemParameters.PrimaryScreenHeight * 0.65;

            window = new Window()
            {
                Title = title,
                Width = width,
                Height = height,
                Background = Brushes.White,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowState = WindowState.Normal
            };

            window.Loaded += (object sender, RoutedEventArgs e) =>
            {
                appStart?.Execute();
            };

            window.Closed += (object sender, EventArgs e) => ((IEvent)this).Execute();

        }

        public void CreateUI()
        {
            window.Content = iuiStructure?.GetWPFElement();

        }

        public System.Windows.Application CreateApp()
        {
            System.Windows.Application app = new System.Windows.Application();
            return app;
        }

        public void Run(System.Windows.Application app = null)
        {
            if (app == null) app = CreateApp();

            app.Run(window);
        }

        private void PostWiringInitialize()
        {
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Sender = window;
            }
        }

        /// <summary>
        /// Brings the window to the foreground.
        /// </summary>
        public void BringToFront()
        {
            window.Activate();
            window.Focus();
        }

        // IEvent implementation -------------------------------------------------------
        void IEvent.Execute() => System.Windows.Application.Current.Shutdown();

        // IDataFlow<bool> implementation ----------------------------------------------
        bool IDataFlow<bool>.Data
        {
            get => window.IsEnabled;
            set => window.IsEnabled = value;
        }

        // IDataFlow<string> implementation
        string IDataFlow<string>.Data
        {
            get => window.Title;
            set => window.Title = value;
        }
    }
}
