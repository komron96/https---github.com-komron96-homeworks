--1
SELECT COUNT(*) AS customer_count
FROM Customers;

--2
SELECT AVG(age) AS average_age
FROM Employees;

--3
--Задача идиентична из прошлой дз

--4
SELECT MIN(unit_price) AS min_order_price
FROM OrderDetails;

--5
SELECT MAX(salary) AS max_salary
FROM Employees;

--6
UPDATE Customers
SET age = age + 1
WHERE customer_id = 100;

--7
SELECT D.id, D.name, AVG(E.years_of_service) AS avg_years_of_service
FROM Departments AS D
LEFT JOIN Employees E ON D.id = E.department_id
GROUP BY D.id, D.name;

--8
DELETE FROM Orders
WHERE ORDER.Location = 'Moscow';

