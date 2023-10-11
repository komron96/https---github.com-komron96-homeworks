SELECT TO_CHAR(DATE(datetime), 'DD.MM.YYYY') AS formatted_date, amount, account_currency
    from fimi_transaction
WHERE datetime BETWEEN '2023-09-01 00:00:00' AND '2023-09-01 23:59:09'
  AND tran_code NOT IN ('624', '801')
  AND (tran_type <> '420' OR tran_number NOT IN (SELECT DISTINCT tran_number
                                                 FROM fimi_transaction
                                                 WHERE datetime BETWEEN '2023-09-01 00:00:00' AND '2023-09-01 23:59:09'
                                                   AND tran_type = '420'))
  and tran_number in ('324400381536', '324400222004', '324447494025', '324403101003', '324400400170', '324450465642');