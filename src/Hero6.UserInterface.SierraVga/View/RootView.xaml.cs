// -----------------------------------------------------------
//  
//  This file was generated, please do not modify.
//  
// -----------------------------------------------------------
namespace LateStartStudio.Hero6.UserInterface.SierraVga.View {
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.ObjectModel;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Charts;
    using EmptyKeys.UserInterface.Data;
    using EmptyKeys.UserInterface.Controls;
    using EmptyKeys.UserInterface.Controls.Primitives;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Interactions.Core;
    using EmptyKeys.UserInterface.Interactivity;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Media.Effects;
    using EmptyKeys.UserInterface.Media.Animation;
    using EmptyKeys.UserInterface.Media.Imaging;
    using EmptyKeys.UserInterface.Shapes;
    using EmptyKeys.UserInterface.Renderers;
    using EmptyKeys.UserInterface.Themes;
    
    
    [GeneratedCodeAttribute("Empty Keys UI Generator", "2.6.0.0")]
    public partial class RootView : UIRoot {
        
        public RootView() : 
                base() {
            this.Initialize();
        }
        
        public RootView(int width, int height) : 
                base(width, height) {
            this.Initialize();
        }
        
        private void Initialize() {
            Style style = RootStyle.CreateRootStyle();
            style.TargetType = this.GetType();
            this.Style = style;
            this.InitializeComponent();
        }
        
        private void InitializeComponent() {
            this.Background = new SolidColorBrush(new ColorW(255, 255, 255, 0));
            this.FontFamily = new FontFamily("Arial");
            this.FontSize = 15F;
            Binding binding__OwnedWindowsContent = new Binding("Windows");
            this.SetBinding(UIRoot.OwnedWindowsContentProperty, binding__OwnedWindowsContent);
            InitializeElementResources(this);
            FontManager.Instance.AddFont("Arial", 15F, FontStyle.Regular, "Arial_11.25_Regular");
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [TextBoxWindow] ControlTemplate
            Func<UIElement, UIElement> r_0_ctFunc = r_0_ctMethod;
            ControlTemplate r_0_ct = new ControlTemplate(r_0_ctFunc);
            elem.Resources.Add("TextBoxWindow", r_0_ct);
        }
        
        private static UIElement r_0_ctMethod(UIElement parent) {
            // e_0 element
            Border e_0 = new Border();
            e_0.Parent = parent;
            e_0.Name = "e_0";
            e_0.Background = new SolidColorBrush(new ColorW(0, 0, 0, 255));
            // e_1 element
            TextBlock e_1 = new TextBlock();
            e_0.Child = e_1;
            e_1.Name = "e_1";
            e_1.TextWrapping = TextWrapping.Wrap;
            Binding binding_e_1_Text = new Binding("Text");
            e_1.SetBinding(TextBlock.TextProperty, binding_e_1_Text);
            return e_0;
        }
    }
}
