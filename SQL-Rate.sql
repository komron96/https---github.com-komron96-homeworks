SELECT distinct TO_CHAR(DATE(datetime), 'DD.MM.YYYY') AS formatted_date, official_rate, currency_from
FROM exchange_rates
WHERE datetime BETWEEN '2023-10-01' AND '2023-10-04'
  AND type = 'standard'
AND currency_from IN ('RUB', 'USD')
AND currency_to = 'TJS'
order by currency_from, formatted_date;
