﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4302C95EC7E436DF7AAB53D9C735D093C2D8DD14"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OBD;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OBD {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Directory;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Hall;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exhibition;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Organizator;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Settler;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ticket;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Profession;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Worker;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Work_Drid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame mainFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OBD;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Directory = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\MainWindow.xaml"
            this.Directory.Click += new System.Windows.RoutedEventHandler(this.Directory_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Hall = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\MainWindow.xaml"
            this.Hall.Click += new System.Windows.RoutedEventHandler(this.Hall_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Exhibition = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\MainWindow.xaml"
            this.Exhibition.Click += new System.Windows.RoutedEventHandler(this.Exhibition_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Organizator = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.Organizator.Click += new System.Windows.RoutedEventHandler(this.Organizator_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Settler = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.Settler.Click += new System.Windows.RoutedEventHandler(this.Settler_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Ticket = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\MainWindow.xaml"
            this.Ticket.Click += new System.Windows.RoutedEventHandler(this.Ticket_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Profession = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.Profession.Click += new System.Windows.RoutedEventHandler(this.Profession_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Worker = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\MainWindow.xaml"
            this.Worker.Click += new System.Windows.RoutedEventHandler(this.Worker_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Work_Drid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.mainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

