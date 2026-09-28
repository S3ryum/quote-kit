# QuoteKit

A tiny C# console app that turns service line items into a readable estimate. It calculates totals but does not save or send client data.

## Requirements

.NET 10 SDK.

## Build and run

~~~sh
dotnet run -- "Northwind Studio" "Website review" 4 75 10
~~~

Arguments are client name, service description, quantity, unit price, and tax percentage. Use a dot for decimal values.

## Example

~~~text
Estimate for Northwind Studio
Website review   4 x 75.00 = 300.00
Subtotal: 300.00
Tax (10%): 30.00
Total: 330.00
~~~
