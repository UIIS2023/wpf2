// Updated by XamlIntelliSenseFileGenerator 12/17/2023 1:30:39 PM
#pragma checksum "..\..\..\..\Forme\FrmKupac2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F2D5C04C0FF98470144C2FC95A386173AF925333"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Knjizara.Forme;
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


namespace Knjizara.Forme
{


    /// <summary>
    /// FrmKupac
    /// </summary>
    public partial class FrmKupac2 : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 21 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImeKupca;

#line default
#line hidden


#line 22 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezimeKupca;

#line default
#line hidden


#line 23 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresaKupca;

#line default
#line hidden


#line 24 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGradKupca;

#line default
#line hidden


#line 25 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontaktKupca;

#line default
#line hidden


#line 26 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxClanskaKarta;

#line default
#line hidden


#line 27 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;

#line default
#line hidden


#line 28 "..\..\..\..\Forme\FrmKupac2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFKnjizara;V1.0.0.0;component/forme/frmkupac2.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Forme\FrmKupac2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txtImeKupca = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.txtPrezimeKupca = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.txtAdresaKupca = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.txtGradKupca = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.txtKontaktKupca = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.cbxClanskaKarta = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 7:
                    this.btnSacuvaj = ((System.Windows.Controls.Button)(target));

#line 27 "..\..\..\..\Forme\FrmKupac2.xaml"
                    this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btnOtkazi = ((System.Windows.Controls.Button)(target));

#line 28 "..\..\..\..\Forme\FrmKupac2.xaml"
                    this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

