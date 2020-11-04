﻿#pragma checksum "..\..\..\..\Pages\MenuPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9237C85B3A721402EBDE0FAFAACC392C25E921F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dewey_Training;
using Dewey_Training.Pages;
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


namespace Dewey_Training.Pages {
    
    
    /// <summary>
    /// MenuPage
    /// </summary>
    public partial class MenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReplaceBooks;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IdentifyingAreas;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindCallNumbers;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewAllScores;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Difficulty;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn username;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn userScore;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn userTime;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ScoreSelection;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Dewey Training;component/pages/menupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MenuPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LoginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Pages\MenuPage.xaml"
            this.LoginBtn.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReplaceBooks = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Pages\MenuPage.xaml"
            this.ReplaceBooks.Click += new System.Windows.RoutedEventHandler(this.ReplaceBooks_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IdentifyingAreas = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Pages\MenuPage.xaml"
            this.IdentifyingAreas.Click += new System.Windows.RoutedEventHandler(this.IdentifyingAreas_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FindCallNumbers = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Pages\MenuPage.xaml"
            this.FindCallNumbers.Click += new System.Windows.RoutedEventHandler(this.FindCallNumbers_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ViewAllScores = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Pages\MenuPage.xaml"
            this.ViewAllScores.Click += new System.Windows.RoutedEventHandler(this.ViewAllScores_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Difficulty = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\Pages\MenuPage.xaml"
            this.Difficulty.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Difficulty_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\..\..\Pages\MenuPage.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.username = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.userScore = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.userTime = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.ScoreSelection = ((System.Windows.Controls.ComboBox)(target));
            
            #line 69 "..\..\..\..\Pages\MenuPage.xaml"
            this.ScoreSelection.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ScoreSelection_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

