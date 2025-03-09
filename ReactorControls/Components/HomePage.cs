namespace MauiReactor.Startup.Components;

internal class HomePageState
{
    public string EnteredText { get; set; } = "Here's what you typed";
    public double StepperValue { get; set; }
    public double SliderValue { get; set; }
    public int SelectedBirdIndex { get; set; } = -1;
    public string BirdsText { get; set; } = string.Empty;
}

internal class HomePage : Component<HomePageState>
{
    private readonly List<string> _birds = ["Duck", "Pigeon", "Penguin", "Ostrich", "Owl"];

    public override VisualNode Render()
        => ContentPage(
            ScrollView(
                VStack(
                        Entry()
                            .Placeholder("Enter some text")
                            .OnTextChanged(text => SetState(s => s.EnteredText = text))
                            .Set(SemanticProperties.HintProperty, "Lets you enter some text"),
                        Label(State.EnteredText)
                            .Set(SemanticProperties.HintProperty, "Here's what you typed")
                            .BackgroundColor(Colors.Gold),
                        Stepper()
                            .Minimum(0)
                            .Maximum(10)
                            .Increment(1)
                            .OnValueChanged((_, e) => SetState(s => s.StepperValue = e.NewValue)),
                        Label("Here's the Stepper value:")
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Stepper"),
                        Label(State.StepperValue)
                            .BackgroundColor(Colors.LightBlue)
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Stepper"),
                        Slider()
                            .Minimum(0.0)
                            .Maximum(1.0)
                            .OnValueChanged((_, e) => SetState(s => s.SliderValue = e.NewValue)),
                        Label("Here's the Slider value:")
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Slider"),
                        Label(State.SliderValue)
                            .BackgroundColor(Colors.LightBlue)
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Slider"),
                        Label("Select a bird:")
                            .Set(SemanticProperties.DescriptionProperty,
                                "The picker to select some birds"),
                        Picker()
                            .Title(DeviceInfo.Platform == DevicePlatform.MacCatalyst ? string.Empty : "Select a Bird:")
                            .OnSelectedIndexChanged(index => SetState(s => s.SelectedBirdIndex = index))
                            .ItemsSource(_birds),
                        Button("Add a bird")
                            .OnClicked(() => SetState(s =>
                            {
                                s.BirdsText += string.IsNullOrEmpty(s.BirdsText)
                                    ? string.Empty
                                    : Environment.NewLine + _birds[s.SelectedBirdIndex];
                            })),
                        Label("Here are the selected birds:"),
                        Label(State.BirdsText)
                    )
                    .VCenter()
                    .Spacing(25)
                    .Padding(30, 0)
            )
        );
}