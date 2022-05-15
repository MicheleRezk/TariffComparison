## Tariff Comparison
This is Tariff Comparison of Products
### Products
#### 1. Product A
Name: “basic electricity tariff”
Calculation model: base costs per month 5 € + consumption costs 22 cent/kWh Examples
##### Examples:
• Consumption = 3500 kWh/year => Annual costs = 830 €/year (5€ * 12 months = 60 € base
costs + 3500 kWh/year * 22 cent/kWh = 770 € consumption costs)
• Consumption = 4500 kWh/year => Annual costs = 1050 €/year (5€ * 12 months = 60 € base
costs + 4500 kWh/year * 22 cent/kWh = 990 € consumption costs)
• Consumption = 6000 kWh/year => Annual costs = 1380 €/year (5€ * 12 months = 60 € base
costs + 6000 kWh/year * 22 cent/kWh = 1320 € consumption costs) 

#### 2. Product B
Name: “Packaged tariff”
Calculation model: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh.
##### Examples:
• Consumption = 3500 kWh/year => Annual costs = 800 €/year
• Consumption = 4500 kWh/year => Annual costs = 950 €/year (800€ + 500 kWh * 30 cent/kWh
= 150 € additional consumption costs)
• Consumption = 6000 kWh/year => Annual costs = 1400 €/year (800€ + 2000 kWh * 30
cent/kWh = 600 € additional consumption costs)

### Solution
Solution consists of 3 projects:
#### TariffComparison.Backend
contains backend services for TariffComparison, 
to test it, pass the consumptionPerYear to products service like: /api/products/4500 
then you will get the 2 tariffs and each one with annualCosts in Euro
#### TariffComparison.Backend.Tests
contains unit test for both services and controllers.
#### TariffComparison.Backend.IntegrationTests
contains the integration tests of the api services

### how to test it
- docker-compose up
Then you can hit the service on this url like: http://localhost:9090/api/Products/3500