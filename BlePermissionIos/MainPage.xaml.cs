using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace BlePermissionIos;

public partial class MainPage : ContentPage
{
    private IAdapter _adapter;

    public MainPage()
	{
		InitializeComponent();

        _adapter = CrossBluetoothLE.Current.Adapter;
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		Task.Run(async () =>
		{
			var status = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();
			await MainThread.InvokeOnMainThreadAsync(() =>
			{
				CounterBtn.Text = $"{status}";
			});
		});
	}
}

