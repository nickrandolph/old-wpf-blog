using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

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
