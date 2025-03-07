namespace MauiReactor.Startup.Components;

internal class HomePageState
{
    public int Counter { get; set; }
    public string EnteredText { get; set; } = "Here's what you typed";

    public double StepperValue { get; set; }
    public double SliderValue { get; set; }
    public int SelectedBirdIndex { get; set; } 
    public string BirdsText { get; set; }

}

internal class HomePage : Component<HomePageState>
{
    private List<string> birds = ["Duck", "Pigeon", "Penguin", "Ostrich", "Owl"];
    
    public override VisualNode Render()
        => ContentPage(
            ScrollView(
                VStack(
                        Entry()
                            .Placeholder("Enter some text")
                            .FontSize(22)
                            // .OnTextChanged((_, e) => SetState(s => s.EnteredText = e.NewTextValue))
                            .OnTextChanged(value => SetState(s => s.EnteredText = value))
                            .Set(SemanticProperties.HintProperty, "Lets you enter some text"),
                        Label(State.EnteredText)
                            .Set(SemanticProperties.HintProperty, "Here's what you typed")
                            .BackgroundColor(Colors.Gold)
                            .FontSize(28),
                        Stepper()
                            .Minimum(0)
                            .Maximum(10)
                            .VCenter()
                            .Increment(1)
                            .OnValueChanged((_, e) => SetState(s => s.StepperValue = e.NewValue)),
                        Label("Here's the Stepper value:")
                            .FontSize(24)
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Stepper"),
                        Label(State.StepperValue)
                            .BackgroundColor(Colors.LightBlue)
                            .FontSize(28)
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Stepper"),
                        Slider()
                            .Minimum(0)
                            .Maximum(1)
                            .OnValueChanged((_, e) => SetState(s => s.SliderValue = e.NewValue)),
                        Label("Here's the Slider value:")
                            .FontSize(24)
                            .VCenter()
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Slider"),
                        Label(State.SliderValue)
                            .BackgroundColor(Colors.LightBlue)
                            .FontSize(28)
                            .VCenter()
                            .Set(SemanticProperties.DescriptionProperty,
                                "The number the user chose with the Slider"),
                        HStack(
                            Picker()
                                .FontSize(28)
                                .Title("Pick a bird")
                                .SelectedIndex(State.SelectedBirdIndex)
                                .OnSelectedIndexChanged(index => SetState(s => s.SelectedBirdIndex = index))
                                .ItemsSource(birds),
                            VStack(
                                Label(State.BirdsText)
                            )
                        ),
                        Button("Add a bird")
                            .FontSize(28)
                            .OnClicked(() => SetState(s => s.BirdsText += Environment.NewLine + birds[s.SelectedBirdIndex]))
                    )
                    .VCenter()
                    .Spacing(25)
                    .Padding(30, 0)
            )
        );
    
}