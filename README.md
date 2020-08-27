![InvestmentCalculator](https://github.com/Kirya522/InvestmentsCalculator/workflows/default/badge.svg)
# Калькулятор инвестиций на основе сложного процента

## Входные параметры

| Название параметра |                                 Значение |
| ------------------ | ---------------------------------------: |
| InitSum            |               Начальная сумма инвестиций |
| MonthlyAdd         |                      Ежемесячный прирост |
| YearlyPercent      |     Средний процент роста дохода в годах |
| PlanningHorizont   | Горизонт планирования инвестиций в годах |

---

## Выходные параметры

**Dictionary<long, double>** Коллекция значений расчётов по годам, ключ - год, значение - сумма в конце года

---

### Запуск
```sh
git clone <repo-url|ssh>
cd src
dotnet restore
dotnetn build
dotnet test
```