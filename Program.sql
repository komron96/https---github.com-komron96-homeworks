--1
SELECT cus.id, cus.name, cus.lastname
FROM Customers cus
INNER JOIN Orders ord ON cus.customer_id = ord.customer_id
INNER JOIN OrderDetails OrDet ON ord.order_id = OrDetON.order_id;

--2
select sum(amount)
from orders
where created_at between '2023-09-01' and '2023-09-30'

--3
SELECT cus.id
FROM Customers cus
left join Orders ord ON cus.customer_id = ord.customer_id
where order_id is null

--4
select sum(amount)
from orders
left join OrderDetails OrDet ON ord.order_id = OrDet.order_id;
where OrDetON.city = "Moscow"

--5
SELECT cus.customer_id, cus.name, COUNT(Orders.order_id) AS total_orders
FROM Customers cus
LEFT JOIN Orders or ON cus.customer_id = or.id
GROUP BY cus.id, cus.name;
