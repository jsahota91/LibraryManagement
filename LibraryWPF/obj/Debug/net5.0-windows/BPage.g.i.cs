﻿#pragma checksum "..\..\..\BPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6FC15C8FA2F3D2C8AB4F10DE060A7B5870010704"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LibraryWPF;
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


namespace LibraryWPF {
    
    
    /// <summary>
    /// BPage
    /// </summary>
    public partial class BPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertBtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateBtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearBtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshBtn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox id_txt;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox title_txt;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox yearPublished_txt;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\BPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxBook;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LibraryWPF;component/bpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 24 "..\..\..\BPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HomePgClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\BPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenrePgClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 26 "..\..\..\BPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuthorPgClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 27 "..\..\..\BPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LocationPgClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\BPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RecordsPgClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.insertBtn = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\BPage.xaml"
            this.insertBtn.Click += new System.Windows.RoutedEventHandler(this.InsertBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.updateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\BPage.xaml"
            this.updateBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\BPage.xaml"
            this.deleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.clearBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\BPage.xaml"
            this.clearBtn.Click += new System.Windows.RoutedEventHandler(this.ClearBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.refreshBtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\BPage.xaml"
            this.refreshBtn.Click += new System.Windows.RoutedEventHandler(this.RefreshBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.id_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.title_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.yearPublished_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.ListBoxBook = ((System.Windows.Controls.ListBox)(target));
            
            #line 54 "..\..\..\BPage.xaml"
            this.ListBoxBook.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxBook_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

