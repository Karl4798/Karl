﻿#pragma checksum "..\..\..\..\Pages\IdentifyAreas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AC0938A2EA2B0C5D46225E2C628F55DBEA57D2B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dewey_Training.Pages;
using Dewey_Training.Services;
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
    /// IdentifyAreas
    /// </summary>
    public partial class IdentifyAreas : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxQuestions;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxAnswers;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Answer1;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Answer2;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Answer3;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Answer4;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Pages\IdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TimerLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Dewey Training;component/pages/identifyareas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\IdentifyAreas.xaml"
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
            this.listBoxQuestions = ((System.Windows.Controls.ListBox)(target));
            
            #line 14 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.listBoxQuestions.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxQuestions_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listBoxAnswers = ((System.Windows.Controls.ListBox)(target));
            
            #line 37 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.listBoxAnswers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxAnswers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Answer1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 59 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Answer1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Answer1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Answer2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 70 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Answer2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Answer2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Answer3 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Answer3.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Answer3_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Answer4 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 92 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Answer4.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Answer4_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Next = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\..\Pages\IdentifyAreas.xaml"
            this.Next.Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TimerLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

