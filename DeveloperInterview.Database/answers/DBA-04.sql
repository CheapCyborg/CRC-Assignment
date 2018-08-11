SELECT CustomerOrderId, FirstName
FROM Customer AS c
LEFT JOIN CustomerOrder co ON co.CustomerId = c.Id
LEFT JOIN OrderProduct o ON o.CustomerOrderId = co.Id
WHERE CustomerOrderId IS NULL
GROUP BY CustomerOrderId ,FirstName;