using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class ExamDetailPage : ContentPage
{
    private readonly FakeDataService _fakeDataService;
    public ExamDetailPage()
    {
        InitializeComponent();

        _fakeDataService = FakeDataService.Instance;

        var exam = _fakeDataService.SelectedExam;
        if (exam == null)
            return;
        CourseNameLabel.Text = exam.CourseName;
        DateLabel.Text = $"📅 {exam.FormattedDate}";
        TimeLabel.Text = $"🕒 {exam.FormattedTime}";
        BuildingLabel.Text = $"🏫 {exam.Building}";
        ClassroomLabel.Text = $"🚪 {exam.Classroom}";
        SupervisorLabel.Text = $"👨‍🏫 Gözetmen: {exam.Supervisor}";
        DescriptionLabel.Text = exam.Description;
    }
    private async void ShowQRClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FakeQrPage), true);
    }
}