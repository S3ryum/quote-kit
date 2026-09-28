using System.Globalization;

if (args.Length != 5)
{
    Console.Error.WriteLine("Usage: QuoteKit <client> <description> <quantity> <unit-price> <tax-percent>");
    return 2;
}
string client = args[0].Trim();
string description = args[1].Trim();
if (client.Length == 0 || description.Length == 0)
{
    Console.Error.WriteLine("Client and description cannot be blank.");
    return 2;
}
if (!decimal.TryParse(args[2], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal quantity) ||
    !decimal.TryParse(args[3], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal unitPrice) ||
    !decimal.TryParse(args[4], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal taxPercent) ||
    quantity <= 0 || unitPrice < 0 || taxPercent < 0 || taxPercent > 100)
{
    Console.Error.WriteLine("Quantity must be positive; price cannot be negative and tax must be from 0 to 100 percent.");
    return 2;
}
decimal subtotal = decimal.Round(quantity * unitPrice, 2, MidpointRounding.AwayFromZero);
decimal tax = decimal.Round(subtotal * taxPercent / 100m, 2, MidpointRounding.AwayFromZero);
decimal total = subtotal + tax;
string money(decimal amount) => amount.ToString("0.00", CultureInfo.InvariantCulture);
Console.WriteLine("Estimate for " + client);
Console.WriteLine(description + "   " + quantity.ToString("0.##", CultureInfo.InvariantCulture)
    + " x " + money(unitPrice) + " = " + money(subtotal));
Console.WriteLine("Subtotal: " + money(subtotal));
Console.WriteLine("Tax (" + taxPercent.ToString("0.##", CultureInfo.InvariantCulture) + "%): " + money(tax));
Console.WriteLine("Total: " + money(total));
return 0;
