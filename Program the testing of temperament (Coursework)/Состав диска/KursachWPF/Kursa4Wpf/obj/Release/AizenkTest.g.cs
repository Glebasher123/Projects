﻿#pragma checksum "..\..\AizenkTest.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E231216739D302AB7D4199737A6C7417A3353A4948909A59399D5A8A35996652"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursa4Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Kursa4Wpf {
    
    
    /// <summary>
    /// AizenkTest
    /// </summary>
    public partial class AizenkTest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MainTextBlock1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelCounter1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBack;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock YesButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NoBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AizenkTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelCounter;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kursa4Wpf;component/aizenktest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AizenkTest.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainTextBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.LabelCounter1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ButtonBack = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AizenkTest.xaml"
            this.ButtonBack.Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.YesButton = ((System.Windows.Controls.TextBlock)(target));
            
            #line 37 "..\..\AizenkTest.xaml"
            this.YesButton.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.YesButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NoBtn = ((System.Windows.Controls.TextBlock)(target));
            
            #line 38 "..\..\AizenkTest.xaml"
            this.NoBtn.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NoBtn_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LabelCounter = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

