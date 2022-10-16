namespace FlashLightUI;

public partial class MainPage : ContentPage
{
	private bool IsFlashlightToggled { get; set; } = false;
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnFlashLightBtnClicked(object sender, EventArgs e)
	{
		await ToggleFlashLight();
	}

	private async Task ToggleFlashLight()
	{
		try
		{
            if (IsFlashlightToggled == false)
            {
                await Flashlight.Default.TurnOnAsync();
                IsFlashlightToggled = true;    
            }
            else
            {
                await Flashlight.Default.TurnOffAsync();
                IsFlashlightToggled = false;
            }

            SetFlashLightText();
            SetFlashLightImage();
        }
        catch (FeatureNotSupportedException ex)
        {
            // Handle not supported on device exception
        }
        catch (PermissionException ex)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to turn on/off flashlight
        }

    }

	private void SetFlashLightText()
	{
        string flashLightMessage = IsFlashlightToggled ? "On" : "Off"; 
		FlashLightLabel.Text = $"Flashlight is {flashLightMessage}";
    }

    private void SetFlashLightImage()
    {
        string flashLightImage = IsFlashlightToggled ? "flashlight_on.png" : "flashlight_off.png";
        FlashLightImage.Source = flashLightImage;
    }
}

