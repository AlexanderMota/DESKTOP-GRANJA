﻿#pragma checksum "..\..\..\..\vistas\DetalleTareaUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37A5B6A6404F4FFFB69DCC7D864A73D0D93C9C06"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using DESKTOP_GRANJA.modelos;
using Syncfusion;
using Syncfusion.UI.Xaml.Controls.DataPager;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.RowFilter;
using Syncfusion.UI.Xaml.TextInputLayout;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Filtering;
using Syncfusion.Windows;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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


namespace DESKTOP_GRANJA.vistas {
    
    
    /// <summary>
    /// DetalleTareaUC
    /// </summary>
    public partial class DetalleTareaUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition seccionTopPlantilla;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textoTituloTarea;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputTituloTarea;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateFechaInicio;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateFechaFin;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonSolicitarTarea;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonEditaPlantilla;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combBDepartamento;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combBImportancia;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textoDepartamento;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textoImportancia;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\vistas\DetalleTareaUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonEditaTarea;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DESKTOP-GRANJA;component/vistas/detalletareauc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\vistas\DetalleTareaUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.seccionTopPlantilla = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            this.textoTituloTarea = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.inputTituloTarea = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dateFechaInicio = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dateFechaFin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.botonSolicitarTarea = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.botonEditaPlantilla = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.combBDepartamento = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.combBImportancia = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.textoDepartamento = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.textoImportancia = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.botonEditaTarea = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\vistas\DetalleTareaUC.xaml"
            this.botonEditaTarea.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Editar);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 134 "..\..\..\..\vistas\DetalleTareaUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Comentar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 13:
            
            #line 95 "..\..\..\..\vistas\DetalleTareaUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ListBox_Selected);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

