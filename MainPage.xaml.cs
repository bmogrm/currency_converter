namespace currency_converter;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        ViewModel.ViewModel viewModel = new ViewModel.ViewModel();
		viewModel.Select_date = DateTime.Today;
        BindingContext = viewModel;
	}

}

