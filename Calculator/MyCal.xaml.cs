
namespace Calculator;

public partial class MyCal : ContentPage
{
	public MyCal()
	{
		InitializeComponent();
	}

    double x;
    double y;
    double output =0;
    string calOperator;




    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";
    double num;
    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        currentEntry = string.Empty;
        x = 0;
        y=0;
        calOperator = null;
        output = 0;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        //if (currentState == 2)
        //{
        //    if (secondNumber == 0)
        //        LockNumberValue(resultText.Text);

        //    double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

        //    this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

        //    this.resultText.Text = result.ToTrimmedString(decimalFormat);
        //    firstNumber = result;
        //    secondNumber = 0;
        //    currentState = -1;
        //    currentEntry = string.Empty;
        //}
        finalCaluculation(x, y, calOperator);

    }
    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;
        if (x != 0)
        {
            y = double.Parse(pressed.ToString());
        }
        if (x == 0)
        {
            x = double.Parse(pressed);
        }
        this.resultText.Text += pressed;


        //currentEntry += pressed;

        //if ((this.resultText.Text == "0" && pressed == "0")
        //    || (currentEntry.Length <= 1 && pressed != "0")
        //    || currentState < 0)
        //{
        //    this.resultText.Text = "";
        //    if (currentState < 0)
        //        currentState *= -1;
        //}

        //if (pressed == "." && decimalFormat != "N2")
        //{
        //    decimalFormat = "N2";
        //}

        //this.resultText.Text += pressed;
        //num = double.Parse(pressed);
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        //LockNumberValue(resultText.Text);

        //currentState = -2;
        //Button button = (Button)sender;
        //string pressed = button.Text;
        // mathOperator = pressed;

      
        finalCaluculation(x, y, calOperator);


        Button button = (Button)sender;
        string pressed = button.Text;
        calOperator = pressed;
        this.resultText.Text += pressed;

    }

    private void finalCaluculation(double a, double b, string ArthOperator)
    {
        if (x != 0 && y != 0)
        {
            double result = 0;
            switch (ArthOperator)
            {
                case "÷":
                    result = a / b;
                    break;
                case "×":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "MOD":
                    result = a % b;
                    break;
            }
            x = result;
            y = 0;
            this.resultText.Text = result.ToString();
        }
    }
    private void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }
    void SquareRoot(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            var Result = double.Parse(resultText.Text);
            resultText.Text = Math.Sqrt(Result).ToString();
        }

    }
    void ModClicked(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            var Result = double.Parse(resultText.Text);
            currentState = 2;
            // var mod = (value1% double.Parse(resultText.Text);
            //resultText.Text = mod.ToString();
        }
        if (currentState == 2)
        {
            var value2 = double.Parse(resultText.Text);
        }
    }
    void LeftParensis(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        this.resultText.Text += pressed;
    }
    void RightParensis(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        this.resultText.Text += pressed;
    }
}