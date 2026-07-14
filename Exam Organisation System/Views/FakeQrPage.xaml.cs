using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Views;

public partial class FakeQrPage : ContentPage
{
    private readonly FakeDataService _fakeDataService;

    public FakeQrPage()
    {
        InitializeComponent(); 

        _fakeDataService = FakeDataService.Instance;

        var exam = _fakeDataService.SelectedExam;
        if (exam != null)
        {
            CourseNameLabel.Text = exam.CourseName;
        }
    }
    private async void OnScanClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SeatPage));
    }
}
