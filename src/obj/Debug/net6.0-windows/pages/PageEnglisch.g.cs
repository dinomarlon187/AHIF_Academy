﻿#pragma checksum "..\..\..\..\pages\PageEnglisch.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DB4F605A53D84E498286550B228018A924687447"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ahif_academy.pages;


namespace ahif_academy.pages {
    
    
    /// <summary>
    /// PageEnglisch
    /// </summary>
    public partial class PageEnglisch : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel lernen;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EnglishTextBlock;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GermanTextBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel addVoc;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewEnglishTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewGermanTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel liste;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox VocabularyListBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lernenButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addVocButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\pages\PageEnglisch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listeButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ahif_academy;component/pages/pageenglisch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\pages\PageEnglisch.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lernen = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.EnglishTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 19 "..\..\..\..\pages\PageEnglisch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GermanTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 22 "..\..\..\..\pages\PageEnglisch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Previous_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\..\..\pages\PageEnglisch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.addVoc = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.NewEnglishTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.NewGermanTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 32 "..\..\..\..\pages\PageEnglisch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddVocabulary_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.liste = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.VocabularyListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 13:
            
            #line 36 "..\..\..\..\pages\PageEnglisch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lernenButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\pages\PageEnglisch.xaml"
            this.lernenButton.Click += new System.Windows.RoutedEventHandler(this.Lernen_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.addVocButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\pages\PageEnglisch.xaml"
            this.addVocButton.Click += new System.Windows.RoutedEventHandler(this.AddVoc_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.listeButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\pages\PageEnglisch.xaml"
            this.listeButton.Click += new System.Windows.RoutedEventHandler(this.Liste_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

