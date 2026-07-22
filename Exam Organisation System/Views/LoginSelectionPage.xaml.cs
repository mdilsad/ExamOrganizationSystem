using Exam_Organisation_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class LoginSelectionPage : ContentPage
{
    public LoginSelectionPage(LoginSelectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}