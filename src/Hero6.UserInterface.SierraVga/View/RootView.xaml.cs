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
        
        private StackPanel e_3;
        
        private Image e_4;
        
        private Grid e_5;
        
        private Image e_6;
        
        private Button e_7;
        
        private Image e_9;
        
        private Button e_10;
        
        private Image e_12;
        
        private Button e_13;
        
        private Image e_15;
        
        private Button e_16;
        
        private Image e_18;
        
        private Button e_19;
        
        private Image e_21;
        
        private Button e_22;
        
        private Image e_24;
        
        private Button e_25;
        
        private Image e_27;
        
        private Button e_28;
        
        private Image e_30;
        
        private Button e_31;
        
        private Image e_33;
        
        private Image e_34;
        
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
            // e_3 element
            this.e_3 = new StackPanel();
            this.Content = this.e_3;
            this.e_3.Name = "e_3";
            // e_4 element
            this.e_4 = new Image();
            this.e_3.Children.Add(this.e_4);
            this.e_4.Name = "e_4";
            BitmapImage e_4_bm = new BitmapImage();
            e_4_bm.TextureAsset = "Top Bar/Background";
            this.e_4.Source = e_4_bm;
            Binding binding_e_4_Visibility = new Binding("IsTopBarVisible");
            this.e_4.SetBinding(Image.VisibilityProperty, binding_e_4_Visibility);
            // e_5 element
            this.e_5 = new Grid();
            this.e_3.Children.Add(this.e_5);
            this.e_5.Name = "e_5";
            this.e_5.HorizontalAlignment = HorizontalAlignment.Left;
            this.e_5.VerticalAlignment = VerticalAlignment.Top;
            RowDefinition row_e_5_0 = new RowDefinition();
            row_e_5_0.Height = new GridLength(36F, GridUnitType.Star);
            this.e_5.RowDefinitions.Add(row_e_5_0);
            ColumnDefinition col_e_5_0 = new ColumnDefinition();
            col_e_5_0.Width = new GridLength(10F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_0);
            ColumnDefinition col_e_5_1 = new ColumnDefinition();
            col_e_5_1.Width = new GridLength(32F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_1);
            ColumnDefinition col_e_5_2 = new ColumnDefinition();
            col_e_5_2.Width = new GridLength(32F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_2);
            ColumnDefinition col_e_5_3 = new ColumnDefinition();
            col_e_5_3.Width = new GridLength(33F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_3);
            ColumnDefinition col_e_5_4 = new ColumnDefinition();
            col_e_5_4.Width = new GridLength(35F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_4);
            ColumnDefinition col_e_5_5 = new ColumnDefinition();
            col_e_5_5.Width = new GridLength(32F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_5);
            ColumnDefinition col_e_5_6 = new ColumnDefinition();
            col_e_5_6.Width = new GridLength(35F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_6);
            ColumnDefinition col_e_5_7 = new ColumnDefinition();
            col_e_5_7.Width = new GridLength(34F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_7);
            ColumnDefinition col_e_5_8 = new ColumnDefinition();
            col_e_5_8.Width = new GridLength(33F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_8);
            ColumnDefinition col_e_5_9 = new ColumnDefinition();
            col_e_5_9.Width = new GridLength(34F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_9);
            ColumnDefinition col_e_5_10 = new ColumnDefinition();
            col_e_5_10.Width = new GridLength(10F, GridUnitType.Star);
            this.e_5.ColumnDefinitions.Add(col_e_5_10);
            Binding binding_e_5_Visibility = new Binding("IsVerbBarVisible");
            this.e_5.SetBinding(Grid.VisibilityProperty, binding_e_5_Visibility);
            // e_6 element
            this.e_6 = new Image();
            this.e_5.Children.Add(this.e_6);
            this.e_6.Name = "e_6";
            BitmapImage e_6_bm = new BitmapImage();
            e_6_bm.TextureAsset = "Verb Bar/Side Left";
            this.e_6.Source = e_6_bm;
            Grid.SetColumn(this.e_6, 0);
            // e_7 element
            this.e_7 = new Button();
            this.e_5.Children.Add(this.e_7);
            this.e_7.Name = "e_7";
            Style e_7_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_7_s_S_0_ctFunc = e_7_s_S_0_ctMethod;
            ControlTemplate e_7_s_S_0_ct = new ControlTemplate(typeof(Button), e_7_s_S_0_ctFunc);
            Setter e_7_s_S_0 = new Setter(Button.TemplateProperty, e_7_s_S_0_ct);
            e_7_s.Setters.Add(e_7_s_S_0);
            this.e_7.Style = e_7_s;
            Grid.SetColumn(this.e_7, 1);
            Binding binding_e_7_Command = new Binding("Walk");
            this.e_7.SetBinding(Button.CommandProperty, binding_e_7_Command);
            // e_9 element
            this.e_9 = new Image();
            this.e_7.Content = this.e_9;
            this.e_9.Name = "e_9";
            Style e_9_s = new Style(typeof(Image));
            Trigger e_9_s_T_0 = new Trigger();
            e_9_s_T_0.Property = Image.IsMouseOverProperty;
            e_9_s_T_0.Value = true;
            BitmapImage e_9_s_T_0_S_0_bm = new BitmapImage();
            e_9_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Walk Light";
            Setter e_9_s_T_0_S_0 = new Setter(Image.SourceProperty, e_9_s_T_0_S_0_bm);
            e_9_s_T_0.Setters.Add(e_9_s_T_0_S_0);
            e_9_s.Triggers.Add(e_9_s_T_0);
            this.e_9.Style = e_9_s;
            BitmapImage e_9_bm = new BitmapImage();
            e_9_bm.TextureAsset = "Verb Bar/Walk Dark";
            this.e_9.Source = e_9_bm;
            // e_10 element
            this.e_10 = new Button();
            this.e_5.Children.Add(this.e_10);
            this.e_10.Name = "e_10";
            Style e_10_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_10_s_S_0_ctFunc = e_10_s_S_0_ctMethod;
            ControlTemplate e_10_s_S_0_ct = new ControlTemplate(typeof(Button), e_10_s_S_0_ctFunc);
            Setter e_10_s_S_0 = new Setter(Button.TemplateProperty, e_10_s_S_0_ct);
            e_10_s.Setters.Add(e_10_s_S_0);
            this.e_10.Style = e_10_s;
            Grid.SetColumn(this.e_10, 2);
            Binding binding_e_10_Command = new Binding("Look");
            this.e_10.SetBinding(Button.CommandProperty, binding_e_10_Command);
            // e_12 element
            this.e_12 = new Image();
            this.e_10.Content = this.e_12;
            this.e_12.Name = "e_12";
            Style e_12_s = new Style(typeof(Image));
            Trigger e_12_s_T_0 = new Trigger();
            e_12_s_T_0.Property = Image.IsMouseOverProperty;
            e_12_s_T_0.Value = true;
            BitmapImage e_12_s_T_0_S_0_bm = new BitmapImage();
            e_12_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Look Light";
            Setter e_12_s_T_0_S_0 = new Setter(Image.SourceProperty, e_12_s_T_0_S_0_bm);
            e_12_s_T_0.Setters.Add(e_12_s_T_0_S_0);
            e_12_s.Triggers.Add(e_12_s_T_0);
            this.e_12.Style = e_12_s;
            BitmapImage e_12_bm = new BitmapImage();
            e_12_bm.TextureAsset = "Verb Bar/Look Dark";
            this.e_12.Source = e_12_bm;
            this.e_12.Stretch = Stretch.Uniform;
            // e_13 element
            this.e_13 = new Button();
            this.e_5.Children.Add(this.e_13);
            this.e_13.Name = "e_13";
            Style e_13_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_13_s_S_0_ctFunc = e_13_s_S_0_ctMethod;
            ControlTemplate e_13_s_S_0_ct = new ControlTemplate(typeof(Button), e_13_s_S_0_ctFunc);
            Setter e_13_s_S_0 = new Setter(Button.TemplateProperty, e_13_s_S_0_ct);
            e_13_s.Setters.Add(e_13_s_S_0);
            this.e_13.Style = e_13_s;
            Grid.SetColumn(this.e_13, 3);
            Binding binding_e_13_Command = new Binding("Hand");
            this.e_13.SetBinding(Button.CommandProperty, binding_e_13_Command);
            // e_15 element
            this.e_15 = new Image();
            this.e_13.Content = this.e_15;
            this.e_15.Name = "e_15";
            Style e_15_s = new Style(typeof(Image));
            Trigger e_15_s_T_0 = new Trigger();
            e_15_s_T_0.Property = Image.IsMouseOverProperty;
            e_15_s_T_0.Value = true;
            BitmapImage e_15_s_T_0_S_0_bm = new BitmapImage();
            e_15_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Hand Light";
            Setter e_15_s_T_0_S_0 = new Setter(Image.SourceProperty, e_15_s_T_0_S_0_bm);
            e_15_s_T_0.Setters.Add(e_15_s_T_0_S_0);
            e_15_s.Triggers.Add(e_15_s_T_0);
            this.e_15.Style = e_15_s;
            BitmapImage e_15_bm = new BitmapImage();
            e_15_bm.TextureAsset = "Verb Bar/Hand Dark";
            this.e_15.Source = e_15_bm;
            // e_16 element
            this.e_16 = new Button();
            this.e_5.Children.Add(this.e_16);
            this.e_16.Name = "e_16";
            Style e_16_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_16_s_S_0_ctFunc = e_16_s_S_0_ctMethod;
            ControlTemplate e_16_s_S_0_ct = new ControlTemplate(typeof(Button), e_16_s_S_0_ctFunc);
            Setter e_16_s_S_0 = new Setter(Button.TemplateProperty, e_16_s_S_0_ct);
            e_16_s.Setters.Add(e_16_s_S_0);
            this.e_16.Style = e_16_s;
            Grid.SetColumn(this.e_16, 4);
            Binding binding_e_16_Command = new Binding("Talk");
            this.e_16.SetBinding(Button.CommandProperty, binding_e_16_Command);
            // e_18 element
            this.e_18 = new Image();
            this.e_16.Content = this.e_18;
            this.e_18.Name = "e_18";
            Style e_18_s = new Style(typeof(Image));
            Trigger e_18_s_T_0 = new Trigger();
            e_18_s_T_0.Property = Image.IsMouseOverProperty;
            e_18_s_T_0.Value = true;
            BitmapImage e_18_s_T_0_S_0_bm = new BitmapImage();
            e_18_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Talk Light";
            Setter e_18_s_T_0_S_0 = new Setter(Image.SourceProperty, e_18_s_T_0_S_0_bm);
            e_18_s_T_0.Setters.Add(e_18_s_T_0_S_0);
            e_18_s.Triggers.Add(e_18_s_T_0);
            this.e_18.Style = e_18_s;
            BitmapImage e_18_bm = new BitmapImage();
            e_18_bm.TextureAsset = "Verb Bar/Talk Dark";
            this.e_18.Source = e_18_bm;
            // e_19 element
            this.e_19 = new Button();
            this.e_5.Children.Add(this.e_19);
            this.e_19.Name = "e_19";
            Style e_19_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_19_s_S_0_ctFunc = e_19_s_S_0_ctMethod;
            ControlTemplate e_19_s_S_0_ct = new ControlTemplate(typeof(Button), e_19_s_S_0_ctFunc);
            Setter e_19_s_S_0 = new Setter(Button.TemplateProperty, e_19_s_S_0_ct);
            e_19_s.Setters.Add(e_19_s_S_0);
            this.e_19.Style = e_19_s;
            Grid.SetColumn(this.e_19, 5);
            Binding binding_e_19_Command = new Binding("SubMenu");
            this.e_19.SetBinding(Button.CommandProperty, binding_e_19_Command);
            // e_21 element
            this.e_21 = new Image();
            this.e_19.Content = this.e_21;
            this.e_21.Name = "e_21";
            Style e_21_s = new Style(typeof(Image));
            Trigger e_21_s_T_0 = new Trigger();
            e_21_s_T_0.Property = Image.IsMouseOverProperty;
            e_21_s_T_0.Value = true;
            BitmapImage e_21_s_T_0_S_0_bm = new BitmapImage();
            e_21_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Sub Menu Light";
            Setter e_21_s_T_0_S_0 = new Setter(Image.SourceProperty, e_21_s_T_0_S_0_bm);
            e_21_s_T_0.Setters.Add(e_21_s_T_0_S_0);
            e_21_s.Triggers.Add(e_21_s_T_0);
            this.e_21.Style = e_21_s;
            BitmapImage e_21_bm = new BitmapImage();
            e_21_bm.TextureAsset = "Verb Bar/Sub Menu Dark";
            this.e_21.Source = e_21_bm;
            // e_22 element
            this.e_22 = new Button();
            this.e_5.Children.Add(this.e_22);
            this.e_22.Name = "e_22";
            Style e_22_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_22_s_S_0_ctFunc = e_22_s_S_0_ctMethod;
            ControlTemplate e_22_s_S_0_ct = new ControlTemplate(typeof(Button), e_22_s_S_0_ctFunc);
            Setter e_22_s_S_0 = new Setter(Button.TemplateProperty, e_22_s_S_0_ct);
            e_22_s.Setters.Add(e_22_s_S_0);
            this.e_22.Style = e_22_s;
            Grid.SetColumn(this.e_22, 6);
            Binding binding_e_22_Command = new Binding("Magic");
            this.e_22.SetBinding(Button.CommandProperty, binding_e_22_Command);
            // e_24 element
            this.e_24 = new Image();
            this.e_22.Content = this.e_24;
            this.e_24.Name = "e_24";
            Style e_24_s = new Style(typeof(Image));
            Trigger e_24_s_T_0 = new Trigger();
            e_24_s_T_0.Property = Image.IsMouseOverProperty;
            e_24_s_T_0.Value = true;
            BitmapImage e_24_s_T_0_S_0_bm = new BitmapImage();
            e_24_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Magic Light";
            Setter e_24_s_T_0_S_0 = new Setter(Image.SourceProperty, e_24_s_T_0_S_0_bm);
            e_24_s_T_0.Setters.Add(e_24_s_T_0_S_0);
            e_24_s.Triggers.Add(e_24_s_T_0);
            this.e_24.Style = e_24_s;
            BitmapImage e_24_bm = new BitmapImage();
            e_24_bm.TextureAsset = "Verb Bar/Magic Dark";
            this.e_24.Source = e_24_bm;
            // e_25 element
            this.e_25 = new Button();
            this.e_5.Children.Add(this.e_25);
            this.e_25.Name = "e_25";
            Style e_25_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_25_s_S_0_ctFunc = e_25_s_S_0_ctMethod;
            ControlTemplate e_25_s_S_0_ct = new ControlTemplate(typeof(Button), e_25_s_S_0_ctFunc);
            Setter e_25_s_S_0 = new Setter(Button.TemplateProperty, e_25_s_S_0_ct);
            e_25_s.Setters.Add(e_25_s_S_0);
            this.e_25.Style = e_25_s;
            Grid.SetColumn(this.e_25, 7);
            Binding binding_e_25_Command = new Binding("CurrentItem");
            this.e_25.SetBinding(Button.CommandProperty, binding_e_25_Command);
            // e_27 element
            this.e_27 = new Image();
            this.e_25.Content = this.e_27;
            this.e_27.Name = "e_27";
            Style e_27_s = new Style(typeof(Image));
            Trigger e_27_s_T_0 = new Trigger();
            e_27_s_T_0.Property = Image.IsMouseOverProperty;
            e_27_s_T_0.Value = true;
            BitmapImage e_27_s_T_0_S_0_bm = new BitmapImage();
            e_27_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Current Item Light";
            Setter e_27_s_T_0_S_0 = new Setter(Image.SourceProperty, e_27_s_T_0_S_0_bm);
            e_27_s_T_0.Setters.Add(e_27_s_T_0_S_0);
            e_27_s.Triggers.Add(e_27_s_T_0);
            this.e_27.Style = e_27_s;
            BitmapImage e_27_bm = new BitmapImage();
            e_27_bm.TextureAsset = "Verb Bar/Current Item Dark";
            this.e_27.Source = e_27_bm;
            // e_28 element
            this.e_28 = new Button();
            this.e_5.Children.Add(this.e_28);
            this.e_28.Name = "e_28";
            Style e_28_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_28_s_S_0_ctFunc = e_28_s_S_0_ctMethod;
            ControlTemplate e_28_s_S_0_ct = new ControlTemplate(typeof(Button), e_28_s_S_0_ctFunc);
            Setter e_28_s_S_0 = new Setter(Button.TemplateProperty, e_28_s_S_0_ct);
            e_28_s.Setters.Add(e_28_s_S_0);
            this.e_28.Style = e_28_s;
            Grid.SetColumn(this.e_28, 8);
            Binding binding_e_28_Command = new Binding("Inventory");
            this.e_28.SetBinding(Button.CommandProperty, binding_e_28_Command);
            // e_30 element
            this.e_30 = new Image();
            this.e_28.Content = this.e_30;
            this.e_30.Name = "e_30";
            Style e_30_s = new Style(typeof(Image));
            Trigger e_30_s_T_0 = new Trigger();
            e_30_s_T_0.Property = Image.IsMouseOverProperty;
            e_30_s_T_0.Value = true;
            BitmapImage e_30_s_T_0_S_0_bm = new BitmapImage();
            e_30_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Inventory Light";
            Setter e_30_s_T_0_S_0 = new Setter(Image.SourceProperty, e_30_s_T_0_S_0_bm);
            e_30_s_T_0.Setters.Add(e_30_s_T_0_S_0);
            e_30_s.Triggers.Add(e_30_s_T_0);
            this.e_30.Style = e_30_s;
            BitmapImage e_30_bm = new BitmapImage();
            e_30_bm.TextureAsset = "Verb Bar/Inventory Dark";
            this.e_30.Source = e_30_bm;
            // e_31 element
            this.e_31 = new Button();
            this.e_5.Children.Add(this.e_31);
            this.e_31.Name = "e_31";
            Style e_31_s = new Style(typeof(Button));
            Func<UIElement, UIElement> e_31_s_S_0_ctFunc = e_31_s_S_0_ctMethod;
            ControlTemplate e_31_s_S_0_ct = new ControlTemplate(typeof(Button), e_31_s_S_0_ctFunc);
            Setter e_31_s_S_0 = new Setter(Button.TemplateProperty, e_31_s_S_0_ct);
            e_31_s.Setters.Add(e_31_s_S_0);
            this.e_31.Style = e_31_s;
            Grid.SetColumn(this.e_31, 9);
            Binding binding_e_31_Command = new Binding("Options");
            this.e_31.SetBinding(Button.CommandProperty, binding_e_31_Command);
            // e_33 element
            this.e_33 = new Image();
            this.e_31.Content = this.e_33;
            this.e_33.Name = "e_33";
            Style e_33_s = new Style(typeof(Image));
            Trigger e_33_s_T_0 = new Trigger();
            e_33_s_T_0.Property = Image.IsMouseOverProperty;
            e_33_s_T_0.Value = true;
            BitmapImage e_33_s_T_0_S_0_bm = new BitmapImage();
            e_33_s_T_0_S_0_bm.TextureAsset = "Verb Bar/Options Light";
            Setter e_33_s_T_0_S_0 = new Setter(Image.SourceProperty, e_33_s_T_0_S_0_bm);
            e_33_s_T_0.Setters.Add(e_33_s_T_0_S_0);
            e_33_s.Triggers.Add(e_33_s_T_0);
            this.e_33.Style = e_33_s;
            BitmapImage e_33_bm = new BitmapImage();
            e_33_bm.TextureAsset = "Verb Bar/Options Dark";
            this.e_33.Source = e_33_bm;
            // e_34 element
            this.e_34 = new Image();
            this.e_5.Children.Add(this.e_34);
            this.e_34.Name = "e_34";
            BitmapImage e_34_bm = new BitmapImage();
            e_34_bm.TextureAsset = "Verb Bar/Side Right";
            this.e_34.Source = e_34_bm;
            Grid.SetColumn(this.e_34, 10);
            ImageManager.Instance.AddImage("Verb Bar/Current Item Dark");
            ImageManager.Instance.AddImage("Verb Bar/Current Item Light");
            ImageManager.Instance.AddImage("Verb Bar/Hand Dark");
            ImageManager.Instance.AddImage("Verb Bar/Hand Light");
            ImageManager.Instance.AddImage("Verb Bar/Inventory Dark");
            ImageManager.Instance.AddImage("Verb Bar/Inventory Light");
            ImageManager.Instance.AddImage("Verb Bar/Look Dark");
            ImageManager.Instance.AddImage("Verb Bar/Look Light");
            ImageManager.Instance.AddImage("Verb Bar/Magic Dark");
            ImageManager.Instance.AddImage("Verb Bar/Magic Light");
            ImageManager.Instance.AddImage("Verb Bar/Options Dark");
            ImageManager.Instance.AddImage("Verb Bar/Options Light");
            ImageManager.Instance.AddImage("Verb Bar/Side Left");
            ImageManager.Instance.AddImage("Verb Bar/Side Right");
            ImageManager.Instance.AddImage("Verb Bar/Sub Menu Dark");
            ImageManager.Instance.AddImage("Verb Bar/Sub Menu Light");
            ImageManager.Instance.AddImage("Verb Bar/Talk Dark");
            ImageManager.Instance.AddImage("Verb Bar/Talk Light");
            ImageManager.Instance.AddImage("Text Box/Background");
            ImageManager.Instance.AddImage("Text Box/Bottom Frame");
            ImageManager.Instance.AddImage("Text Box/Left Bottom Frame");
            ImageManager.Instance.AddImage("Text Box/Left Frame");
            ImageManager.Instance.AddImage("Text Box/Left Top Frame");
            ImageManager.Instance.AddImage("Text Box/Right Bottom Frame");
            ImageManager.Instance.AddImage("Text Box/Right Frame");
            ImageManager.Instance.AddImage("Text Box/Right Top Frame");
            ImageManager.Instance.AddImage("Text Box/Top Frame");
            ImageManager.Instance.AddImage("Top Bar/Background");
            ImageManager.Instance.AddImage("Verb Bar/Walk Dark");
            ImageManager.Instance.AddImage("Verb Bar/Walk Light");
            FontManager.Instance.AddFont("Arial", 15F, FontStyle.Regular, "Arial_11.25_Regular");
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [CurrentItemDark] BitmapImage
            BitmapImage r_0_bm = new BitmapImage();
            r_0_bm.TextureAsset = "Verb Bar/Current Item Dark";
            elem.Resources.Add("CurrentItemDark", r_0_bm);
            // Resource - [CurrentItemLight] BitmapImage
            BitmapImage r_1_bm = new BitmapImage();
            r_1_bm.TextureAsset = "Verb Bar/Current Item Light";
            elem.Resources.Add("CurrentItemLight", r_1_bm);
            // Resource - [HandDark] BitmapImage
            BitmapImage r_2_bm = new BitmapImage();
            r_2_bm.TextureAsset = "Verb Bar/Hand Dark";
            elem.Resources.Add("HandDark", r_2_bm);
            // Resource - [HandLight] BitmapImage
            BitmapImage r_3_bm = new BitmapImage();
            r_3_bm.TextureAsset = "Verb Bar/Hand Light";
            elem.Resources.Add("HandLight", r_3_bm);
            // Resource - [InventoryDark] BitmapImage
            BitmapImage r_4_bm = new BitmapImage();
            r_4_bm.TextureAsset = "Verb Bar/Inventory Dark";
            elem.Resources.Add("InventoryDark", r_4_bm);
            // Resource - [InventoryLight] BitmapImage
            BitmapImage r_5_bm = new BitmapImage();
            r_5_bm.TextureAsset = "Verb Bar/Inventory Light";
            elem.Resources.Add("InventoryLight", r_5_bm);
            // Resource - [LookDark] BitmapImage
            BitmapImage r_6_bm = new BitmapImage();
            r_6_bm.TextureAsset = "Verb Bar/Look Dark";
            elem.Resources.Add("LookDark", r_6_bm);
            // Resource - [LookLight] BitmapImage
            BitmapImage r_7_bm = new BitmapImage();
            r_7_bm.TextureAsset = "Verb Bar/Look Light";
            elem.Resources.Add("LookLight", r_7_bm);
            // Resource - [MagicDark] BitmapImage
            BitmapImage r_8_bm = new BitmapImage();
            r_8_bm.TextureAsset = "Verb Bar/Magic Dark";
            elem.Resources.Add("MagicDark", r_8_bm);
            // Resource - [MagicLight] BitmapImage
            BitmapImage r_9_bm = new BitmapImage();
            r_9_bm.TextureAsset = "Verb Bar/Magic Light";
            elem.Resources.Add("MagicLight", r_9_bm);
            // Resource - [OptionsDark] BitmapImage
            BitmapImage r_10_bm = new BitmapImage();
            r_10_bm.TextureAsset = "Verb Bar/Options Dark";
            elem.Resources.Add("OptionsDark", r_10_bm);
            // Resource - [OptionsLight] BitmapImage
            BitmapImage r_11_bm = new BitmapImage();
            r_11_bm.TextureAsset = "Verb Bar/Options Light";
            elem.Resources.Add("OptionsLight", r_11_bm);
            // Resource - [SideLeft] BitmapImage
            BitmapImage r_12_bm = new BitmapImage();
            r_12_bm.TextureAsset = "Verb Bar/Side Left";
            elem.Resources.Add("SideLeft", r_12_bm);
            // Resource - [SideRight] BitmapImage
            BitmapImage r_13_bm = new BitmapImage();
            r_13_bm.TextureAsset = "Verb Bar/Side Right";
            elem.Resources.Add("SideRight", r_13_bm);
            // Resource - [SubMenuDark] BitmapImage
            BitmapImage r_14_bm = new BitmapImage();
            r_14_bm.TextureAsset = "Verb Bar/Sub Menu Dark";
            elem.Resources.Add("SubMenuDark", r_14_bm);
            // Resource - [SubMenuLight] BitmapImage
            BitmapImage r_15_bm = new BitmapImage();
            r_15_bm.TextureAsset = "Verb Bar/Sub Menu Light";
            elem.Resources.Add("SubMenuLight", r_15_bm);
            // Resource - [TalkDark] BitmapImage
            BitmapImage r_16_bm = new BitmapImage();
            r_16_bm.TextureAsset = "Verb Bar/Talk Dark";
            elem.Resources.Add("TalkDark", r_16_bm);
            // Resource - [TalkLight] BitmapImage
            BitmapImage r_17_bm = new BitmapImage();
            r_17_bm.TextureAsset = "Verb Bar/Talk Light";
            elem.Resources.Add("TalkLight", r_17_bm);
            // Resource - [TextBoxBackground] BitmapImage
            BitmapImage r_18_bm = new BitmapImage();
            r_18_bm.TextureAsset = "Text Box/Background";
            elem.Resources.Add("TextBoxBackground", r_18_bm);
            // Resource - [TextBoxBottomFrame] BitmapImage
            BitmapImage r_19_bm = new BitmapImage();
            r_19_bm.TextureAsset = "Text Box/Bottom Frame";
            elem.Resources.Add("TextBoxBottomFrame", r_19_bm);
            // Resource - [TextBoxLeftBottomFrame] BitmapImage
            BitmapImage r_20_bm = new BitmapImage();
            r_20_bm.TextureAsset = "Text Box/Left Bottom Frame";
            elem.Resources.Add("TextBoxLeftBottomFrame", r_20_bm);
            // Resource - [TextBoxLeftFrame] BitmapImage
            BitmapImage r_21_bm = new BitmapImage();
            r_21_bm.TextureAsset = "Text Box/Left Frame";
            elem.Resources.Add("TextBoxLeftFrame", r_21_bm);
            // Resource - [TextBoxLeftTopFrame] BitmapImage
            BitmapImage r_22_bm = new BitmapImage();
            r_22_bm.TextureAsset = "Text Box/Left Top Frame";
            elem.Resources.Add("TextBoxLeftTopFrame", r_22_bm);
            // Resource - [TextBoxRightBottomFrame] BitmapImage
            BitmapImage r_23_bm = new BitmapImage();
            r_23_bm.TextureAsset = "Text Box/Right Bottom Frame";
            elem.Resources.Add("TextBoxRightBottomFrame", r_23_bm);
            // Resource - [TextBoxRightFrame] BitmapImage
            BitmapImage r_24_bm = new BitmapImage();
            r_24_bm.TextureAsset = "Text Box/Right Frame";
            elem.Resources.Add("TextBoxRightFrame", r_24_bm);
            // Resource - [TextBoxRightTopFrame] BitmapImage
            BitmapImage r_25_bm = new BitmapImage();
            r_25_bm.TextureAsset = "Text Box/Right Top Frame";
            elem.Resources.Add("TextBoxRightTopFrame", r_25_bm);
            // Resource - [TextBoxTopFrame] BitmapImage
            BitmapImage r_26_bm = new BitmapImage();
            r_26_bm.TextureAsset = "Text Box/Top Frame";
            elem.Resources.Add("TextBoxTopFrame", r_26_bm);
            // Resource - [TextBoxWindow] ControlTemplate
            Func<UIElement, UIElement> r_27_ctFunc = r_27_ctMethod;
            ControlTemplate r_27_ct = new ControlTemplate(r_27_ctFunc);
            elem.Resources.Add("TextBoxWindow", r_27_ct);
            // Resource - [TopBarBackground] BitmapImage
            BitmapImage r_28_bm = new BitmapImage();
            r_28_bm.TextureAsset = "Top Bar/Background";
            elem.Resources.Add("TopBarBackground", r_28_bm);
            // Resource - [VerbBarButtonStyle] Style
            Style r_29_s = new Style(typeof(Button));
            Func<UIElement, UIElement> r_29_s_S_0_ctFunc = r_29_s_S_0_ctMethod;
            ControlTemplate r_29_s_S_0_ct = new ControlTemplate(typeof(Button), r_29_s_S_0_ctFunc);
            Setter r_29_s_S_0 = new Setter(Button.TemplateProperty, r_29_s_S_0_ct);
            r_29_s.Setters.Add(r_29_s_S_0);
            elem.Resources.Add("VerbBarButtonStyle", r_29_s);
            // Resource - [WalkDark] BitmapImage
            BitmapImage r_30_bm = new BitmapImage();
            r_30_bm.TextureAsset = "Verb Bar/Walk Dark";
            elem.Resources.Add("WalkDark", r_30_bm);
            // Resource - [WalkLight] BitmapImage
            BitmapImage r_31_bm = new BitmapImage();
            r_31_bm.TextureAsset = "Verb Bar/Walk Light";
            elem.Resources.Add("WalkLight", r_31_bm);
        }
        
        private static UIElement r_27_ctMethod(UIElement parent) {
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
        
        private static UIElement r_29_s_S_0_ctMethod(UIElement parent) {
            // e_2 element
            ContentPresenter e_2 = new ContentPresenter();
            e_2.Parent = parent;
            e_2.Name = "e_2";
            Binding binding_e_2_Content = new Binding("Content");
            binding_e_2_Content.Source = parent;
            e_2.SetBinding(ContentPresenter.ContentProperty, binding_e_2_Content);
            return e_2;
        }
        
        private static UIElement e_7_s_S_0_ctMethod(UIElement parent) {
            // e_8 element
            ContentPresenter e_8 = new ContentPresenter();
            e_8.Parent = parent;
            e_8.Name = "e_8";
            Binding binding_e_8_Content = new Binding("Content");
            binding_e_8_Content.Source = parent;
            e_8.SetBinding(ContentPresenter.ContentProperty, binding_e_8_Content);
            return e_8;
        }
        
        private static UIElement e_10_s_S_0_ctMethod(UIElement parent) {
            // e_11 element
            ContentPresenter e_11 = new ContentPresenter();
            e_11.Parent = parent;
            e_11.Name = "e_11";
            Binding binding_e_11_Content = new Binding("Content");
            binding_e_11_Content.Source = parent;
            e_11.SetBinding(ContentPresenter.ContentProperty, binding_e_11_Content);
            return e_11;
        }
        
        private static UIElement e_13_s_S_0_ctMethod(UIElement parent) {
            // e_14 element
            ContentPresenter e_14 = new ContentPresenter();
            e_14.Parent = parent;
            e_14.Name = "e_14";
            Binding binding_e_14_Content = new Binding("Content");
            binding_e_14_Content.Source = parent;
            e_14.SetBinding(ContentPresenter.ContentProperty, binding_e_14_Content);
            return e_14;
        }
        
        private static UIElement e_16_s_S_0_ctMethod(UIElement parent) {
            // e_17 element
            ContentPresenter e_17 = new ContentPresenter();
            e_17.Parent = parent;
            e_17.Name = "e_17";
            Binding binding_e_17_Content = new Binding("Content");
            binding_e_17_Content.Source = parent;
            e_17.SetBinding(ContentPresenter.ContentProperty, binding_e_17_Content);
            return e_17;
        }
        
        private static UIElement e_19_s_S_0_ctMethod(UIElement parent) {
            // e_20 element
            ContentPresenter e_20 = new ContentPresenter();
            e_20.Parent = parent;
            e_20.Name = "e_20";
            Binding binding_e_20_Content = new Binding("Content");
            binding_e_20_Content.Source = parent;
            e_20.SetBinding(ContentPresenter.ContentProperty, binding_e_20_Content);
            return e_20;
        }
        
        private static UIElement e_22_s_S_0_ctMethod(UIElement parent) {
            // e_23 element
            ContentPresenter e_23 = new ContentPresenter();
            e_23.Parent = parent;
            e_23.Name = "e_23";
            Binding binding_e_23_Content = new Binding("Content");
            binding_e_23_Content.Source = parent;
            e_23.SetBinding(ContentPresenter.ContentProperty, binding_e_23_Content);
            return e_23;
        }
        
        private static UIElement e_25_s_S_0_ctMethod(UIElement parent) {
            // e_26 element
            ContentPresenter e_26 = new ContentPresenter();
            e_26.Parent = parent;
            e_26.Name = "e_26";
            Binding binding_e_26_Content = new Binding("Content");
            binding_e_26_Content.Source = parent;
            e_26.SetBinding(ContentPresenter.ContentProperty, binding_e_26_Content);
            return e_26;
        }
        
        private static UIElement e_28_s_S_0_ctMethod(UIElement parent) {
            // e_29 element
            ContentPresenter e_29 = new ContentPresenter();
            e_29.Parent = parent;
            e_29.Name = "e_29";
            Binding binding_e_29_Content = new Binding("Content");
            binding_e_29_Content.Source = parent;
            e_29.SetBinding(ContentPresenter.ContentProperty, binding_e_29_Content);
            return e_29;
        }
        
        private static UIElement e_31_s_S_0_ctMethod(UIElement parent) {
            // e_32 element
            ContentPresenter e_32 = new ContentPresenter();
            e_32.Parent = parent;
            e_32.Name = "e_32";
            Binding binding_e_32_Content = new Binding("Content");
            binding_e_32_Content.Source = parent;
            e_32.SetBinding(ContentPresenter.ContentProperty, binding_e_32_Content);
            return e_32;
        }
    }
}
