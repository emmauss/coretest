using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Controls;
using System;

namespace coretest
{
    public partial class MainWindow : CoreWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void SetTitleBar(CoreWindow cw)
        {
            var titleBar = cw.TitleBar;
            if (titleBar != null)
            {
                titleBar.ExtendViewIntoTitleBar = true;
                if (this.FindControl<Grid>("TitleBarHost") is Grid stack)
                {
                    cw.SetTitleBar(stack);
                    stack.Margin = new Thickness(0, 0, titleBar.SystemOverlayRightInset, 0);
                }
            }
        }

        protected override void OnOpened(EventArgs e)
        {
            SetTitleBar(this);
            base.OnOpened(e);
        }
    }
}
