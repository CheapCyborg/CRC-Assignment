SELECT CustomerId,CustomerOrderId, ProductId, [Name] FROM OrderProduct
RIGHT JOIN Product p ON p.Id = OrderProduct.ProductId
RIGHT JOIN CustomerOrder c ON c.id = OrderProduct.CustomerOrderId
WHERE ProductId IS NULL;