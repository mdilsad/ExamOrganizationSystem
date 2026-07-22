using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Exam_Organisation_System.Views;

public partial class QrScannerPage : ContentPage
{
    public QrScannerPage()
    {
        InitializeComponent();
        

        cameraView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.TwoDimensional,
            AutoRotate = true,
            Multiple = false
        };

        cameraView.BarcodesDetected += CameraView_BarcodesDetected;
    }

    private async void CameraView_BarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        var result = e.Results.FirstOrDefault();
        if (result == null)
            return;

        cameraView.IsDetecting = false;

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await DisplayAlert("QR Okundu", result.Value, "Tamam");
            cameraView.IsDetecting = true;
        });
    }
}