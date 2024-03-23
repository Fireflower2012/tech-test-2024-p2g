// See https://aka.ms/new-console-template for more information
using Parcel2Go_tech_test;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = new ServiceCollection()
    .AddSingleton<ICheckout, Checkout>()
    .AddSingleton<IServiceCatalogue, ServiceCatalogue>()
    .BuildServiceProvider();

try
{
    var basket = serviceProvider.GetService<ICheckout>();

    if ( basket == null )
    { throw new NullReferenceException("Checkout service could not be found"); }

    ConsoleOutText.DisplayIntroText();
    ConsoleOutText.DisplayServiceList();

    bool keepRunning = true;
    var inputText = "";

    while (keepRunning)
    {
        inputText = Console.ReadLine();

        if (inputText.ToUpper() == "CHECKOUT")
        {
            keepRunning = false;
            ConsoleOutText.DisplayBasketSummaryText(basket.GetBasketSummary());
            ConsoleOutText.DisplayRunningTotal(basket.GetTotalPrice());
        }
        else
        {
            var result = basket.Scan(inputText);

            if (result)
            {
                ConsoleOutText.DisplayBasketSummaryText(basket.GetBasketSummary());
                ConsoleOutText.DisplayRunningTotal(basket.GetTotalPrice());

                Console.WriteLine();
            }
            else
            {
                ConsoleOutText.DisplayInvalidServiceText();
                ConsoleOutText.DisplayServiceList();
            }
        }

    }

    ConsoleOutText.DisplayExitText();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


