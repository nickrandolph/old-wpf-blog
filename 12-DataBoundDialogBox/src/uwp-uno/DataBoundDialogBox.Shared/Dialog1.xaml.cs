using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataBoundDialogBox
{
    public sealed partial class Dialog1 : ContentDialog
    {
        public Dialog1()
        {
            this.InitializeComponent();
        }

        private void OKHandler(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            BindingExpression bindingExpressionName = NameTextBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpressionName.UpdateSource();
            BindingExpression bindingExpressionComment = CommentTextBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpressionComment.UpdateSource();
        }
    }
}
