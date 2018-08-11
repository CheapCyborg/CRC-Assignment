SELECT CustomerId, FirstName, (
	SELECT SUM(price)
) AS 'Total Spent'
FROM Customer AS c
LEFT JOIN CustomerOrder co ON co.CustomerId = c.Id
LEFT JOIN OrderProduct o ON o.CustomerOrderId = co.Id
LEFT JOIN Product p ON p.Id = o.ProductId
GROUP BY CustomerId, FirstName
ORDER BY 'Total Spent' DESC;