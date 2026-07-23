using Exam_Organisation_System.ViewModels;
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
    private bool _isProcessing;

    public QrScannerPage(QrScannerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

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
        if (_isProcessing)
            return;

        _isProcessing = true;

        var result = e.Results.FirstOrDefault();
        if (result == null)
        {
            _isProcessing = false;
            return;
        }

        cameraView.IsDetecting = false;

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (BindingContext is QrScannerViewModel vm)
            {
                await vm.OnBarcodeDetected(result.Value);
            }
            // cameraView.IsDetecting = true;  -- removed as requested
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _isProcessing = false;
        cameraView.IsDetecting = true;
        cameraView.BarcodesDetected -= CameraView_BarcodesDetected;
        cameraView.BarcodesDetected += CameraView_BarcodesDetected;
    }

    protected override void OnDisappearing()
    {
        cameraView.IsDetecting = false;
        cameraView.BarcodesDetected -= CameraView_BarcodesDetected;

        cameraView.Handler?.DisconnectHandler();
        cameraView.Handler = null;

        base.OnDisappearing();
    }
}