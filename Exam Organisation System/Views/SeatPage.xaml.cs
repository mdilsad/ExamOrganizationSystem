using Exam_Organisation_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class SeatPage : ContentPage
{
    private readonly FakeDataService _fakeDataService;

    public SeatPage()
    {
        InitializeComponent();

        _fakeDataService = FakeDataService.Instance;

        var exam = _fakeDataService.SelectedExam;
        if (exam == null)
            return;

        CourseNameLabel.Text = exam.CourseName;
        DateLabel.Text = exam.FormattedDate;
        TimeLabel.Text = exam.FormattedTime;
        BuildingLabel.Text = exam.Building;
        ClassroomLabel.Text = exam.Classroom;
        SeatNumberLabel.Text = exam.SeatNumber.ToString();
    }
    private async void BackToMainClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}