SELECT ProductId, [Name], (
	SELECT SUM(Quantity)
) AS 'Total Units'
FROM OrderProduct AS o
INNER JOIN Product p ON p.Id = o.ProductId
GROUP BY ProductId, [Name]
ORDER BY 'Total Units' DESC;