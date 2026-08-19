using HuelgoApp.Mobile.Services;

namespace HuelgoApp.Mobile;

public partial class MainPage : ContentPage
{
	private readonly AuthApiClient _authApiClient;

	public MainPage(AuthApiClient authApiClient)
	{
		InitializeComponent();
		_authApiClient = authApiClient;
		BirthDatePicker.Date = DateTime.Today.AddYears(-18);
		Connectivity.Current.ConnectivityChanged += OnConnectivityChanged;
		Loaded += async (_, _) => await RestoreSessionAsync();
	}

	private async void OnRegisterClicked(object? sender, EventArgs e) => await ExecuteAsync(() => _authApiClient.RegisterAsync(FirstNameEntry.Text, LastNameEntry.Text, DateOnly.FromDateTime(BirthDatePicker.Date ?? DateTime.Today), EmailEntry.Text, PasswordEntry.Text, ConfirmPasswordEntry.Text));

	private async void OnLoginClicked(object? sender, EventArgs e) => await ExecuteAsync(() => _authApiClient.LoginAsync(EmailEntry.Text, PasswordEntry.Text));

	private async void OnLogoutClicked(object? sender, EventArgs e)
	{
		await _authApiClient.LogoutAsync();
		SetAuthenticated(false);
		StatusLabel.Text = "Sesión cerrada.";
	}

	private async Task ExecuteAsync(Func<Task> operation)
	{
		try
		{
			await operation();
			SetAuthenticated(true);
			StatusLabel.Text = "Sesión iniciada y almacenada de forma segura.";
		}
		catch (Exception)
		{
			StatusLabel.Text = "No se pudo completar la operación. Revisa los datos o la conexión.";
		}
	}

	private async Task RestoreSessionAsync()
	{
		SetAuthenticated(await _authApiClient.HasSessionAsync());
		UpdateConnectionStatus();
	}

	private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			UpdateConnectionStatus();
			if (e.NetworkAccess == NetworkAccess.Internet)
			{
				await _authApiClient.SyncPendingChangesAsync();
				StatusLabel.Text = "Sincronización completada.";
			}
		});
	}

	private void UpdateConnectionStatus() => ConnectionLabel.Text = Connectivity.Current.NetworkAccess == NetworkAccess.Internet ? "En línea" : "Sin conexión: los cambios quedan pendientes.";

	private void SetAuthenticated(bool authenticated)
	{
		LogoutButton.IsVisible = authenticated;
		DashboardLabel.IsVisible = authenticated;
		RegistrationFields.IsVisible = !authenticated;
		ConfirmPasswordEntry.IsVisible = !authenticated;
	}
}
